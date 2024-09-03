using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixx_CafeSystem.Reports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Trixx_CafeSystem
{
    public partial class frmBillList : SampleAdd
    {
        Context Context = new Context();
        public frmBillList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var query = (from B in Context.Bills
                        join C in Context.Login_Users
                        on B.CashierID equals C.User_ID
                        where B.BillDate == DateTime.Today
                        select new 
                        {
                            dgvBillNum = B.BillId,
                            dgvOrderNum = B.OrderId,
                            dvgDate = B.BillDate,
                            dvgTotalPrice = B.TotalPrice,
                            dvgCashier = C.User_Name
                        }).ToList();
            // Bind the result to the DataGridView
            foreach(var item in query)
            {
                string formattedDate = item.dvgDate.ToString("yyyy-MM-dd");
                dataGridView1.Rows.Add( item.dgvBillNum, item.dvgCashier, item.dgvOrderNum, formattedDate, item.dvgTotalPrice);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvPrint")
            {
                    int selectedBillId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvBillNum"].Value);
                    var billDetails = (from B in Context.Bills
                                   where B.BillId == selectedBillId
                                   select B).ToList();
                    FormPrint frmPrint = new FormPrint();
                    rptBill rptBill = new rptBill();
                    rptBill.SetDataSource(billDetails);
                    frmPrint.crystalReportViewer1.ReportSource = rptBill;
                    frmPrint.crystalReportViewer1.Refresh();
                    frmPrint.Show();
            }
        }

    }
}
