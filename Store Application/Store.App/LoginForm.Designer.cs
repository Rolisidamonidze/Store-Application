
namespace Store.App {
   partial class LoginForm {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.txtUsername = new System.Windows.Forms.TextBox();
         this.txtPassword = new System.Windows.Forms.TextBox();
         this.btnLogin = new System.Windows.Forms.Button();
         this.lblError = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 25);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(75, 20);
         this.label2.TabIndex = 0;
         this.label2.Text = "Username";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 73);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(70, 20);
         this.label1.TabIndex = 0;
         this.label1.Text = "Password";
         // 
         // txtUsername
         // 
         this.txtUsername.Location = new System.Drawing.Point(111, 18);
         this.txtUsername.Name = "txtUsername";
         this.txtUsername.Size = new System.Drawing.Size(190, 27);
         this.txtUsername.TabIndex = 1;
         this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
         // 
         // txtPassword
         // 
         this.txtPassword.Location = new System.Drawing.Point(111, 73);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(190, 27);
         this.txtPassword.TabIndex = 1;
         this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
         // 
         // btnLogin
         // 
         this.btnLogin.Location = new System.Drawing.Point(207, 118);
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Size = new System.Drawing.Size(94, 29);
         this.btnLogin.TabIndex = 2;
         this.btnLogin.Text = "Login";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
         // 
         // lblError
         // 
         this.lblError.AutoSize = true;
         this.lblError.ForeColor = System.Drawing.Color.Red;
         this.lblError.Location = new System.Drawing.Point(43, 161);
         this.lblError.Name = "lblError";
         this.lblError.Size = new System.Drawing.Size(240, 20);
         this.lblError.TabIndex = 3;
         this.lblError.Text = "Username or password is incorrect!";
         // 
         // LoginForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(320, 206);
         this.Controls.Add(this.lblError);
         this.Controls.Add(this.btnLogin);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.txtUsername);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.label2);
         this.Name = "LoginForm";
         this.Text = "LoginForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtUsername;
      private System.Windows.Forms.TextBox txtPassword;
      private System.Windows.Forms.Button btnLogin;
      private System.Windows.Forms.Label lblError;
   }
}