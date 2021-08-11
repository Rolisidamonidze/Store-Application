
namespace Store.App.AddForms {
   partial class PurchaseDetailAddForm {
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
         this.txtQuantity = new System.Windows.Forms.TextBox();
         this.txtUnitPrice = new System.Windows.Forms.TextBox();
         this.lblQuantity = new System.Windows.Forms.Label();
         this.lblExpirationDate = new System.Windows.Forms.Label();
         this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
         this.label1 = new System.Windows.Forms.Label();
         this.lblUnitPrice = new System.Windows.Forms.Label();
         this.btnSubmit = new System.Windows.Forms.Button();
         this.txtProducts = new System.Windows.Forms.TextBox();
         this.dtpStoreDate = new System.Windows.Forms.DateTimePicker();
         this.lblStoreDate = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // txtQuantity
         // 
         this.txtQuantity.Location = new System.Drawing.Point(24, 106);
         this.txtQuantity.Name = "txtQuantity";
         this.txtQuantity.Size = new System.Drawing.Size(113, 27);
         this.txtQuantity.TabIndex = 9;
         // 
         // txtUnitPrice
         // 
         this.txtUnitPrice.Location = new System.Drawing.Point(161, 104);
         this.txtUnitPrice.Name = "txtUnitPrice";
         this.txtUnitPrice.Size = new System.Drawing.Size(108, 27);
         this.txtUnitPrice.TabIndex = 9;
         // 
         // lblQuantity
         // 
         this.lblQuantity.AutoSize = true;
         this.lblQuantity.Location = new System.Drawing.Point(25, 82);
         this.lblQuantity.Name = "lblQuantity";
         this.lblQuantity.Size = new System.Drawing.Size(65, 20);
         this.lblQuantity.TabIndex = 8;
         this.lblQuantity.Text = "Quantity";
         // 
         // lblExpirationDate
         // 
         this.lblExpirationDate.AutoSize = true;
         this.lblExpirationDate.Location = new System.Drawing.Point(311, 13);
         this.lblExpirationDate.Name = "lblExpirationDate";
         this.lblExpirationDate.Size = new System.Drawing.Size(112, 20);
         this.lblExpirationDate.TabIndex = 0;
         this.lblExpirationDate.Text = "Expiration Date";
         // 
         // dtpExpirationDate
         // 
         this.dtpExpirationDate.Location = new System.Drawing.Point(311, 37);
         this.dtpExpirationDate.Name = "dtpExpirationDate";
         this.dtpExpirationDate.Size = new System.Drawing.Size(250, 27);
         this.dtpExpirationDate.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(24, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(66, 20);
         this.label1.TabIndex = 8;
         this.label1.Text = "Products";
         // 
         // lblUnitPrice
         // 
         this.lblUnitPrice.AutoSize = true;
         this.lblUnitPrice.Location = new System.Drawing.Point(161, 82);
         this.lblUnitPrice.Name = "lblUnitPrice";
         this.lblUnitPrice.Size = new System.Drawing.Size(72, 20);
         this.lblUnitPrice.TabIndex = 8;
         this.lblUnitPrice.Text = "Unit Price";
         // 
         // btnSubmit
         // 
         this.btnSubmit.Location = new System.Drawing.Point(239, 177);
         this.btnSubmit.Name = "btnSubmit";
         this.btnSubmit.Size = new System.Drawing.Size(94, 29);
         this.btnSubmit.TabIndex = 10;
         this.btnSubmit.Text = "Add";
         this.btnSubmit.UseVisualStyleBackColor = true;
         this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
         // 
         // txtProducts
         // 
         this.txtProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.txtProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
         this.txtProducts.Location = new System.Drawing.Point(24, 39);
         this.txtProducts.Name = "txtProducts";
         this.txtProducts.Size = new System.Drawing.Size(251, 27);
         this.txtProducts.TabIndex = 11;
         // 
         // dtpStoreDate
         // 
         this.dtpStoreDate.Location = new System.Drawing.Point(311, 104);
         this.dtpStoreDate.Name = "dtpStoreDate";
         this.dtpStoreDate.Size = new System.Drawing.Size(250, 27);
         this.dtpStoreDate.TabIndex = 2;
         // 
         // lblStoreDate
         // 
         this.lblStoreDate.AutoSize = true;
         this.lblStoreDate.Location = new System.Drawing.Point(311, 80);
         this.lblStoreDate.Name = "lblStoreDate";
         this.lblStoreDate.Size = new System.Drawing.Size(80, 20);
         this.lblStoreDate.TabIndex = 0;
         this.lblStoreDate.Text = "Store Date";
         // 
         // PurchaseDetailAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(575, 233);
         this.Controls.Add(this.txtProducts);
         this.Controls.Add(this.btnSubmit);
         this.Controls.Add(this.txtQuantity);
         this.Controls.Add(this.txtUnitPrice);
         this.Controls.Add(this.lblQuantity);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.lblStoreDate);
         this.Controls.Add(this.dtpStoreDate);
         this.Controls.Add(this.lblExpirationDate);
         this.Controls.Add(this.dtpExpirationDate);
         this.Controls.Add(this.lblUnitPrice);
         this.Name = "PurchaseDetailAddForm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.Text = "PurchaseDetailAddForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtQuantity;
      private System.Windows.Forms.TextBox txtUnitPrice;
      private System.Windows.Forms.Label lblQuantity;
      private System.Windows.Forms.Label lblExpirationDate;
      private System.Windows.Forms.DateTimePicker dtpExpirationDate;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label lblUnitPrice;
      private System.Windows.Forms.Button btnSubmit;
      private System.Windows.Forms.TextBox txtProducts;
      private System.Windows.Forms.DateTimePicker dtpStoreDate;
      private System.Windows.Forms.Label lblStoreDate;
   }
}