using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Store.App.AddForms {
   public partial class OrderAddForm : Form {
      OrderRepository _orderRepository;
      OrderDetailRepository _orderDetailRepository;
      ProductRepository _productRepository;
      BindingSource _bindingSource;
      IEnumerable<Product> _products;

      public OrderAddForm() {
         InitializeComponent();
         _orderRepository = new();
         _orderDetailRepository = new();
         _productRepository = new();
         _bindingSource = new();

         _bindingSource.DataSource = new List<OrderDetail>();
         dgvOrderDetails.DataSource = _bindingSource;

         _products = _productRepository.Select();
         FillFields();

         txtDiscount.Enabled = false;
         cbxDiscount.Checked = false;
         cbxDiscount.CheckedChanged += CbxDiscount_CheckedChanged;
      }

      private void CbxDiscount_CheckedChanged(object sender, EventArgs e) {
         txtDiscount.Enabled = !txtDiscount.Enabled;
      }

      private void FillFields() {
         foreach (var product in _products) {
            txtProducts.AutoCompleteCustomSource.Add(product.Name);
         }

         txtUser.Text = LocalStorage.CurrentUser.Username;
         txtUser.Enabled = false;
      }

      private void btnAddToList_Click(object sender, EventArgs e) {
         var orderDetail = new OrderDetail();
         try {
            orderDetail.ProductID = _products.First(p => p.Name == txtProducts.Text).ID;
            orderDetail.Quantity = short.Parse(txtQuantity.Text);
            orderDetail.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            orderDetail.Discount = txtDiscount.Enabled ? double.Parse(txtDiscount.Text) : default;
            
         } catch (ArgumentException) {
            MessageBox.Show("Please, input data in correct format");
         } catch {
            MessageBox.Show("Error");
         }

         _bindingSource.Add(orderDetail);
      }

      private void btnConfirm_Click(object sender, EventArgs e) {
         var orderTransaction = _orderRepository.BeginTransaction();
         _orderDetailRepository.ShareTransaction(orderTransaction);

         Order order = new Order { UserID = LocalStorage.CurrentUser.ID };

         try {
            var orderId =  _orderRepository.Insert(order, LocalStorage.CurrentUser.ID);

            foreach (var orderDetail in (IEnumerable<OrderDetail>)_bindingSource.DataSource) {
               orderDetail.ID = orderId;
               _orderDetailRepository.Insert(orderDetail, LocalStorage.CurrentUser.ID);
            }

            _orderRepository.CommitTransaction();

            this.Close();
         } catch (Exception ex) {
            MessageBox.Show(ex.Message);
            _orderRepository.RollbackTransaction();
         }
      }
   }
}
