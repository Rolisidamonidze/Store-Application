
using Store.Models;
using System.Windows.Forms;

namespace Store.App {
   partial class ListForm<TModel> : Form where TModel : new() {
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
         this.btnPrevious = new System.Windows.Forms.Button();
         this.btnNext = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnPrevious
         // 
         this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnPrevious.Location = new System.Drawing.Point(12, 671);
         this.btnPrevious.Name = "btnPrevious";
         this.btnPrevious.Size = new System.Drawing.Size(94, 29);
         this.btnPrevious.TabIndex = 1;
         this.btnPrevious.Text = "Previous";
         this.btnPrevious.UseVisualStyleBackColor = true;
         this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
         // 
         // btnNext
         // 
         this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnNext.Location = new System.Drawing.Point(663, 671);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(94, 29);
         this.btnNext.TabIndex = 1;
         this.btnNext.Text = "Next";
         this.btnNext.UseVisualStyleBackColor = true;
         this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
         // 
         // ListForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(769, 712);
         this.Controls.Add(this.btnNext);
         this.Controls.Add(this.btnPrevious);
         this.Name = "ListForm";
         this.Text = "ListForm";
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.Button btnPrevious;
      private System.Windows.Forms.Button btnNext;
   }
}