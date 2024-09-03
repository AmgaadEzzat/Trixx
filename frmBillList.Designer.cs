namespace Trixx_CafeSystem
{
    partial class frmBillList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvBillNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Size = new System.Drawing.Size(898, 100);
            this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.button1, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(635, 35);
            this.label1.Size = new System.Drawing.Size(145, 32);
            this.label1.Text = "قائمة الفاتورة";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trixx_CafeSystem.Properties.Resources.istockphoto_1224630183_612x612;
            this.pictureBox1.Location = new System.Drawing.Point(786, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 611);
            this.panel2.Size = new System.Drawing.Size(898, 10);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(501, 17);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new System.Drawing.Point(631, 17);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBillNum,
            this.dgvCashier,
            this.dgvOrderNum,
            this.dgvDate,
            this.dgvTotalPrice,
            this.dgvPrint});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(77, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 61;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(738, 436);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dgvBillNum
            // 
            this.dgvBillNum.HeaderText = "رقم الفاتوره";
            this.dgvBillNum.MinimumWidth = 6;
            this.dgvBillNum.Name = "dgvBillNum";
            this.dgvBillNum.ReadOnly = true;
            this.dgvBillNum.Width = 125;
            // 
            // dgvCashier
            // 
            this.dgvCashier.HeaderText = "الكاشير";
            this.dgvCashier.MinimumWidth = 6;
            this.dgvCashier.Name = "dgvCashier";
            this.dgvCashier.ReadOnly = true;
            this.dgvCashier.Width = 125;
            // 
            // dgvOrderNum
            // 
            this.dgvOrderNum.HeaderText = "رقم الطلب";
            this.dgvOrderNum.MinimumWidth = 6;
            this.dgvOrderNum.Name = "dgvOrderNum";
            this.dgvOrderNum.ReadOnly = true;
            this.dgvOrderNum.Width = 125;
            // 
            // dgvDate
            // 
            this.dgvDate.HeaderText = "التاريخ";
            this.dgvDate.MinimumWidth = 6;
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            this.dgvDate.Width = 125;
            // 
            // dgvTotalPrice
            // 
            this.dgvTotalPrice.HeaderText = "السعر الاجمالي";
            this.dgvTotalPrice.MinimumWidth = 6;
            this.dgvTotalPrice.Name = "dgvTotalPrice";
            this.dgvTotalPrice.ReadOnly = true;
            this.dgvTotalPrice.Width = 125;
            // 
            // dgvPrint
            // 
            this.dgvPrint.FillWeight = 50F;
            this.dgvPrint.HeaderText = "";
            this.dgvPrint.Image = global::Trixx_CafeSystem.Properties.Resources.download__1_;
            this.dgvPrint.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvPrint.MinimumWidth = 6;
            this.dgvPrint.Name = "dgvPrint";
            this.dgvPrint.ReadOnly = true;
            this.dgvPrint.Width = 50;
            // 
            // frmBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(898, 621);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmBillList";
            this.Text = "frmBillList";
            this.Load += new System.EventHandler(this.frmBillList_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBillNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotalPrice;
        private System.Windows.Forms.DataGridViewImageColumn dgvPrint;
    }
}