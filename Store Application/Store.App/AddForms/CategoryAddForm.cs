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
   public partial class CategoryAddForm : Form {
      CategoryRepository _categoryRepository;
      public CategoryAddForm() {
         InitializeComponent();
         _categoryRepository = new CategoryRepository();
      }

      private void btnConfirm_Click(object sender, EventArgs e) {
         Category category = new Category
         {
            Description = txtDescription.Text,
            Name = txtName.Text,
         };

         try {
            _categoryRepository.Insert(category, LocalStorage.CurrentUser.ID);
            this.Close();
         } catch (Exception) {
            throw;
         }
      }
   }
}
