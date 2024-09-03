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
    public partial class frmStaff : SampleViewForSalaries
    {
        private Context _context;
        private string _loggedInUserName;
        public frmStaff(string loggedInUserName)
        {
            InitializeComponent();
            _loggedInUserName = loggedInUserName;
            _context = new Context();

            InitializeDataGridView();  // Initialize the DataGridView with Edit and Delete buttons
            LoadStaffIntoDataGridView();  // Load categories when the form loads
        }
        private void frmStaff_Load(object sender, EventArgs e)
        {
            LoadStaffIntoDataGridView();
            dvgStaff.CellClick += dvgStaff_CellClick;
        }

        private void LoadStaffIntoDataGridView()
        {
            
            
                var Staff = _context.Staffs
                                        .Select(s => new { s.Staff_ID,s.Staff_Name,s.Staff_Phone,s.Address,s.Assign_Date})
                                        .ToList();
                dvgStaff.DataSource = Staff;

            // Setting Arabic column headers
            dvgStaff.Columns["Assign_Date"].HeaderText = " تاريخ التعيين";
            dvgStaff.Columns["Address"].HeaderText = " العنوان";
            dvgStaff.Columns["Staff_Phone"].HeaderText = " رقم التليفون";
            dvgStaff.Columns["Staff_Name"].HeaderText = "الاسم";
            dvgStaff.Columns["Staff_ID"].HeaderText = "#";

            dvgStaff.Columns["Staff_ID"].DisplayIndex = 0;       // First column
            dvgStaff.Columns["Staff_Name"].DisplayIndex = 1;     // Second column
            dvgStaff.Columns["Staff_Phone"].DisplayIndex = 2;    // Third column
            dvgStaff.Columns["Address"].DisplayIndex = 3;        // Fourth column
            dvgStaff.Columns["Assign_Date"].DisplayIndex = 4;



        }

        private void InitializeDataGridView()
        {
            // Create and configure the Edit button column
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "تعديل",
                Name = "btnEdit",
                Text = "تعديل",
                UseColumnTextForButtonValue = true,
                Width = 80, // Optional: Adjust the width of the button column
            };

            // Create and configure the Delete button column
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "حذف",
                Name = "btnDelete",
                Text = "حذف",
                UseColumnTextForButtonValue = true,
                Width = 80, // Optional: Adjust the width of the button column
            };

            // Add the Edit and Delete buttons to the rightmost position
            dvgStaff.Columns.Add(btnEdit);   // Add Edit button first
            dvgStaff.Columns.Add(btnDelete); // Add Delete button next
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            Staff_Details staff_Details = new Staff_Details(_loggedInUserName);
            staff_Details.StaffSaved += StaffAddForm_staffSaved;
            staff_Details.ShowDialog();

        }

        // Reload categories after a new category is added
        private void StaffAddForm_staffSaved(object sender, EventArgs e)
        {
            LoadStaffIntoDataGridView();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the search term from the TextBox
            string searchTerm = txtSearch.Text.Trim();

            // Call getData with the search term to filter the DataGridView
            getData(searchTerm);
        }


        // Handling Search 
        public void getData(string searchTerm = "")
        {
            var staffData = _context.Staffs
                .Where(s => s.Staff_Name.Contains(searchTerm))
               .Select(s => new { s.Assign_Date,s.Address, s.Staff_Phone ,s.Staff_Name ,s.Staff_ID  })
                                        .ToList();

            dvgStaff.DataSource = staffData;
            
            dvgStaff.Columns["Assign_Date"].HeaderText = " تاريخ التعيين";
            dvgStaff.Columns["Address"].HeaderText = " العنوان";
            dvgStaff.Columns["Staff_Phone"].HeaderText = " رقم التليفون";
            dvgStaff.Columns["Staff_Name"].HeaderText = "الاسم";
            dvgStaff.Columns["Staff_ID"].HeaderText = "#";

            dvgStaff.Columns["Staff_ID"].DisplayIndex = 0;       // First column
            dvgStaff.Columns["Staff_Name"].DisplayIndex = 1;     // Second column
            dvgStaff.Columns["Staff_Phone"].DisplayIndex = 2;    // Third column
            dvgStaff.Columns["Address"].DisplayIndex = 3;        // Fourth column
            dvgStaff.Columns["Assign_Date"].DisplayIndex = 4;

        }


        // Handle CellClick event for Edit and Delete buttons
        private void dvgStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
              

                int StaffID = Convert.ToInt32(dvgStaff.Rows[e.RowIndex].Cells["Staff_ID"].Value);

                if (e.ColumnIndex == dvgStaff.Columns["btnEdit"].Index)
                {
                  
                    EditStaff(StaffID);
                }
                else if (e.ColumnIndex == dvgStaff.Columns["btnDelete"].Index)
                {
                   
                    DeleteStaff(StaffID);
                }
            }
        }
        // Edit staff functionality
        private void EditStaff(int staffID)
        {
            var staff = _context.Staffs.Find(staffID);
            if (staff != null)
            {
                // Create the form in edit mode
                Staff_Details staff_Details = new Staff_Details(_loggedInUserName)
                {
                    StaffId = staffID, // Set the StaffId to the ID of the staff being edited
                    TxtName = { Text = staff.Staff_Name },
                    TxtAddress = { Text = staff.Address },
                    TxtNID = { Text = staff.NID },
                    TxtPhoneNumber = { Text = staff.Staff_Phone }
                };

                // Subscribe to the StaffSaved event
                staff_Details.StaffSaved += (s, e) =>
                {
                    // Refresh the DataGridView by reloading the staff members
                    LoadStaffIntoDataGridView();

                    // Optionally, display a success message
                    MessageBox.Show("تم التعديل بنجاح", "تم التعديل");
                };

                // Show the form as a dialog
                staff_Details.ShowDialog();
            }
            else
            {
                MessageBox.Show("لا يوجد موظف بهذا المعرف", "خطأ");
            }
        }


        // Delete category functionality
        private void DeleteStaff(int staffID)
        {
           
                var staffmember = _context.Staffs.Find(staffID);
                if (staffmember != null)
            {
                DialogResult result = RTLMessageBoxForm.Show("هل تريد الخروج ؟", "الخروج");
                if (result == DialogResult.Yes)
                    {
                    _context.Staffs.Remove(staffmember);
                    _context.SaveChanges();
                        LoadStaffIntoDataGridView();  
                    }
                }
            
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

      
    }
}
