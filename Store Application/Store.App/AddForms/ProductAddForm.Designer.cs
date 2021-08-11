
namespace Store.App.AddForms {
   partial class ProductAddForm {
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
         this.txtCode = new System.Windows.Forms.TextBox();
         this.cmbxCategory = new System.Windows.Forms.ComboBox();
         this.txtName = new System.Windows.Forms.TextBox();
         this.lblUnitPrice = new System.Windows.Forms.Label();
         this.btnAddProduct = new System.Windows.Forms.Button();
         this.txtUnitPrice = new System.Windows.Forms.TextBox();
         this.lblName = new System.Windows.Forms.Label();
         this.lblCode = new System.Windows.Forms.Label();
         this.lblProductCategory = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // txtCode
         // 
         this.txtCode.Location = new System.Drawing.Point(112, 168);
         this.txtCode.Name = "txtCode";
         this.txtCode.Size = new System.Drawing.Size(240, 27);
         this.txtCode.TabIndex = 2;
         // 
         // cmbxCategory
         // 
         this.cmbxCategory.FormattingEnabled = true;
         this.cmbxCategory.Location = new System.Drawing.Point(113, 26);
         this.cmbxCategory.Name = "cmbxCategory";
         this.cmbxCategory.Size = new System.Drawing.Size(239, 28);
         this.cmbxCategory.TabIndex = 1;
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(112, 121);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(240, 27);
         this.txtName.TabIndex = 2;
         // 
         // lblUnitPrice
         // 
         this.lblUnitPrice.AutoSize = true;
         this.lblUnitPrice.Location = new System.Drawing.Point(12, 77);
         this.lblUnitPrice.Name = "lblUnitPrice";
         this.lblUnitPrice.Size = new System.Drawing.Size(72, 20);
         this.lblUnitPrice.TabIndex = 0;
         this.lblUnitPrice.Text = "Unit Price";
         // 
         // btnAddProduct
         // 
         this.btnAddProduct.Location = new System.Drawing.Point(148, 227);
         this.btnAddProduct.Name = "btnAddProduct";
         this.btnAddProduct.Size = new System.Drawing.Size(83, 33);
         this.btnAddProduct.TabIndex = 3;
         this.btnAddProduct.Text = "Add";
         this.btnAddProduct.UseVisualStyleBackColor = true;
         this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
         // 
         // txtUnitPrice
         // 
         this.txtUnitPrice.Location = new System.Drawing.Point(113, 74);
         this.txtUnitPrice.Name = "txtUnitPrice";
         this.txtUnitPrice.Size = new System.Drawing.Size(239, 27);
         this.txtUnitPrice.TabIndex = 2;
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(12, 124);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(49, 20);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // lblCode
         // 
         this.lblCode.AutoSize = true;
         this.lblCode.Location = new System.Drawing.Point(12, 171);
         this.lblCode.Name = "lblCode";
         this.lblCode.Size = new System.Drawing.Size(44, 20);
         this.lblCode.TabIndex = 0;
         this.lblCode.Text = "Code";
         // 
         // lblProductCategory
         // 
         this.lblProductCategory.AutoSize = true;
         this.lblProductCategory.Location = new System.Drawing.Point(12, 29);
         this.lblProductCategory.Name = "lblProductCategory";
         this.lblProductCategory.Size = new System.Drawing.Size(69, 20);
         this.lblProductCategory.TabIndex = 0;
         this.lblProductCategory.Text = "Category";
         // 
         // ProductAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(368, 289);
         this.Controls.Add(this.lblProductCategory);
         this.Controls.Add(this.lblCode);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.txtCode);
         this.Controls.Add(this.txtUnitPrice);
         this.Controls.Add(this.cmbxCategory);
         this.Controls.Add(this.btnAddProduct);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblUnitPrice);
         this.Name = "ProductAddForm";
         this.Text = "ProductAddForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtCode;
      private System.Windows.Forms.ComboBox cmbxCategory;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label lblUnitPrice;
      private System.Windows.Forms.Button btnAddProduct;
      private System.Windows.Forms.TextBox txtUnitPrice;
      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.Label lblCode;
      private System.Windows.Forms.Label lblProductCategory;
   }
}