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
    public partial class frmProductAdd : SampleAdd
    {
        private string _loggedInUserName;

        public event EventHandler ProductSaved;
        public frmProductAdd(string loggedInUserName)
        {
            InitializeComponent();
            _loggedInUserName = loggedInUserName;
        }

        // Public properties to access the text boxes from outside if needed
        public TextBox TxtName => txtName;
        public NumericUpDown TxtPrice => txtPrice;
        public ComboBox Categcomco => CategCombo;
        public NumericUpDown Quantity => qty;
        public int? Product_ID { get; set; }


        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                var Categories = context.Categories
                    .Select(c => new { CatName = c.Name, CatID = c.Category_ID })
                    .ToList();

                // Bind the ComboBox
                Categcomco.DataSource = Categories;
                Categcomco.DisplayMember = "CatName";
                Categcomco.ValueMember = "CatID";
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string productName = TxtName.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("من فضلك ادخل اسم صحيح", "خطأ");
                return;
            }

            if (Quantity.Value < 0)
            {
                MessageBox.Show("من فضلك ادخل قيمة صحيحه", "خطأ");
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

                // Check if a product with the same name and category already exists
                var existingProduct = context.Products
                    .FirstOrDefault(p => p.Name == productName && p.Category_ID == (int)Categcomco.SelectedValue);

                if (existingProduct != null && (!Product_ID.HasValue || existingProduct.Product_ID != Product_ID.Value))
                {
                    MessageBox.Show("هذا المنتج موجود بالفعل في نفس الفئة.", "خطأ");
                    return;
                }

                if (Product_ID.HasValue && Product_ID.Value > 0)
                {
                    existingProduct = context.Products.Find(Product_ID.Value);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = TxtName.Text;
                        existingProduct.Stock_Qty = (int)Quantity.Value;
                        existingProduct.Price = (decimal)TxtPrice.Value;
                        existingProduct.Category_ID = (int)Categcomco.SelectedValue;
                        existingProduct.User_ID = user.User_ID;
                        context.SaveChanges();

                        MessageBox.Show("تم تحديث بيانات المنتج بنجاح", "تم");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المنتج", "خطأ");
                    }
                }
                else
                {
                    var newProduct = new Product
                    {
                        Name = TxtName.Text,
                        Stock_Qty = (int)Quantity.Value,
                        Price = (decimal)TxtPrice.Value,
                        Category_ID = (int)Categcomco.SelectedValue,
                        User_ID = user.User_ID
                    };
                    context.Products.Add(newProduct);
                    context.SaveChanges();

                    MessageBox.Show("تم إضافة المنتج بنجاح", "تم");
                }
            }

            ProductSaved?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}