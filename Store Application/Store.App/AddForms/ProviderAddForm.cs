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
   public partial class ProviderAddForm : Form {
      ProviderRepository _ProviderRepository;
      public ProviderAddForm() {
         InitializeComponent();
         _ProviderRepository = new ProviderRepository();
      }

      private void btnConfirm_Click(object sender, EventArgs e) {
         Provider provider = new Provider()
         {
            Name = txtName.Text,
            Phone = txtPhone.Text,
            Email = txtEmail.Text,
         };
         try {
            _ProviderRepository.Insert(provider, LocalStorage.CurrentUser.ID);
            this.Close();
         } catch (Exception) {
            throw;
         }
      }
   }
}
