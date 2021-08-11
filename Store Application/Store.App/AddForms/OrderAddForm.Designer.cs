
namespace Store.App.AddForms {
   partial class OrderAddForm {
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
         this.btnConfirm = new System.Windows.Forms.Button();
         this.cbxDiscount = new System.Windows.Forms.CheckBox();
         this.txtDiscount = new System.Windows.Forms.TextBox();
         this.txtQuantity = new System.Windows.Forms.TextBox();
         this.txtProducts = new System.Windows.Forms.TextBox();
         this.txtUnitPrice = new System.Windows.Forms.TextBox();
         this.lblQuantity = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.lblUnitPrice = new System.Windows.Forms.Label();
         this.btnAddToList = new System.Windows.Forms.Button();
         this.txtUser = new System.Windows.Forms.TextBox();
         this.lblUser = new System.Windows.Forms.Label();
         this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
         ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
         this.SuspendLayout();
         // 
         // btnConfirm
         // 
         this.btnConfirm.Location = new System.Drawing.Point(302, 583);
         this.btnConfirm.Name = "btnConfirm";
         this.btnConfirm.Size = new System.Drawing.Size(94, 29);
         this.btnConfirm.TabIndex = 3;
         this.btnConfirm.Text = "Add";
         this.btnConfirm.UseVisualStyleBackColor = true;
         this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
         // 
         // cbxDiscount
         // 
         this.cbxDiscount.AutoSize = true;
         this.cbxDiscount.Location = new System.Drawing.Point(190, 209);
         this.cbxDiscount.Name = "cbxDiscount";
         this.cbxDiscount.Size = new System.Drawing.Size(89, 24);
         this.cbxDiscount.TabIndex = 10;
         this.cbxDiscount.Text = "Discount";
         this.cbxDiscount.UseVisualStyleBackColor = true;
         // 
         // txtDiscount
         // 
         this.txtDiscount.Location = new System.Drawing.Point(302, 207);
         this.txtDiscount.Name = "txtDiscount";
         this.txtDiscount.Size = new System.Drawing.Size(250, 27);
         this.txtDiscount.TabIndex = 9;
         // 
         // txtQuantity
         // 
         this.txtQuantity.Location = new System.Drawing.Point(302, 163);
         this.txtQuantity.Name = "txtQuantity";
         this.txtQuantity.Size = new System.Drawing.Size(250, 27);
         this.txtQuantity.TabIndex = 9;
         // 
         // txtProducts
         // 
         this.txtProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.txtProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
         this.txtProducts.Location = new System.Drawing.Point(302, 76);
         this.txtProducts.Name = "txtProducts";
         this.txtProducts.Size = new System.Drawing.Size(250, 27);
         this.txtProducts.TabIndex = 9;
         // 
         // txtUnitPrice
         // 
         this.txtUnitPrice.Location = new System.Drawing.Point(302, 120);
         this.txtUnitPrice.Name = "txtUnitPrice";
         this.txtUnitPrice.Size = new System.Drawing.Size(250, 27);
         this.txtUnitPrice.TabIndex = 9;
         // 
         // lblQuantity
         // 
         this.lblQuantity.AutoSize = true;
         this.lblQuantity.Location = new System.Drawing.Point(214, 166);
         this.lblQuantity.Name = "lblQuantity";
         this.lblQuantity.Size = new System.Drawing.Size(65, 20);
         this.lblQuantity.TabIndex = 8;
         this.lblQuantity.Text = "Quantity";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(213, 79);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(66, 20);
         this.label1.TabIndex = 8;
         this.label1.Text = "Products";
         // 
         // lblUnitPrice
         // 
         this.lblUnitPrice.AutoSize = true;
         this.lblUnitPrice.Location = new System.Drawing.Point(207, 123);
         this.lblUnitPrice.Name = "lblUnitPrice";
         this.lblUnitPrice.Size = new System.Drawing.Size(72, 20);
         this.lblUnitPrice.TabIndex = 8;
         this.lblUnitPrice.Text = "Unit Price";
         // 
         // btnAddToList
         // 
         this.btnAddToList.Location = new System.Drawing.Point(302, 258);
         this.btnAddToList.Name = "btnAddToList";
         this.btnAddToList.Size = new System.Drawing.Size(94, 35);
         this.btnAddToList.TabIndex = 5;
         this.btnAddToList.Text = "Add To List";
         this.btnAddToList.UseVisualStyleBackColor = true;
         this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
         // 
         // txtUser
         // 
         this.txtUser.Location = new System.Drawing.Point(302, 31);
         this.txtUser.Name = "txtUser";
         this.txtUser.Size = new System.Drawing.Size(250, 27);
         this.txtUser.TabIndex = 4;
         // 
         // lblUser
         // 
         this.lblUser.AutoSize = true;
         this.lblUser.Location = new System.Drawing.Point(241, 34);
         this.lblUser.Name = "lblUser";
         this.lblUser.Size = new System.Drawing.Size(38, 20);
         this.lblUser.TabIndex = 0;
         this.lblUser.Text = "User";
         // 
         // dgvOrderDetails
         // 
         this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvOrderDetails.Location = new System.Drawing.Point(12, 345);
         this.dgvOrderDetails.Name = "dgvOrderDetails";
         this.dgvOrderDetails.RowHeadersWidth = 51;
         this.dgvOrderDetails.RowTemplate.Height = 29;
         this.dgvOrderDetails.Size = new System.Drawing.Size(708, 185);
         this.dgvOrderDetails.TabIndex = 12;
         // 
         // OrderAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(732, 651);
         this.Controls.Add(this.cbxDiscount);
         this.Controls.Add(this.txtUser);
         this.Controls.Add(this.txtDiscount);
         this.Controls.Add(this.dgvOrderDetails);
         this.Controls.Add(this.txtQuantity);
         this.Controls.Add(this.lblUser);
         this.Controls.Add(this.txtProducts);
         this.Controls.Add(this.txtUnitPrice);
         this.Controls.Add(this.lblQuantity);
         this.Controls.Add(this.btnConfirm);
         this.Controls.Add(this.btnAddToList);
         this.Controls.Add(this.lblUnitPrice);
         this.Controls.Add(this.label1);
         this.Name = "OrderAddForm";
         this.Text = "OrderAddForm";
         ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnConfirm;
      private System.Windows.Forms.TextBox txtQuantity;
      private System.Windows.Forms.TextBox txtUnitPrice;
      private System.Windows.Forms.Label lblQuantity;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label lblUnitPrice;
      private System.Windows.Forms.Button btnAddToList;
      private System.Windows.Forms.TextBox txtUser;
      private System.Windows.Forms.Label lblUser;
      private System.Windows.Forms.DataGridView dgvOrderDetails;
      private System.Windows.Forms.TextBox txtProducts;
      private System.Windows.Forms.CheckBox cbxDiscount;
      private System.Windows.Forms.TextBox txtDiscount;
   }
}