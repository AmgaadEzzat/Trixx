using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Trixx_CafeSystem.Model;

namespace Trixx_CafeSystem.View
{
    public partial class frmCategoryView : frmSampleView
    {

        public frmCategoryView()
        {
            InitializeComponent();
              // Initialize the DataGridView with Edit and Delete buttons
            LoadCategoriesIntoDataGridView();
            InitializeDataGridView(); // Load categories when the form loads
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            LoadCategoriesIntoDataGridView();  // Load categories when the form loads
        }

        // Initialize DataGridView with Edit and Delete buttons
        private void InitializeDataGridView()
        {
            // Create and configure the Edit button column
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "تعديل",
                Name = "btnEdit",
                Text = "تعديل",
                UseColumnTextForButtonValue = true,
                Width = 80
               
            };

            // Create and configure the Delete button column
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "حذف",
                Name = "btnDelete",
                Text = "حذف",
                UseColumnTextForButtonValue = true,
                Width = 80,
                 // Optional: Adjust the width of the button column
            };

            // Add the Edit and Delete buttons to the rightmost position
            dataGridViewCategories.Columns.Add(btnEdit);   // Add Edit button first
            dataGridViewCategories.Columns.Add(btnDelete); // Add Delete button next
        }

        // Load Categories into DataGridView
        private void LoadCategoriesIntoDataGridView()
        {
            using (var context = new Context())
            {
                var categories = context.Categories
                                        .Select(c => new { c.Category_ID, c.Name })
                                        .ToList();
                dataGridViewCategories.DataSource = categories;

                // Setting Arabic column headers
               
               
                dataGridViewCategories.Columns["Name"].HeaderText = "الاسم";
                dataGridViewCategories.Columns["Category_ID"].HeaderText = "رقم";

               /* dataGridViewCategories.Columns["Name"].DisplayIndex =2;
                dataGridViewCategories.Columns["Category_ID"].DisplayIndex =1;*/
               


            }
        }

        // Event handler for Add button click
        public override void AddBtn_Click(object sender, EventArgs e)
        {
            frmCategoryAdd categoryAddForm = new frmCategoryAdd();
            categoryAddForm.CategorySaved += CategoryAddForm_CategorySaved;
            categoryAddForm.ShowDialog();
        }

        // Reload categories after a new category is added
        private void CategoryAddForm_CategorySaved(object sender, EventArgs e)
        {
            LoadCategoriesIntoDataGridView();
        }

        // Search categories based on the user's input
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchTxtBox.Text.Trim();

            using (var context = new Context())
            {
                var filteredCategories = context.Categories
                    .Where(c => c.Name.StartsWith(searchTerm))
                    .ToList();

                dataGridViewCategories.DataSource = filteredCategories;
            }
        }

        // Handle CellClick event for Edit and Delete buttons
        private void dataGridViewCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int categoryId = Convert.ToInt32(dataGridViewCategories.Rows[e.RowIndex].Cells["Category_ID"].Value);

                if (e.ColumnIndex == dataGridViewCategories.Columns["btnEdit"].Index)
                {
                    EditCategory(categoryId);
                }
                else if (e.ColumnIndex == dataGridViewCategories.Columns["btnDelete"].Index)
                {
                    DeleteCategory(categoryId);
                }
            }
        }

        // Edit category functionality
        private void EditCategory(int categoryId)
        {

            using (var context = new Context())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    // Create the form and pass the current category information
                    frmCategoryAdd categoryAddForm = new frmCategoryAdd
                    {
                        CategoryId = categoryId, // Set the CategoryId for editing
                        TxtName = { Text = category.Name } // Set the current category name
                    };

                    // Subscribe to the CategorySaved event
                    categoryAddForm.CategorySaved += (s, e) =>
                    {
                        // Refresh the DataGridView by reloading the categories
                        LoadCategoriesIntoDataGridView();

                        // Optionally, display a success message
                        MessageBox.Show("تم التعديل بنجاح", "تم التعديل");
                    };

                    // Show the form as a dialog
                    categoryAddForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("لا يوجد قسم", "خطأ");
                }
            }
        }

        // Delete category functionality
        private void DeleteCategory(int categoryId)
        {
            using (var context = new Context())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    DialogResult result = RTLMessageBoxForm.Show("هل تريد الخروج ؟", "الخروج");
                    if (result == DialogResult.Yes)
                    {
                        context.Categories.Remove(category);
                        context.SaveChanges();
                        LoadCategoriesIntoDataGridView();  // Refresh the DataGridView
                    }
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
