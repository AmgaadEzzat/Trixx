using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trixx_CafeSystem
{
    public partial class Staff_Details : SampleAdd
    {
        private string _loggedInUserName;
        public event EventHandler StaffSaved;

        public Staff_Details(string loggedInUserName)
        {
            InitializeComponent();
            _loggedInUserName = loggedInUserName;
        }

        // Public properties to access the text boxes from outside if needed
        public TextBox TxtName => txtName;
        public TextBox TxtPhoneNumber => txtPhoneNumber;
        public TextBox TxtAddress => txtAddress;
        public TextBox TxtNID => txtNID;

        public int? StaffId { get; set; }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string staffName = TxtName.Text.Trim();
            string nid = TxtNID.Text.Trim();
            string phoneNumber = TxtPhoneNumber.Text.Trim();

            // Validate the staff name
            if (string.IsNullOrEmpty(staffName))
            {
                MessageBox.Show("من فضلك ادخل اسم صحيح", "خطأ");
                return;
            }

            // Validate the NID
            if (nid.Length != 14 || !nid.All(char.IsDigit))
            {
                MessageBox.Show("الرقم القومي يجب أن يكون مكون من 14 رقمًا.", "خطأ");
                return;
            }

            // Validate the phone number
            if (phoneNumber.Length != 11 || !phoneNumber.StartsWith("01") || !phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("رقم الهاتف يجب أن يكون 11 رقمًا ويبدأ بـ 01.", "خطأ");
                return;
            }

            using (var context = new Context())
            {
                var user = context.Login_Users.FirstOrDefault(u => u.User_Name == _loggedInUserName);
                if (user == null)
                {
                    MessageBox.Show("المستخدم الحالي غير موجود.", "خطأ");
                    return;
                }
                var existedStaff = context.Staffs
                                  .FirstOrDefault(s => s.NID == nid || s.Staff_Phone == phoneNumber);

                if (existedStaff != null)
                {
                    MessageBox.Show("هذا الموظف موجود بالفعل.", "خطأ");
                    return;
                }
                if (StaffId.HasValue && StaffId.Value > 0)
                {
                    // Update existing staff
                    var existingStaff = context.Staffs.Find(StaffId.Value);
                    if (existingStaff != null)
                    {
                        existingStaff.Staff_Name = staffName;
                        existingStaff.Staff_Phone = phoneNumber;
                        existingStaff.NID = nid;
                        existingStaff.Address = TxtAddress.Text;
                        existingStaff.User_ID = user.User_ID;
                        context.SaveChanges();

                        MessageBox.Show("تم تحديث بيانات الموظف بنجاح", "تم");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على الموظف", "خطأ");
                    }
                }
                else
                {
                    // Add new staff
                    var newStaff = new Staff
                    {
                        Staff_Name = staffName,
                        Staff_Phone = phoneNumber,
                        NID = nid,
                        Address = TxtAddress.Text,
                        User_ID = user.User_ID,
                        Assign_Date = DateTime.Now.Date
                    };
                    context.Staffs.Add(newStaff);
                    context.SaveChanges();

                    MessageBox.Show("تم إضافة الموظف بنجاح", "تم");
                }
            }

            StaffSaved?.Invoke(this, EventArgs.Empty);
            this.Close();
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}