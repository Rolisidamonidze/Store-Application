using Store.App.AddForms;
using Store.App.EditForms;
using Store.App.Extensions;
using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Store.App {
   public partial class MainForm : Form {
      UserRepository _userRepository;

      public MainForm() {
         InitializeComponent();
         _userRepository = new UserRepository();
         LocalStorage.MainForm = this;
         IsMdiContainer = true;
         WindowState = FormWindowState.Maximized;
         HideMenuItems();
         var loginForm = new LoginForm() { Owner = this };
         loginForm.Show();
         loginForm.OnAuthentication += DisplayUserControls;
      }

      #region Lists

      private void mnuEmployeesList_Click(object sender, EventArgs e) {
         OpenChildListForm<Employee>();
      }

      private void mnuUsersList_Click(object sender, EventArgs e) {
         OpenChildListForm<User>();
      }

      private void mnuProvidersList_Click(object sender, EventArgs e) {
         OpenChildListForm<Provider>();
      }

      private void mnuOrdersList_Click(object sender, EventArgs e) {
         OpenChildListForm<Order>();
      }

      private void mnuPurchasesList_Click(object sender, EventArgs e) {
         OpenChildListForm<Purchase>();
      }

      private void mnuProductsList_Click(object sender, EventArgs e) {
         OpenChildListForm<Product>();
      }

      private void mnuCategoryList_Click(object sender, EventArgs e) {
         OpenChildListForm<Category>();
      }

      private void OpenChildListForm<TModel>() where TModel : new() {
         Form mdiChildListForm = this.GetMdiChildForm(typeof(TModel).Name + "ListForm");
         if (mdiChildListForm == null) {
            var modelList = new ListForm<TModel>() { MdiParent = this };
            modelList.Show();
         } else {
            ((ListForm<TModel>)mdiChildListForm).UpdateList();
         }
      }

      #endregion

      #region Add

      private void mnuEmployeeAdd_Click(object sender, EventArgs e) {
         new EmployeeAddForm() { MdiParent = this }.Show();
      }

      private void mnuUserAdd_Click(object sender, EventArgs e) {
         new UserAddForm() { MdiParent = this }.Show();
      }

      private void mnuOrderAdd_Click(object sender, EventArgs e) {
         new OrderAddForm() { MdiParent = this }.Show();
      }

      private void mnuProviderAdd_Click(object sender, EventArgs e) {
         new ProviderAddForm() { MdiParent = this }.Show();
      }

      private void mnuPurchaseAdd_Click(object sender, EventArgs e) {
         new PurchaseAddForm() { MdiParent = this }.Show();
      }

      private void mnuProductsAdd_Click(object sender, EventArgs e) {
         new ProductAddForm() { MdiParent = this }.Show();
      }
      private void mnuCategoryAdd_Click(object sender, EventArgs e) {
         new CategoryAddForm() { MdiParent = this }.Show();
      }

      #endregion

      #region Edit
      private void mnuEmployeeEdit_Click(object sender, EventArgs e) {
         var employee = GetModelToEdit<Employee>();
         if (employee != null) {
            new EmployeeEditForm(employee) { MdiParent = this }.Show();
         }
      }

      private void mnuUserEdit_Click(object sender, EventArgs e) {
         var user = GetModelToEdit<User>();
         if (user != null) {
            new UserEditForm(user) { MdiParent = this }.Show();
         }
      }

      private void mnuProviderEdit_Click(object sender, EventArgs e) {
         var provider = GetModelToEdit<Provider>();
         if (provider != null) {
            new ProviderEditForm(provider) { MdiParent = this }.Show();
         }
      }

      private void mnuProductsEdit_Click(object sender, EventArgs e) {
         var product = GetModelToEdit<Product>();
         if (product != null) {
            new ProductEditForm(product) { MdiParent = this }.Show();
         }
      }

      private TModel GetModelToEdit<TModel>() where TModel : class, new() {
         if (IsListFormOpen<TModel>()) {

            if (!IsActiveForm<TModel>()) {
               ActivateChildListForm<TModel>();
            }

            TModel model = new TModel();
            DataGridViewRow selectedRow = ((ListForm<TModel>)ActiveMdiChild)._dataGridView.SelectedRows[0];
            foreach (DataGridViewCell cell in selectedRow.Cells) {
               var property = model.GetType().GetProperty(cell.OwningColumn.Name);
               property.SetValue(model, cell.Value);
            }
            return model;
         } else {
            MessageBox.Show($"{typeof(TModel).Name} is not selected");
         }
         return null;
      }
      #endregion

      #region Delete
      private void OpenDeleteDialog<TModel>() where TModel : new() {
         if (IsListFormOpen<TModel>()) {

            if (!IsActiveForm<TModel>()) {
               ActivateChildListForm<TModel>();
            }

            DataGridViewRow selectedRow = ((ListForm<TModel>)ActiveMdiChild)._dataGridView.SelectedRows[0];
            DialogResult dialogResult = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes) {
               var id = selectedRow.Cells["ID"].Value;
               new BaseRepository<TModel>().Delete((int)id, LocalStorage.CurrentUser.ID);
               ((ListForm<TModel>)ActiveMdiChild).UpdateList();
            }
         } else {
            MessageBox.Show($"{typeof(TModel).Name} is not selected");
         }
      }
      private void mnuEmployeeDelete_Click(object sender, EventArgs e) {
         OpenDeleteDialog<Employee>();
      }

      private void mnuUserDelete_Click(object sender, EventArgs e) {
         OpenDeleteDialog<User>();
      }

      private void mnuProviderDelete_Click(object sender, EventArgs e) {
         OpenDeleteDialog<Provider>();
      }

      private void mnuProductsDelete_Click(object sender, EventArgs e) {
         OpenDeleteDialog<Product>();
      }

      private void mnuUserDelete_Click_1(object sender, EventArgs e) {
         OpenDeleteDialog<User>();
      }

      private void mnuProviderDelete_Click_1(object sender, EventArgs e) {
         OpenDeleteDialog<Provider>();
      }

      private void mnuCategoryDelete_Click(object sender, EventArgs e) {
         OpenDeleteDialog<Category>();
      }

      private void mnuProductDetailsDelete_Click(object sender, EventArgs e) {
         OpenDeleteDialog<ProductDetail>();
      }

      #endregion

      #region Permissions

      private void HideMenuItems() {
         foreach (ToolStripItem item in _menuStrip.Items) {
            item.Visible = false;
         }
         foreach (Control control in this.Controls) {
            control.Visible = false;
         }
      }

      private void SaveUserPermissionsInLocalStorage() {
         DataTable permissionsTable = _userRepository.GetUserPermissions(LocalStorage.CurrentUser.ID);
         LocalStorage.Permissions = new List<int>();
         foreach (DataRow row in permissionsTable.Rows) {
            LocalStorage.Permissions.Add((short)row["PermissionCode"]);
         }
      }

      private void CheckPermissions(ToolStripDropDownItem item) {
         if (item.HasDropDownItems) {
            foreach (ToolStripItem child in item.DropDownItems) {
               if (child is ToolStripDropDownItem) {
                  CheckPermissions(child as ToolStripDropDownItem);
               }
            }
         };

         if (item.HasPermission()) {
            item.Visible = true;
         }
      }

      private void CheckPermissions(Control control) {
         if (control.HasChildren) {
            foreach (Control child in control.Controls) {
               CheckPermissions(child);
            }
         };

         if (control.HasPermission()) {
            control.Visible = true;
         }
      }

      private void DisplayUserControls() {
         SaveUserPermissionsInLocalStorage();
         foreach (ToolStripItem item in _menuStrip.Items) {
            CheckPermissions((ToolStripDropDownItem)item);
         }
         foreach (Control control in this.Controls) {
            CheckPermissions(control);
         }
      }

      #endregion

      #region Helper Methods
      public Form ActivateForm(string name) {
         foreach (Form child in this.MdiChildren) {
            if (child.Name == name) {
               child.Activate();
               return child;
            }
         }

         MessageBox.Show($"{name} is not open");
         return default;
      }

      public bool IsListFormOpen<TModel>() {
         foreach (Form childForm in this.MdiChildren) {
            if (childForm.Name == typeof(TModel).Name + "ListForm") {
               return true;
            }
         }
         return false;
      }

      private bool IsActiveForm<TModel>() {
         if (this.ActiveMdiChild.Name == typeof(TModel).Name) {
            return true;
         }
         return false;
      }

      private void ActivateChildListForm<TModel>() {
         foreach (var child in this.MdiChildren) {
            if (child.Name == typeof(TModel).Name + "ListForm") {
               child.Activate();
               break;
            }
         }
      }

      #endregion

      #region Window

      private void mnuCascade_Click(object sender, EventArgs e) {
         this.LayoutMdi(MdiLayout.Cascade);
      }

      private void mnuVertical_Click(object sender, EventArgs e) {
         this.LayoutMdi(MdiLayout.TileVertical);
      }

      private void mnuHorizontal_Click(object sender, EventArgs e) {
         this.LayoutMdi(MdiLayout.TileHorizontal);
      }

      private void mnuCloseAll_Click(object sender, EventArgs e) {
         while (this.MdiChildren.Length > 0) {
            this.MdiChildren[0].Close();
         }
      }

      #endregion

      #region About

      private void mnuAbout_Click(object sender, EventArgs e) {
         new AboutForm().Show();
      }

      #endregion

      #region Logout
      private void mnuLogout_Click(object sender, EventArgs e) {
         Application.Restart();
      }

      #endregion
   }
}
