
namespace Store.App.AddForms {
   partial class CategoryAddForm {
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
         this.lblDescription = new System.Windows.Forms.Label();
         this.txtDescription = new System.Windows.Forms.RichTextBox();
         this.btnConfirm = new System.Windows.Forms.Button();
         this.txtName = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(12, 23);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(49, 20);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // lblDescription
         // 
         this.lblDescription.AutoSize = true;
         this.lblDescription.Location = new System.Drawing.Point(12, 66);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(85, 20);
         this.lblDescription.TabIndex = 0;
         this.lblDescription.Text = "Description";
         // 
         // txtDescription
         // 
         this.txtDescription.Location = new System.Drawing.Point(137, 63);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(294, 77);
         this.txtDescription.TabIndex = 2;
         this.txtDescription.Text = "";
         // 
         // btnConfirm
         // 
         this.btnConfirm.Location = new System.Drawing.Point(177, 189);
         this.btnConfirm.Name = "btnConfirm";
         this.btnConfirm.Size = new System.Drawing.Size(94, 29);
         this.btnConfirm.TabIndex = 3;
         this.btnConfirm.Text = "Add";
         this.btnConfirm.UseVisualStyleBackColor = true;
         this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(137, 20);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(294, 27);
         this.txtName.TabIndex = 4;
         // 
         // CategoryAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(452, 257);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.btnConfirm);
         this.Controls.Add(this.txtDescription);
         this.Controls.Add(this.lblDescription);
         this.Controls.Add(this.lblName);
         this.Name = "CategoryAddForm";
         this.Text = "CategoryAddForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.Label lblDescription;
      private System.Windows.Forms.RichTextBox txtDescription;
      private System.Windows.Forms.Button btnConfirm;
      private System.Windows.Forms.TextBox txtName;
   }
}