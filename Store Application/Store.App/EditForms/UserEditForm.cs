using Store.Models;
using Store.Repositories;
using System;
using Store.App.Extensions;
using System.Windows.Forms;

namespace Store.App.EditForms {
   public partial class UserEditForm : Form {
      UserRepository _userRepository;
      User _user;
      public UserEditForm(User user) {
         InitializeComponent();
         _user = user;
         _userRepository = new UserRepository();

         FillFields();
      }

      private void FillFields() {
         txtUsername.Text = _user.Username;
      }

      private void btnConfirm_Click(object sender, EventArgs e) {
         User userToUpdate = new User
         {
            ID = _user.ID,
            Username = txtUsername.Text,
         };
         try {
            _userRepository.Update(userToUpdate, LocalStorage.CurrentUser.ID);
            this.Close();
         } catch (Exception err) {
            MessageBox.Show(err.Message);
         }
      }
   }
}
