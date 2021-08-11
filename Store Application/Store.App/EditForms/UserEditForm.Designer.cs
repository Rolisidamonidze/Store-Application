
namespace Store.App.EditForms {
   partial class UserEditForm {
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
         this.lblUsername = new System.Windows.Forms.Label();
         this.txtUsername = new System.Windows.Forms.TextBox();
         this.btnConfirm = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lblUsername
         // 
         this.lblUsername.AutoSize = true;
         this.lblUsername.Location = new System.Drawing.Point(12, 26);
         this.lblUsername.Name = "lblUsername";
         this.lblUsername.Size = new System.Drawing.Size(75, 20);
         this.lblUsername.TabIndex = 0;
         this.lblUsername.Text = "Username";
         // 
         // txtUsername
         // 
         this.txtUsername.Location = new System.Drawing.Point(108, 23);
         this.txtUsername.Name = "txtUsername";
         this.txtUsername.Size = new System.Drawing.Size(214, 27);
         this.txtUsername.TabIndex = 1;
         // 
         // btnConfirm
         // 
         this.btnConfirm.Location = new System.Drawing.Point(122, 90);
         this.btnConfirm.Name = "btnConfirm";
         this.btnConfirm.Size = new System.Drawing.Size(94, 29);
         this.btnConfirm.TabIndex = 2;
         this.btnConfirm.Text = "Edit";
         this.btnConfirm.UseVisualStyleBackColor = true;
         this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
         // 
         // EditUserForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(339, 151);
         this.Controls.Add(this.btnConfirm);
         this.Controls.Add(this.txtUsername);
         this.Controls.Add(this.lblUsername);
         this.Name = "EditUserForm";
         this.Text = "Edit User";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblUsername;
      private System.Windows.Forms.TextBox txtUsername;
      private System.Windows.Forms.Button btnConfirm;
   }
}