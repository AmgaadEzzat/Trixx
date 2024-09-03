
namespace Trixx_CafeSystem
{
    partial class frmProductView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvgProduct = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(601, 35);
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.Text = "قائمة المنتجات";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Trixx_CafeSystem.Properties.Resources.images;
            this.btnAdd.Location = new System.Drawing.Point(672, 73);
            // 
            // dvgProduct
            // 
            this.dvgProduct.AllowUserToDeleteRows = false;
            this.dvgProduct.BackgroundColor = System.Drawing.Color.White;
            this.dvgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProduct.Location = new System.Drawing.Point(37, 160);
            this.dvgProduct.Name = "dvgProduct";
            this.dvgProduct.ReadOnly = true;
            this.dvgProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dvgProduct.Size = new System.Drawing.Size(690, 278);
            this.dvgProduct.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Brown;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(39, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 33);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dvgProduct);
            this.Name = "frmProductView";
            this.Text = "frmProductView";
            this.Load += new System.EventHandler(this.frmProductView_Load);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dvgProduct, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgProduct;
        private System.Windows.Forms.Button btnClose;
    }
}