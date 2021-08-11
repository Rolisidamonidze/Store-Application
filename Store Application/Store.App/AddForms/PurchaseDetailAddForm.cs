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
   public partial class PurchaseDetailAddForm : Form {
      ProductRepository _productRepository;
      IEnumerable<Product> _products;

      public PurchaseDetailAddForm() {
         InitializeComponent();

         _productRepository = new ProductRepository();
         _products = _productRepository.Select();

         FillFields();
      }

      private void FillFields() {
         foreach (var product in _products) {
            txtProducts.AutoCompleteCustomSource.Add(product.ToString());
         }
      }

      private void btnSubmit_Click(object sender, EventArgs e) {
         var purchaseDetail = new PurchaseDetail();
         try {
            purchaseDetail.ProductID = _products.First(p => p.Name == txtProducts.Text).ID;
         } catch (Exception) {
            MessageBox.Show("Inputed product does not exist");
         }

         try {
            purchaseDetail.Quantity = short.Parse(txtQuantity.Text);
            purchaseDetail.ExpirationDate = dtpExpirationDate.Value;
            purchaseDetail.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            purchaseDetail.StoreDate = dtpStoreDate.Value;
         } catch (Exception) {
            MessageBox.Show("Please, input data in correct format");
         }

         ((PurchaseAddForm)this.Owner).BindingSource.Add(purchaseDetail);
         this.Close();
      }
   }
}
