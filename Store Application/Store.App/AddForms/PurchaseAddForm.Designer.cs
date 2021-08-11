
namespace Store.App.AddForms {
   partial class PurchaseAddForm {
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
         this.lblProvider = new System.Windows.Forms.Label();
         this.lblRequiredDate = new System.Windows.Forms.Label();
         this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
         this.lblUser = new System.Windows.Forms.Label();
         this.txtUser = new System.Windows.Forms.TextBox();
         this.btnSubmit = new System.Windows.Forms.Button();
         this.txtProviders = new System.Windows.Forms.TextBox();
         this.btnPurchaseDetailsAdd = new System.Windows.Forms.Button();
         this.dgvPurchases = new System.Windows.Forms.DataGridView();
         ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
         this.SuspendLayout();
         // 
         // lblProvider
         // 
         this.lblProvider.AutoSize = true;
         this.lblProvider.Location = new System.Drawing.Point(351, 19);
         this.lblProvider.Name = "lblProvider";
         this.lblProvider.Size = new System.Drawing.Size(64, 20);
         this.lblProvider.TabIndex = 0;
         this.lblProvider.Text = "Provider";
         // 
         // lblRequiredDate
         // 
         this.lblRequiredDate.AutoSize = true;
         this.lblRequiredDate.Location = new System.Drawing.Point(632, 19);
         this.lblRequiredDate.Name = "lblRequiredDate";
         this.lblRequiredDate.Size = new System.Drawing.Size(105, 20);
         this.lblRequiredDate.TabIndex = 0;
         this.lblRequiredDate.Text = "Required Date";
         // 
         // dtpRequiredDate
         // 
         this.dtpRequiredDate.Location = new System.Drawing.Point(632, 52);
         this.dtpRequiredDate.Name = "dtpRequiredDate";
         this.dtpRequiredDate.Size = new System.Drawing.Size(250, 27);
         this.dtpRequiredDate.TabIndex = 2;
         // 
         // lblUser
         // 
         this.lblUser.AutoSize = true;
         this.lblUser.Location = new System.Drawing.Point(6, 15);
         this.lblUser.Name = "lblUser";
         this.lblUser.Size = new System.Drawing.Size(38, 20);
         this.lblUser.TabIndex = 0;
         this.lblUser.Text = "User";
         // 
         // txtUser
         // 
         this.txtUser.Location = new System.Drawing.Point(50, 12);
         this.txtUser.Name = "txtUser";
         this.txtUser.Size = new System.Drawing.Size(154, 27);
         this.txtUser.TabIndex = 4;
         // 
         // btnSubmit
         // 
         this.btnSubmit.Location = new System.Drawing.Point(388, 394);
         this.btnSubmit.Name = "btnSubmit";
         this.btnSubmit.Size = new System.Drawing.Size(106, 29);
         this.btnSubmit.TabIndex = 5;
         this.btnSubmit.Text = "Add";
         this.btnSubmit.UseVisualStyleBackColor = true;
         this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
         // 
         // txtProviders
         // 
         this.txtProviders.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.txtProviders.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
         this.txtProviders.Location = new System.Drawing.Point(351, 52);
         this.txtProviders.Name = "txtProviders";
         this.txtProviders.Size = new System.Drawing.Size(250, 27);
         this.txtProviders.TabIndex = 6;
         // 
         // btnPurchaseDetailsAdd
         // 
         this.btnPurchaseDetailsAdd.Location = new System.Drawing.Point(716, 109);
         this.btnPurchaseDetailsAdd.Name = "btnPurchaseDetailsAdd";
         this.btnPurchaseDetailsAdd.Size = new System.Drawing.Size(166, 29);
         this.btnPurchaseDetailsAdd.TabIndex = 8;
         this.btnPurchaseDetailsAdd.Text = "Add Purchase Details";
         this.btnPurchaseDetailsAdd.UseVisualStyleBackColor = true;
         this.btnPurchaseDetailsAdd.Click += new System.EventHandler(this.btnPurchaseDetailsAdd_Click);
         // 
         // dgvPurchases
         // 
         this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvPurchases.Location = new System.Drawing.Point(12, 156);
         this.dgvPurchases.Name = "dgvPurchases";
         this.dgvPurchases.RowHeadersWidth = 51;
         this.dgvPurchases.RowTemplate.Height = 29;
         this.dgvPurchases.Size = new System.Drawing.Size(870, 203);
         this.dgvPurchases.TabIndex = 9;
         // 
         // PurchaseAddForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(894, 435);
         this.Controls.Add(this.dgvPurchases);
         this.Controls.Add(this.btnPurchaseDetailsAdd);
         this.Controls.Add(this.txtProviders);
         this.Controls.Add(this.btnSubmit);
         this.Controls.Add(this.txtUser);
         this.Controls.Add(this.lblProvider);
         this.Controls.Add(this.lblUser);
         this.Controls.Add(this.lblRequiredDate);
         this.Controls.Add(this.dtpRequiredDate);
         this.Name = "PurchaseAddForm";
         this.Text = "PurchaseAddForm";
         ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblProvider;
      private System.Windows.Forms.Label lblRequiredDate;
      private System.Windows.Forms.DateTimePicker dtpRequiredDate;
      private System.Windows.Forms.Label lblUser;
      private System.Windows.Forms.TextBox txtUser;
      private System.Windows.Forms.Button btnSubmit;
      private System.Windows.Forms.TextBox txtProviders;
      private System.Windows.Forms.Button btnPurchaseDetailsAdd;
      private System.Windows.Forms.DataGridView dgvPurchases;
   }
}