
namespace Trixx_CafeSystem
{
    partial class Staff_Details
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
            this.staffName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.phoneNumber = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(405, 100);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(128, 30);
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.Text = "اضافة موظف جديد";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trixx_CafeSystem.Properties.Resources.staff_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(311, 12);
            this.pictureBox1.Size = new System.Drawing.Size(66, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 379);
            this.panel2.Size = new System.Drawing.Size(405, 71);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(106, 17);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new System.Drawing.Point(253, 17);
            // 
            // staffName
            // 
            this.staffName.AutoSize = true;
            this.staffName.Location = new System.Drawing.Point(351, 118);
            this.staffName.Name = "staffName";
            this.staffName.Size = new System.Drawing.Size(42, 19);
            this.staffName.TabIndex = 2;
            this.staffName.Text = "الاسم";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(236, 140);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 26);
            this.txtName.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(236, 250);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(157, 26);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // phoneNumber
            // 
            this.phoneNumber.AutoSize = true;
            this.phoneNumber.Location = new System.Drawing.Point(313, 228);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(80, 19);
            this.phoneNumber.TabIndex = 4;
            this.phoneNumber.Text = "رقم التليفون";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 250);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(198, 45);
            this.txtAddress.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "العنوان";
            // 
            // txtNID
            // 
            this.txtNID.Location = new System.Drawing.Point(12, 140);
            this.txtNID.Name = "txtNID";
            this.txtNID.Size = new System.Drawing.Size(198, 26);
            this.txtNID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "الرقم القومي";
            // 
            // Staff_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.txtNID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.staffName);
            this.Name = "Staff_Details";
            this.Text = "Staff_Details";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.staffName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.phoneNumber, 0);
            this.Controls.SetChildIndex(this.txtPhoneNumber, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNID, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label staffName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label phoneNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNID;
        private System.Windows.Forms.Label label3;
    }
}