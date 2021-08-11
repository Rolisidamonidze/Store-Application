using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Store.App.Extensions;

namespace Store.App.AddForms {
   public partial class UserAddForm : Form {
      EmployeeRepository _employeeRepository;
      GroupRepository _groupRepository;
      UserRepository _userRepository;

      public UserAddForm() {
         InitializeComponent();

         this.MdiParent = LocalStorage.MainForm;

         _employeeRepository = new();
         _groupRepository = new();
         _userRepository = new();
         FillComboBoxes();

         txtPassword.PasswordChar = '*';

//#if DEBUG
//         txtUsername.Text = "madona";
//         txtPassword.Text = "madona123";
//#endif
      }

      private void FillComboBoxes() {
         foreach (Employee employee in _employeeRepository.Select()) {
            cmbxEmployees.Items.Add(employee);
         }
         foreach (Group group in _groupRepository.Select()) {
            cmbxGroup.Items.Add(group);
         }
      }

      private void btnSubmit_Click(object sender, EventArgs e) {
         var userId = ((Employee)cmbxEmployees.SelectedItem).ID;
         var groupId = ((Group)cmbxGroup.SelectedItem).ID;
         User user = new()
         {
            ID = userId,
            Username = txtUsername.Text,
            Password = txtPassword.Text
         };

         try {
            _userRepository.BeginTransaction();
            _userRepository.Insert(user, LocalStorage.CurrentUser.ID);
            _userRepository.InsertUserGroup(userId, groupId, LocalStorage.CurrentUser.ID);
            _userRepository.CommitTransaction();

            this.Close();
         } catch (Exception ex) {
            _userRepository.RollbackTransaction();
            MessageBox.Show(ex.Message);
         }
      }
   }
}
