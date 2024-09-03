using System;
using System.Linq;
using System.Windows.Forms;

namespace Trixx_CafeSystem
{
    public partial class Profile : Form
    {
        private string _loggedInUserName;
        private readonly Context _context;

        public Profile(string loggedInUserName)
        {
            InitializeComponent();
            _context = new Context();
            _loggedInUserName = loggedInUserName;
            LoadUserData();
        }

        // Load the user's data into the text boxes
        private void LoadUserData()
        {
            var user = _context.Login_Users.SingleOrDefault(u => u.User_Name == _loggedInUserName);
            if (user != null)
            {
                txtUserName.Text = user.User_Name;
                txtPassword.Text = user.Password;
            }
        }

        // Update the user's username and password
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string newUserName = txtUserName.Text;
            string newPassword = txtPassword.Text;

            if (newUserName.Length < 3)
            {
                MessageBox.Show("يجب أن يتكون اسم المستخدم من 3 أحرف على الأقل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(newPassword))
            {
                MessageBox.Show("يجب أن تتكون كلمة المرور من 5 اجزاء على الأقل، وتحتوي على أرقام فقط بالإضافة إلى حرف واحد على الأقل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = _context.Login_Users.SingleOrDefault(u => u.User_Name == _loggedInUserName);
            if (user != null)
            {
                user.User_Name = newUserName;
                user.Password = newPassword;
                _context.SaveChanges();

                _loggedInUserName = newUserName;

                if (this.Owner is frmMain mainForm)
                {
                    mainForm.UpdateUsernameLabel(newUserName);
                }

                MessageBox.Show("تم تحديث اسم المستخدم. سيتم تسجيل الخروج الآن.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                Form frmMain = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
                if (frmMain != null)
                {
                    frmMain.Close();
                }

                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
        }

        // Delete the user's account
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("هل أنت متأكد أنك تريد حذف حسابك؟ لا يمكن التراجع عن هذا الإجراء.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var user = _context.Login_Users.SingleOrDefault(u => u.User_Name == _loggedInUserName);
                if (user != null)
                {
                    _context.Login_Users.Remove(user);
                    _context.SaveChanges();

                    MessageBox.Show("تم حذف المستخدم بنجاح. سيتم إغلاق التطبيق الآن.", "تم حذف المستخدم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("تم إلغاء حذف الحساب.", "تم إلغاء العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Add a new user
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newUserName = txtUserName.Text;
            string newPassword = txtPassword.Text;

            if (newUserName.Length < 3)
            {
                MessageBox.Show("يجب أن يتكون اسم المستخدم من 3 أحرف على الأقل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(newPassword))
            {
                MessageBox.Show("يجب أن تتكون كلمة المرور من 5 اجزاء على الأقل، وتحتوي على أرقام فقط بالإضافة إلى حرف واحد على الأقل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingUser = _context.Login_Users.Any(u => u.User_Name == newUserName);
            if (existingUser)
            {
                MessageBox.Show("اسم المستخدم موجود بالفعل. الرجاء اختيار اسم مستخدم مختلف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newUser = new Login_User
            {
                User_Name = newUserName,
                Password = newPassword
            };

            _context.Login_Users.Add(newUser);
            _context.SaveChanges();
            MessageBox.Show("تمت إضافة مستخدم جديد بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtUserName.Clear();
            txtPassword.Clear();
        }

        // Validate the password according to specified rules
        private bool IsValidPassword(string password)
        {
            if (password.Length < 5) return false;

            bool hasLetter = false;
            bool hasOnlyDigitsAndLetters = true;

            foreach (char c in password)
            {
                if (char.IsLetter(c)) hasLetter = true;
                if (!char.IsLetterOrDigit(c)) hasOnlyDigitsAndLetters = false;
            }

            return hasLetter && hasOnlyDigitsAndLetters;
        }

        // Close the Profile form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
