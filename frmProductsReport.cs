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
using Trixx_CafeSystem.Reports;

namespace Trixx_CafeSystem
{
    public partial class frmProductsReport : Form
    {
        public frmProductsReport()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Get parameters
            DateTime startDate = StartDate.Value.Date;
            DateTime endDate = EndDate.Value.Date;
            Debug.WriteLine(StartDate.ToString(), EndDate.ToString());

            rptProducts rptProducts = new rptProducts();
            // Set parameters
            rptProducts.SetParameterValue("StartDate", startDate);
            rptProducts.SetParameterValue("EndDate", endDate);

            FormPrint frmPrint = new FormPrint();
            frmPrint.crystalReportViewer1.ReportSource = rptProducts;
            frmPrint.crystalReportViewer1.Refresh();
            frmPrint.Show();
        
        }
    }
}
