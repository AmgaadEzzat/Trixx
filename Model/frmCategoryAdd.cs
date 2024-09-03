using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Trixx_CafeSystem.View;

namespace Trixx_CafeSystem.Model
{
   
    public partial class frmCategoryAdd : SampleAdd
    {
        public event EventHandler CategorySaved;

        
        public frmCategoryAdd()
        {
            InitializeComponent();
          
        }

        public int id = 0;
        // In CategoryAdd form
        public TextBox TxtName
        {
            get { return textName; }
        }
        public int? CategoryId { get; set; }  // Nullable int property to track the category being edited

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = textName.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("من فضلك ادخل اسم صحيح", "خطأ");
                return;
            }

            using (var context = new Context())
            {
                if (CategoryId.HasValue && CategoryId.Value > 0)
                {
                    // Update existing category
                    var existingCategory = context.Categories.Find(CategoryId.Value);
                    if (existingCategory != null)
                    {
                        existingCategory.Name = categoryName;
                        context.SaveChanges();

                        MessageBox.Show("تم اضافة القسم بنجاح", "تم");
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد قسم", "خطأ");
                    }
                }
                else
                {
                    // Add new category
                    var newCategory = new Category { Name = categoryName };
                    context.Categories.Add(newCategory);
                    context.SaveChanges();

                    MessageBox.Show("تم أضافة القسم بنجاح", "تم");
                }
            }

            // Raise the CategorySaved event to notify that a category was added or updated
            CategorySaved?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
