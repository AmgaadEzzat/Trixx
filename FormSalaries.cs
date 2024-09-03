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
    
    public partial class FormSalaries : SampleViewForSalaries
    {
        private Context _context;

        public FormSalaries(int staffID, string Staff_name)
        {
            InitializeComponent();
            _context = new Context();
            LoadData(staffID, Staff_name);
        }

        public FormSalaries()
        {
            InitializeComponent();
        }

        private void FormSalaries_Load(object sender, EventArgs e)
        {
            _context = new Context();
            AddCustomColumns();
            getData();

            // Subscribe to the CellClick event
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Load Start Time from the database and populate the DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var staffIDValue = row.Cells["Staff_ID"].Value;
                if (staffIDValue != null)
                {
                    var staffID = Convert.ToInt32(staffIDValue);
                    var salaryRecord = _context.Salaries
                        .FirstOrDefault(s => s.staffID == staffID && s.End_Time == null);

                    if (salaryRecord != null)
                    {
                        row.Cells["StartTime"].Value = salaryRecord.Start_Time.ToString();
                    }
                }
            }
        }

        private void AddCustomColumns()
        {
            // Add Save Button column with Arabic text "حفظ"
            DataGridViewButtonColumn saveButtonColumn = new DataGridViewButtonColumn();
            saveButtonColumn.Name = "SaveAction";
            saveButtonColumn.HeaderText = "حفظ";
            saveButtonColumn.Text = "حفظ";
            saveButtonColumn.Width = 80;
            saveButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(saveButtonColumn);

            // Add Result TextBox column (Read-Only)
            DataGridViewTextBoxColumn resultColumn = new DataGridViewTextBoxColumn();
            resultColumn.Name = "Result";
            resultColumn.HeaderText = "الاجر اليومي";
            resultColumn.ReadOnly = true;
            resultColumn.Width = 80;
            dataGridView1.Columns.Add(resultColumn);

            // Add "احسب" Button column
            DataGridViewButtonColumn calculateButtonColumn = new DataGridViewButtonColumn();
            calculateButtonColumn.Name = "CalculateAction";
            calculateButtonColumn.HeaderText = "احسب";
            calculateButtonColumn.Text = "احسب";
            calculateButtonColumn.Width = 50;
            calculateButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(calculateButtonColumn);


            // Add Salary TextBox column
            DataGridViewTextBoxColumn salaryColumn = new DataGridViewTextBoxColumn();
            salaryColumn.Name = "Salary";
            salaryColumn.HeaderText = "الاجر";
            salaryColumn.Width = 50;
            dataGridView1.Columns.Add(salaryColumn);

            // Add End Shift Time TextBox column (Read-Only)
            DataGridViewTextBoxColumn endTextColumn = new DataGridViewTextBoxColumn();
            endTextColumn.Name = "EndTime";
            endTextColumn.HeaderText = "نهاية الشيفت";
            endTextColumn.ReadOnly = true;
            endTextColumn.Width = 80;
            dataGridView1.Columns.Add(endTextColumn);

            // Add End Shift Button column
            DataGridViewButtonColumn endButtonColumn = new DataGridViewButtonColumn();
            endButtonColumn.Name = "EndAction";
            endButtonColumn.HeaderText = "انهي الشيفت";
            endButtonColumn.Text = "انتهاء";
            endButtonColumn.Width = 60;
            endButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(endButtonColumn);

            // Add Start Shift Time TextBox column (Read-Only)
            DataGridViewTextBoxColumn startTextColumn = new DataGridViewTextBoxColumn();
            startTextColumn.Name = "StartTime";
            startTextColumn.HeaderText = "بداية الشيفت";
            startTextColumn.Width = 80;
            startTextColumn.ReadOnly = true;
            dataGridView1.Columns.Add(startTextColumn);

            // Add Start Shift Button column
            DataGridViewButtonColumn startButtonColumn = new DataGridViewButtonColumn();
            startButtonColumn.Name = "StartAction";
            startButtonColumn.HeaderText = "ابدا الشيفت";
            startButtonColumn.Text = "ابدأ";
            startButtonColumn.Width =60;
            startButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(startButtonColumn);
            
        }


        public void LoadData(int StaffID, string Staff_name)
        {
            var staffDetails = _context.Staffs
                .Where(s => s.Staff_ID == StaffID && s.Staff_Name == Staff_name)
                .Select(s => new { s.Staff_ID, s.Staff_Name })
                .ToList();

            dataGridView1.DataSource = staffDetails;
        }

        public void getData()
        {
            var staffData = _context.Staffs
                .Select(s => new {  s.Staff_Name, s.Staff_ID })
                .ToList();

            dataGridView1.DataSource = staffData;
            dataGridView1.Columns["Staff_ID"].HeaderText = "#";
            dataGridView1.Columns["Staff_ID"].Width =20;
            dataGridView1.Columns["Staff_Name"].HeaderText = "الاسم";
            dataGridView1.Columns["Staff_Name"].Width = 120;
        }

        // Handling Search 
        public void getData(string searchTerm = "")
        {
            var staffData = _context.Staffs
                .Where(s => s.Staff_Name.Contains(searchTerm))
                .Select(s => new { s.Staff_ID, s.Staff_Name })
                .ToList();

            dataGridView1.DataSource = staffData;
            dataGridView1.Columns["Staff_ID"].HeaderText = "#";
            dataGridView1.Columns["Staff_ID"].Width = 20;
            dataGridView1.Columns["Staff_Name"].HeaderText = "الاسم";
            dataGridView1.Columns["Staff_Name"].Width = 120;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the current time
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            // Check if the Start Shift button was clicked
            if (e.ColumnIndex == dataGridView1.Columns["StartAction"].Index && e.RowIndex >= 0)
            {
                // Set the value in the corresponding "StartTime" column cell
                dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value = currentTime;
            }

            // Check if the End Shift button was clicked
            if (e.ColumnIndex == dataGridView1.Columns["EndAction"].Index && e.RowIndex >= 0)
            {
                // Get the StartTime value from the row
                var startTimeValue = dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value;

                if (startTimeValue == null)
                {
                    // Show an error message if StartTime is not set
                    MessageBox.Show("من فضلك قم بتحديد وقت بداية الشيفت قبل تحديد وقت نهايته", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set the value in the corresponding "EndTime" column cell
                dataGridView1.Rows[e.RowIndex].Cells["EndTime"].Value = currentTime;
            }

            // Check if the "احسب" button was clicked
            if (e.ColumnIndex == dataGridView1.Columns["CalculateAction"].Index && e.RowIndex >= 0)
            {
                // Get the StartTime and EndTime values
                var startTimeValue = dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value;
                var endTimeValue = dataGridView1.Rows[e.RowIndex].Cells["EndTime"].Value;

                // Check if both StartTime and EndTime are filled
                if (startTimeValue != null && endTimeValue != null)
                {
                    // Parse the times
                    DateTime startTime = DateTime.Parse(startTimeValue.ToString());
                    DateTime endTime = DateTime.Parse(endTimeValue.ToString());

                    // Ensure that EndTime is after StartTime
                    if (endTime <= startTime)
                    {
                        MessageBox.Show("تأكد من أن وقت النهاية بعد وقت البداية", "بيانات غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Calculate the difference in hours
                    double hoursWorked = (endTime - startTime).TotalHours;

                    // Get the Salary value and parse it
                    var salaryValue = dataGridView1.Rows[e.RowIndex].Cells["Salary"].Value;
                    if (salaryValue != null && double.TryParse(salaryValue.ToString(), out double salary))
                    {
                        // Calculate the result
                        double result = hoursWorked * salary;

                        // Ensure that the result is positive
                        if (result < 0)
                        {
                            MessageBox.Show("النتيجة يجب أن تكون قيمة إيجابية", "خطأ في الحساب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Set the result in the Result column
                        dataGridView1.Rows[e.RowIndex].Cells["Result"].Value = result.ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show("ادخل قيمة للأجر في الساعة", "قيمة غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("من فضلك ادخل معاد بداية ونهاية الشيفت", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Check if the "حفظ" button was clicked
            if (e.ColumnIndex == dataGridView1.Columns["SaveAction"].Index && e.RowIndex >= 0)
            {
                // Retrieve the data from the row
                var staffIDValue = dataGridView1.Rows[e.RowIndex].Cells["Staff_ID"].Value;
                var salaryValue = dataGridView1.Rows[e.RowIndex].Cells["Salary"].Value;
                var startTimeValue = dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value;
                var endTimeValue = dataGridView1.Rows[e.RowIndex].Cells["EndTime"].Value;
                var resultValue = dataGridView1.Rows[e.RowIndex].Cells["Result"].Value;

                // Check if all necessary data is present
                if (staffIDValue != null && salaryValue != null && startTimeValue != null && endTimeValue != null && resultValue != null)
                {
                    TimeSpan startTime = TimeSpan.Zero;
                    TimeSpan endTime = TimeSpan.Zero;

                    if (startTimeValue != null)
                    {
                        TimeSpan.TryParse(startTimeValue.ToString(), out startTime);
                    }

                    if (endTimeValue != null)
                    {
                        TimeSpan.TryParse(endTimeValue.ToString(), out endTime);
                    }

                    // Create a new Salary object
                    Salaries salaryRecord = new Salaries
                    {
                        staffID = Convert.ToInt32(staffIDValue),
                        Wage_per_hour = Convert.ToDouble(salaryValue),
                        Start_Time = startTime,
                        End_Time = endTime,
                        Salary = Convert.ToDouble(resultValue)
                    };

                    // Save the record to the database
                    _context.Salaries.Add(salaryRecord);
                    _context.SaveChanges();

                    MessageBox.Show("تم الحفظ بنجاح.", "الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("لم يتم الحفظ تأكد ان جميع البيانات ممتلئة", "لم يتم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Check if the "Salary" column is being edited
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Salary")
            {
                // Check if the entered value is a valid number
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out _))
                {
                    // Cancel the edit and show an error message
                    e.Cancel = true;
                    MessageBox.Show("ادخل قيمة للأجر في الساعة", "قيمة غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Get the search term from the TextBox
            string searchTerm = txtSearch.Text.Trim();

            // Call getData with the search term to filter the DataGridView
            getData(searchTerm);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RTLMessageBoxForm.Show("هل تريد الخروج ؟", "الخروج");
                if (result == DialogResult.Yes)
                {
                    // Explicitly call the form closing logic
                    OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, false));
                    this.Close(); // Close the current form
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Get the StartTime value from the row
                var startTimeValue = row.Cells["StartTime"].Value;

                if (startTimeValue != null)
                {
                    // Get the Staff ID to identify the row
                    var staffIDValue = row.Cells["Staff_ID"].Value;

                    if (staffIDValue != null)
                    {
                        // Convert StartTime to TimeSpan
                        TimeSpan startTime = TimeSpan.Zero;
                        if (TimeSpan.TryParse(startTimeValue.ToString(), out startTime))
                        {
                            var staffID = Convert.ToInt32(staffIDValue);

                            var salaryRecord = _context.Salaries
                                .FirstOrDefault(s => s.staffID == staffID && s.End_Time == null);

                            if (salaryRecord != null)
                            {
                                salaryRecord.Start_Time = startTime;
                            }
                            else
                            {
                                salaryRecord = new Salaries
                                {
                                    staffID = staffID,
                                    Start_Time = startTime
                                };
                                _context.Salaries.Add(salaryRecord);
                            }

                            _context.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Start Time format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


    }
}