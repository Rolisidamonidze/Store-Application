using Store.Models;
using Store.Repositories;
using System;
using System.Windows.Forms;
using Store.App.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Store.App {
   public partial class ListForm<TModel> : Form where TModel : new() {
      BaseRepository<TModel> _repository;
      BindingSource _bindingSource;
      public DataGridView _dataGridView;
      Pagination<TModel> _pagination;

      public ListForm(IEnumerable<TModel> items): this() {
         InitializeComponent();
        
         _pagination = new Pagination<TModel>(items, 20);
         _bindingSource.DataSource = _pagination.CurrentChunk;
      }

      public ListForm() {
         InitializeComponent();
         _repository = new BaseRepository<TModel>();
         this.Text = typeof(TModel).Name + "s";
         this.Name = typeof(TModel).Name + "ListForm";
         this.MdiParent = LocalStorage.MainForm;

         _pagination = new Pagination<TModel>(_repository.Select(), 20);
         _dataGridView = new DataGridView() { Dock = DockStyle.Fill };
         _bindingSource = new BindingSource();
         _bindingSource.DataSource = _pagination.CurrentChunk;
         _dataGridView.DataSource = _bindingSource;
         _dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
         _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         _dataGridView.MultiSelect = false;
         _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

         if (typeof(TModel).Equals(typeof(Purchase))) {
            _dataGridView.CellDoubleClick += _purchaseDataGridView_CellDoubleClick;
         } else if (typeof(TModel).Equals(typeof(Order))) {
            _dataGridView.CellDoubleClick += _orderDataGridView_CellDoubleClick;
         } else if (typeof(TModel).Equals(typeof(Product))) {
            _dataGridView.CellDoubleClick += _productDataGridView_CellDoubleClick; ;
         }

         Controls.Add(_dataGridView);
      }

      private void _productDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
         var id = (int)SelectedRow.Cells["ID"].Value;
         ProductDetailRepository productDetailRepository = new();
         var items = productDetailRepository.Select().Where(x => x.ID == id);
         new ListForm<ProductDetail>(items).Show();
      }

      private void _orderDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
         var id = (int)SelectedRow.Cells["ID"].Value;
         OrderDetailRepository orderDetailRepository = new();
         var items = orderDetailRepository.Select().Where(x => x.ID == id);
         new ListForm<OrderDetail>(items).Show();
      }

      private void _purchaseDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
         var id = (int)SelectedRow.Cells["ID"].Value;
         PurchaseDetailRepository purchaseDetailRepository = new();
         var items = purchaseDetailRepository.Select().Where(x => x.ID == id);
         new ListForm<PurchaseDetail>(items).Show();
      }

      public DataGridViewRow SelectedRow => _dataGridView.CurrentRow;

      public void UpdateList() {
         _pagination.UpdateCollection(_repository.Select());
         _bindingSource.DataSource = _pagination.CurrentChunk;
      }

      private void ListForm_Load(object sender, EventArgs e) {
         _bindingSource.DataSource = _pagination.CurrentChunk;
      }

      private void btnNext_Click(object sender, EventArgs e) {
         _bindingSource.DataSource = _pagination.Next();
      }

      private void btnPrevious_Click(object sender, EventArgs e) {
         _bindingSource.DataSource = _pagination.Previous();
      }
   }
}
