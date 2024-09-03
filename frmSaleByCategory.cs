using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixx_CafeSystem.Reports;

namespace Trixx_CafeSystem
{
    public partial class frmSaleByCategory : Form
    {
        Context Context = new Context();
        public frmSaleByCategory()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Get parameters
            DateTime StartDate = dateTimePicker1.Value.Date;
            DateTime EndDate = dateTimePicker2.Value.Date;
            Debug.WriteLine(StartDate.ToString(),EndDate.ToString() );

            rptSaleByCategory rptSaleByCategory = new rptSaleByCategory();
            // Set parameters
            rptSaleByCategory.SetParameterValue("StartDate", StartDate);
            rptSaleByCategory.SetParameterValue("EndDate", EndDate);

            FormPrint frmPrint = new FormPrint();
            frmPrint.crystalReportViewer1.ReportSource = rptSaleByCategory;
            frmPrint.crystalReportViewer1.Refresh();
            frmPrint.Show();
        }
    }
}
