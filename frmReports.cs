using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixx_CafeSystem.Reports;

namespace Trixx_CafeSystem
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private async void btnSaleByCtg_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                frmSaleByCategory frmSaleByCategory = new frmSaleByCategory();
                frmSaleByCategory.ShowDialog();
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                frmProductsReport frmProductsReport = new frmProductsReport();
                frmProductsReport.ShowDialog();
            });
        }

        private  void button2_Click(object sender, EventArgs e)
        {    
            rptSalaries rptSalaries = new rptSalaries();
            FormPrint frmPrint = new FormPrint();
            frmPrint.crystalReportViewer1.ReportSource = rptSalaries;
            frmPrint.crystalReportViewer1.Refresh();
            frmPrint.Show();           
        }
    }
}
