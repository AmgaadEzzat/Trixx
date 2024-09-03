using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Trixx_CafeSystem
{
    public partial class RTLMessageBoxForm : Form
    {
        public RTLMessageBoxForm(string message, string title)
        {
            InitializeComponent();
            this.Text = title;

            // Set the message text and adjust properties for RTL support
            lblMessage.Text = message;
            lblMessage.RightToLeft = RightToLeft.Yes;
            lblMessage.TextAlign = ContentAlignment.MiddleRight;

            // Set the buttons' text and adjust properties for RTL support
            btnYes.Text = "نعم";
            btnNo.Text = "لا";
            btnYes.RightToLeft = RightToLeft.Yes;
            btnNo.RightToLeft = RightToLeft.Yes;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        public static DialogResult Show(string message, string title)
        {
            using (var form = new RTLMessageBoxForm(message, title))
            {
                return form.ShowDialog();
            }
        }
    }
}
