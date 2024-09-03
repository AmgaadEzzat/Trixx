using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trixx_CafeSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string password = txtPass.Text;
            // Validate username
            if (userName.Length < 3)
            {
                MessageBox.Show("اسم المستخدم غير صالح. الرجاء إدخال 3 أحرف على الأقل", "اسم مستخدم غير صالح");
                return;
            }
            // Validate password
            if (!ValidatePassword(password))
            {
                MessageBox.Show("يجب أن تتكون كلمة المرور من 5 اجزاء على الأقل، وتحتوي على أرقام فقط بالإضافة إلى حرف واحد على الأقل.", "كلمة المرور غير صالحة");
                return;
            }
            using (var context = new Context())
            {
                var user = context.Login_Users.SingleOrDefault(u => u.User_Name == userName && u.Password == password);

                if (user != null)
                {
                    // If user is valid, open MainForm and pass the username
                    frmMain mainForm = new frmMain(user.User_Name);
                    this.Hide(); // Hide the login form
                    mainForm.ShowDialog(); // Show the main form as a dialog
                    this.Close(); // Close the login form after the main form is closed
                }
                else
                {
                    MessageBox.Show("الرجاء إدخال بيانات صحيحة.", "تسجيل الدخول غير صالح");
                }
            }
        }
        private bool ValidatePassword(string password)
        {
            if (password.Length < 5) return false;

            bool hasLetter = false;
            bool hasOnlyDigitsAndLetters = true;

            foreach (char c in password)
            {
                if (char.IsLetter(c)) hasLetter = true;
                if (!char.IsLetterOrDigit(c)) hasOnlyDigitsAndLetters = false;
            }

            // The password should contain at least one letter and consist of only letters and digits
            return hasLetter && hasOnlyDigitsAndLetters;
        }
    }
}
