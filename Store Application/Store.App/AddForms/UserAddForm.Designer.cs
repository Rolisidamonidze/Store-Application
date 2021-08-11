
namespace Store.App.AddForms {
   partial class UserAddForm {
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
         this.lblEmployees = new System.Windows.Forms.Label();
         this.cmbxEmployees = new System.Windows.Forms.ComboBox();
         this.lblUsername = new System.Windows.Forms.Label();
         this.txtUsername = new System.Windows.Forms.TextBox();
         this.lblPassword = new System.Windows.Forms.Label();
         this.txtPassword = new System.Windows.Forms.TextBox();
         this.btnSubmit = new System.Windows.Forms.Button();
         this.lblGroup = new System.Windows.Forms.Label();
         this.cmbxGroup = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // lblEmployees
         // 
         this.lblEmployees.AutoSize = true;
         this.lblEmployees.Location = new System.Drawing.Point(15, 24);
         this.lblEmployees.Name = "lblEmployees";
         this.lblEmployees.Size = new System.Drawing.Size(75, 20);
         this.lblEmployees.TabIndex = 0;
         this.lblEmployees.Text = "Employee";
         // 
         // cmbxEmployees
         // 
         this.cmbxEmployees.FormattingEnabled = true;
         this.cmbxEmployees.Location = new System.Drawing.Point(122, 21);
         this.cmbxEmployees.Name = "cmbxEmployees";
         this.cmbxEmployees.Size = new System.Drawing.Size(251, 28);
         this.cmbxEmployees.TabIndex = 1;
         // 
         // lblUsername
         // 
         this.lblUsername.AutoSize = true;
         this.lblUsername.Location = new System.Drawing.Point(15, 114);
         this.lblUsername.Name = "lblUsername";
         this.lblUsername.Size = new System.Drawing.Size(75, 20);
         this.lblUsername.TabIndex = 0;
         this.lblUsername.Text = "Username";
         // 
         // txtUsername
         // 
         this.txtUsername.Location = new System.Drawing.Point(122, 111);
         this.txtUsername.Name = "txtUsername";
         this.txtUsername.Size = new System.Drawing.Size(251, 27);
         this.txtUsername.TabIndex = 2;
         // 
         // lblPassword
         // 
         this.lblPassword.AutoSize = true;
         this.lblPassword.Location = new System.Drawing.Point(15, 161);
         this.lblPassword.Name = "lblPassword";
         this.lblPassword.Size = new System.Drawing.Size(70, 20);
         this.lblPassword.TabIndex = 0;
         this.lblPassword.Text = "Password";
         // 
         // txtPassword
         // 
         this.txtPassword.Location = new System.Drawing.Point(122, 158);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(251, 27);
         this.txtPassword.TabIndex = 2;
         // 
         // btnSubmit
         // 
         this.btnSubmit.Location = new System.Drawing.Point(153, 226);
         this.btnSubmit.Name = "btnSubmit";
         this.btnSubmit.Size = new System.Drawing.Size(94, 29);
         this.btnSubmit.TabIndex = 3;
         this.btnSubmit.Text = "Add";
         this.btnSubmit.UseVisualStyleBackColor = true;
         this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
         // 
         // lblGroup
         // 
         this.lblGroup.AutoSize = true;
         this.lblGroup.Location = new System.Drawing.Point(15, 68);
         this.lblGroup.Name = "lblGroup";
         this.lblGroup.Size = new System.Drawing.Size(50, 20);
         this.lblGroup.TabIndex = 0;
         this.lblGroup.Text = "Group";
         // 
         // cmbxGroup
         // 
         this.cmbxGroup.FormattingEnabled = true;
         this.cmbxGroup.Location = new System.Drawing.Point(122, 65);
         this.cmbxGroup.Name = "cmbxGroup";
         this.cmbxGroup.Size = new System.Drawing.Size(251, 28);
         this.cmbxGroup.TabIndex = 1;
         // 
         // UserAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(390, 293);
         this.Controls.Add(this.btnSubmit);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.txtUsername);
         this.Controls.Add(this.lblPassword);
         this.Controls.Add(this.cmbxGroup);
         this.Controls.Add(this.cmbxEmployees);
         this.Controls.Add(this.lblUsername);
         this.Controls.Add(this.lblGroup);
         this.Controls.Add(this.lblEmployees);
         this.Name = "UserAddForm";
         this.Text = "UserAddForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblEmployees;
      private System.Windows.Forms.ComboBox cmbxEmployees;
      private System.Windows.Forms.Label lblUsername;
      private System.Windows.Forms.TextBox txtUsername;
      private System.Windows.Forms.Label lblPassword;
      private System.Windows.Forms.TextBox txtPassword;
      private System.Windows.Forms.Button btnSubmit;
      private System.Windows.Forms.Label lblGroup;
      private System.Windows.Forms.ComboBox cmbxGroup;
   }
}