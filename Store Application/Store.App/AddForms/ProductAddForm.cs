using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.App.AddForms {
   public partial class ProductAddForm : Form {
      ProductRepository _productRepository;
      ProductDetailRepository _productDetailRepository;
      CategoryRepository _categoryRepository;
      IEnumerable<Category> _categories;


      public ProductAddForm() {
         InitializeComponent();
         this.Text = "Add Form";

         _categoryRepository = new();
         _productRepository = new();
         _productDetailRepository = new();
         _categories = _categoryRepository.Select();

         foreach (Category category in _categories) {
            cmbxCategory.Items.Add(category);
         }
      }

      private void btnConfirm_Click(object sender, EventArgs e) {

      }

      private void btnAddProduct_Click(object sender, EventArgs e) {
         Product product = new Product();
         product.Name = txtName.Text;
         product.ProductCode = short.Parse(txtCode.Text);
         product.UnitPrice = decimal.Parse(txtUnitPrice.Text);
         product.CategoryID = _categories.Where((c) => c.Name == cmbxCategory.Text)
                                         .Select((c) => c.ID)
                                         .FirstOrDefault();

         try {
            _productRepository.Insert(product, LocalStorage.CurrentUser.ID);
            this.Close();
         } catch (Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
