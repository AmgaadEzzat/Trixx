namespace Trixx_CafeSystem
{
    partial class frmPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Close_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CategoryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Category_Button = new System.Windows.Forms.Button();
            this.Drinks_Button = new System.Windows.Forms.Button();
            this.Desert_Button = new System.Windows.Forms.Button();
            this.ProductPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save_Order = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.CategoryPanel.SuspendLayout();
            this.ProductPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.Close_Button);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 103);
            this.panel1.TabIndex = 0;
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.Red;
            this.Close_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Close_Button.FlatAppearance.BorderSize = 2;
            this.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Button.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Button.ForeColor = System.Drawing.Color.White;
            this.Close_Button.Location = new System.Drawing.Point(12, 12);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(122, 75);
            this.Close_Button.TabIndex = 7;
            this.Close_Button.Text = "اغلاق";
            this.Close_Button.UseVisualStyleBackColor = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1105, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = " اوردر";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1193, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(271, 501);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(77, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(31, 501);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 603);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1308, 85);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // CategoryPanel
            // 
            this.CategoryPanel.Controls.Add(this.Category_Button);
            this.CategoryPanel.Controls.Add(this.Drinks_Button);
            this.CategoryPanel.Controls.Add(this.Desert_Button);
            this.CategoryPanel.Location = new System.Drawing.Point(1153, 109);
            this.CategoryPanel.Name = "CategoryPanel";
            this.CategoryPanel.Size = new System.Drawing.Size(155, 386);
            this.CategoryPanel.TabIndex = 1;
            // 
            // Category_Button
            // 
            this.Category_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.Category_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Category_Button.FlatAppearance.BorderSize = 2;
            this.Category_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Category_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category_Button.ForeColor = System.Drawing.Color.White;
            this.Category_Button.Location = new System.Drawing.Point(3, 3);
            this.Category_Button.Name = "Category_Button";
            this.Category_Button.Size = new System.Drawing.Size(149, 72);
            this.Category_Button.TabIndex = 4;
            this.Category_Button.Text = "جميع المنتجات\r\n";
            this.Category_Button.UseVisualStyleBackColor = false;
            this.Category_Button.Click += new System.EventHandler(this.Category_Click_1);
            // 
            // Drinks_Button
            // 
            this.Drinks_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.Drinks_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Drinks_Button.FlatAppearance.BorderSize = 2;
            this.Drinks_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Drinks_Button.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drinks_Button.ForeColor = System.Drawing.Color.White;
            this.Drinks_Button.Location = new System.Drawing.Point(3, 81);
            this.Drinks_Button.Name = "Drinks_Button";
            this.Drinks_Button.Size = new System.Drawing.Size(149, 72);
            this.Drinks_Button.TabIndex = 5;
            this.Drinks_Button.Text = "المشروبات";
            this.Drinks_Button.UseVisualStyleBackColor = false;
            this.Drinks_Button.Click += new System.EventHandler(this.Drinks_Click);
            // 
            // Desert_Button
            // 
            this.Desert_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.Desert_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Desert_Button.FlatAppearance.BorderSize = 2;
            this.Desert_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Desert_Button.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desert_Button.ForeColor = System.Drawing.Color.White;
            this.Desert_Button.Location = new System.Drawing.Point(3, 159);
            this.Desert_Button.Name = "Desert_Button";
            this.Desert_Button.Size = new System.Drawing.Size(149, 72);
            this.Desert_Button.TabIndex = 6;
            this.Desert_Button.Text = "الحلويات";
            this.Desert_Button.UseVisualStyleBackColor = false;
            this.Desert_Button.Click += new System.EventHandler(this.Desserts_Click);
            // 
            // ProductPanel
            // 
            this.ProductPanel.AutoScroll = true;
            this.ProductPanel.Controls.Add(this.dataGridView1);
            this.ProductPanel.Location = new System.Drawing.Point(570, 112);
            this.ProductPanel.Name = "ProductPanel";
            this.ProductPanel.Size = new System.Drawing.Size(568, 386);
            this.ProductPanel.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(8, 8);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView2.Location = new System.Drawing.Point(16, 112);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(551, 383);
            this.dataGridView2.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "رقم";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "اسم المنتج";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "كميه ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "سعر";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // save_Order
            // 
            this.save_Order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.save_Order.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.save_Order.FlatAppearance.BorderSize = 2;
            this.save_Order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_Order.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_Order.ForeColor = System.Drawing.Color.White;
            this.save_Order.Location = new System.Drawing.Point(354, 501);
            this.save_Order.Name = "save_Order";
            this.save_Order.Size = new System.Drawing.Size(122, 75);
            this.save_Order.TabIndex = 6;
            this.save_Order.Text = "تأكيد";
            this.save_Order.UseVisualStyleBackColor = false;
            this.save_Order.Click += new System.EventHandler(this.save_Order_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Red;
            this.delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.delete.FlatAppearance.BorderSize = 2;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(114, 501);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(122, 75);
            this.delete.TabIndex = 7;
            this.delete.Text = "مسح";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // frmPOS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1308, 688);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.save_Order);
            this.Controls.Add(this.ProductPanel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.CategoryPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPOS";
            this.Text = "frmPOS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.CategoryPanel.ResumeLayout(false);
            this.ProductPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FlowLayoutPanel CategoryPanel;
        private System.Windows.Forms.FlowLayoutPanel ProductPanel;
        private System.Windows.Forms.Button Category_Button;
        private System.Windows.Forms.Button Drinks_Button;
        private System.Windows.Forms.Button Desert_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Button save_Order;
        private System.Windows.Forms.Button delete;
    }
}