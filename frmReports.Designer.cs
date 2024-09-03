namespace Trixx_CafeSystem
{
    partial class frmReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaleByCtg = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(633, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "التقارير";
            // 
            // btnSaleByCtg
            // 
            this.btnSaleByCtg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnSaleByCtg.ForeColor = System.Drawing.Color.White;
            this.btnSaleByCtg.Image = global::Trixx_CafeSystem.Properties.Resources.newdownload2;
            this.btnSaleByCtg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaleByCtg.Location = new System.Drawing.Point(496, 88);
            this.btnSaleByCtg.Name = "btnSaleByCtg";
            this.btnSaleByCtg.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnSaleByCtg.Size = new System.Drawing.Size(223, 85);
            this.btnSaleByCtg.TabIndex = 3;
            this.btnSaleByCtg.Text = "البيع حسب الفئة";
            this.btnSaleByCtg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleByCtg.UseVisualStyleBackColor = false;
            this.btnSaleByCtg.Click += new System.EventHandler(this.btnSaleByCtg_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(12, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Trixx_CafeSystem.Properties.Resources.newdownload2;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(239, 88);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.button1.Size = new System.Drawing.Size(223, 85);
            this.button1.TabIndex = 5;
            this.button1.Text = "تفاصيل المنتجات";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // frmReports
            // 
            this.AcceptButton = this.btnSaleByCtg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaleByCtg);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaleByCtg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
    }
}