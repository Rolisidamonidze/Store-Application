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

namespace Store.App {
   public partial class LoginForm : Form {
      public event Action OnAuthentication;

      UserRepository _userRepository;
      public LoginForm() {
         InitializeComponent();
         _userRepository = new UserRepository();
         Enabled = true;
         Activate();
         this.CenterToParent();
         txtPassword.PasswordChar = '*';
         lblError.Visible = false;
         this.Text = "Login";
         txtUsername.TabIndex = 0;
         txtPassword.TabIndex = 1;
         btnLogin.TabIndex = 2;
#if DEBUG
         txtUsername.Text = "sergi";
         txtPassword.Text = "sergi";
#endif
      }

      private void btnLogin_Click(object sender, EventArgs e) {
         int userId = (int)_userRepository.Authenticate(txtUsername.Text, txtPassword.Text);
         if (userId != -1) {
            LocalStorage.CurrentUser = new User { ID = userId, Username = txtUsername.Text };
            this.Close();
            OnAuthentication();
         } else {
            lblError.Visible = true;
         }
      }

      private void txtUsername_Enter(object sender, EventArgs e) {
         lblError.Visible = false;
      }

      private void txtPassword_Enter(object sender, EventArgs e) {
         lblError.Visible = false;
      }
   }
}
