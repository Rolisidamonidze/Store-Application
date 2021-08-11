
namespace Store.App.AddForms {
   partial class ProviderAddForm {
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
         this.lblName = new System.Windows.Forms.Label();
         this.txtName = new System.Windows.Forms.TextBox();
         this.lblEmail = new System.Windows.Forms.Label();
         this.txtEmail = new System.Windows.Forms.TextBox();
         this.lblPhone = new System.Windows.Forms.Label();
         this.txtPhone = new System.Windows.Forms.TextBox();
         this.btnConfirm = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(26, 22);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(49, 20);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(101, 19);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(229, 27);
         this.txtName.TabIndex = 1;
         // 
         // lblEmail
         // 
         this.lblEmail.AutoSize = true;
         this.lblEmail.Location = new System.Drawing.Point(26, 59);
         this.lblEmail.Name = "lblEmail";
         this.lblEmail.Size = new System.Drawing.Size(46, 20);
         this.lblEmail.TabIndex = 0;
         this.lblEmail.Text = "Email";
         // 
         // txtEmail
         // 
         this.txtEmail.Location = new System.Drawing.Point(101, 56);
         this.txtEmail.Name = "txtEmail";
         this.txtEmail.Size = new System.Drawing.Size(229, 27);
         this.txtEmail.TabIndex = 1;
         // 
         // lblPhone
         // 
         this.lblPhone.AutoSize = true;
         this.lblPhone.Location = new System.Drawing.Point(26, 98);
         this.lblPhone.Name = "lblPhone";
         this.lblPhone.Size = new System.Drawing.Size(50, 20);
         this.lblPhone.TabIndex = 0;
         this.lblPhone.Text = "Phone";
         // 
         // txtPhone
         // 
         this.txtPhone.Location = new System.Drawing.Point(101, 95);
         this.txtPhone.Name = "txtPhone";
         this.txtPhone.Size = new System.Drawing.Size(229, 27);
         this.txtPhone.TabIndex = 1;
         // 
         // btnConfirm
         // 
         this.btnConfirm.Location = new System.Drawing.Point(138, 164);
         this.btnConfirm.Name = "btnConfirm";
         this.btnConfirm.Size = new System.Drawing.Size(94, 29);
         this.btnConfirm.TabIndex = 2;
         this.btnConfirm.Text = "Add";
         this.btnConfirm.UseVisualStyleBackColor = true;
         this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
         // 
         // ProviderAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(359, 234);
         this.Controls.Add(this.btnConfirm);
         this.Controls.Add(this.txtPhone);
         this.Controls.Add(this.txtEmail);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblPhone);
         this.Controls.Add(this.lblEmail);
         this.Controls.Add(this.lblName);
         this.Name = "ProviderAddForm";
         this.Text = "ProviderAddForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label lblEmail;
      private System.Windows.Forms.TextBox txtEmail;
      private System.Windows.Forms.Label lblPhone;
      private System.Windows.Forms.TextBox txtPhone;
      private System.Windows.Forms.Button btnConfirm;
   }
}