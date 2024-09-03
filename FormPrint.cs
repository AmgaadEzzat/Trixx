using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trixx_CafeSystem
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RTLMessageBoxForm.Show("هل تريد الخروج ؟", "الخروج");
                if (result == DialogResult.Yes)
                {
                    this.Close(); // Close the current form
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        private Size originalSize = new Size(922, 550);
        private Point originalLocation = new Point(0, 0);
        private Point originalExitButtonLocation;
        private Point originalMaximizeButtonLocation;
        private Point originalMinimizeButtonLocation;
        private bool isMaximized = false;
        private void btnMax_Click(object sender, EventArgs e)
        {
            if (isMaximized)
            {
                // Undo the maximization
                this.WindowState = FormWindowState.Normal; // Change the state to Normal
                this.Size = originalSize;
                this.Location = originalLocation;

                // Restore the original button positions
                btnExit.Location = originalExitButtonLocation;
                btnMax.Location = originalMaximizeButtonLocation;
                btnMin.Location = originalMinimizeButtonLocation;

                btnMax.Text = "تكبير";
                isMaximized = false;
            }
            else
            {
                // Store the original size, location, and button positions before maximizing
                originalSize = this.Size;
                originalLocation = this.Location;
                originalExitButtonLocation = btnExit.Location;
                originalMaximizeButtonLocation = btnMax.Location;
                originalMinimizeButtonLocation = btnMin.Location;

                // Maximize the form
                this.WindowState = FormWindowState.Maximized;

                // Move the buttons to a specific location when the form is maximized
                btnExit.Location = new Point(1100, 5);  // Example: move to (X, Y)
                btnMax.Location = new Point(1030, 5);   // Example: move to (X, Y)
                btnMin.Location = new Point(960, 5);    // Example: move to (X, Y)

                btnMax.Text = "عودة";
                isMaximized = true;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
