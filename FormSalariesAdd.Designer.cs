
namespace Trixx_CafeSystem
{
    partial class FormSalariesAdd
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
            this.lblname = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(366, 100);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(66, 35);
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "أضافة موظف لحساب الاجر";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trixx_CafeSystem.Properties.Resources.staff_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(298, 12);
            this.pictureBox1.Size = new System.Drawing.Size(60, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 385);
            this.panel2.Size = new System.Drawing.Size(366, 71);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(104, 17);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new System.Drawing.Point(234, 17);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(249, 132);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(86, 19);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "اختيار موظف";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 27);
            this.comboBox1.TabIndex = 0;
            // 
            // FormSalariesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 456);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblname);
            this.Name = "FormSalariesAdd";
            this.Text = "FormSalariesAdd";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblname, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}