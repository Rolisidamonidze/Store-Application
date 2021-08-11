using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Store.App.AddForms {
   public partial class PurchaseAddForm : Form {
      ProviderRepository _providerRepository;
      PurchaseRepository _purchaseRepository;
      PurchaseDetailRepository _purchasDetailRepository;
      ProductRepository _productRepository;
      List<Provider> _providers;
      BindingSource _bindingSource;

      public PurchaseAddForm() {
         InitializeComponent();
         _providerRepository = new ProviderRepository();
         _purchaseRepository = new PurchaseRepository();
         _purchasDetailRepository = new PurchaseDetailRepository();
         _productRepository = new ProductRepository();

         _providers = new List<Provider>();
         _providers.AddRange(_providerRepository.Select());
         _bindingSource = new BindingSource();
         _bindingSource.DataSource = new List<PurchaseDetail>();
         dgvPurchases.DataSource = _bindingSource;

         FillFields();
      }

      public BindingSource BindingSource {
         get {
            return _bindingSource;
         }
         set {
            _bindingSource = value;
         }
      }

      private void FillFields() {
         foreach (var provider in _providers) {
            txtProviders.AutoCompleteCustomSource.Add(provider.ToString());
         }

         txtUser.Text = LocalStorage.CurrentUser.Username;
         txtUser.Enabled = false;
      }

      private void btnPurchaseDetailsAdd_Click(object sender, EventArgs e) {
         var purchaseDetailsForm = new PurchaseDetailAddForm();
         purchaseDetailsForm.Owner = this;
         purchaseDetailsForm.Show();
      }

      private void btnSubmit_Click(object sender, EventArgs e) {
         var purchaseTransaction = _purchaseRepository.BeginTransaction();
         _purchasDetailRepository.ShareTransaction(purchaseTransaction);

         Purchase purchase = new Purchase();
         purchase.UserID = LocalStorage.CurrentUser.ID;
         purchase.RequiredDate = dtpRequiredDate.Value;

         try {
            purchase.ProviderID = _providers.First(p => p.Name == txtProviders.Text).ID;
            var id = _purchaseRepository.Insert(purchase, LocalStorage.CurrentUser.ID);

            foreach (PurchaseDetail purchaseDetail in (IEnumerable<PurchaseDetail>)_bindingSource.DataSource) {
               purchaseDetail.ID = id;
               _purchasDetailRepository.Insert(purchaseDetail, LocalStorage.CurrentUser.ID);
            }

            _purchaseRepository.CommitTransaction();
            this.Close();
            new ListForm<Purchase>().Show();
         } catch (Exception ex) {
            MessageBox.Show(ex.Message);
            _purchaseRepository.RollbackTransaction();
         }
      }
   }
}
