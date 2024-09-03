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
    public partial class frmProductView : SampleViewForSalaries
    {
        private Context _context;
        private string _loggedInUserName;
        public frmProductView(string loggedInUserName)
        {
            InitializeComponent();
            _loggedInUserName = loggedInUserName;
            _context = new Context();

            InitializeDataGridView();  // Initialize the DataGridView with Edit and Delete buttons
            LoadProductsIntoDataGridView();  // Load categories when the form loads
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            LoadProductsIntoDataGridView();
            dvgProduct.CellClick += dvgProduct_CellClick;
        }


        private void LoadProductsIntoDataGridView()
        {


            var product = _context.Products
                                    .Select(p=> new { p.Name, p.Price, p.Stock_Qty, p.Category_ID,p.Product_ID})
                                    .ToList();
            dvgProduct.DataSource = product;

            // Setting Arabic column headers
            dvgProduct.Columns["Category_ID"].HeaderText = " رقم التصنيف";
            dvgProduct.Columns["Stock_Qty"].HeaderText = " الكمية";
            dvgProduct.Columns["Price"].HeaderText = " السعر";
            dvgProduct.Columns["Name"].HeaderText = "الاسم";
            dvgProduct.Columns["Product_ID"].HeaderText = "#";

            dvgProduct.Columns["Product_ID"].DisplayIndex = 0;       // First column
            dvgProduct.Columns["Name"].DisplayIndex = 1;     // Second column
            dvgProduct.Columns["Price"].DisplayIndex = 2;    // Third column
            dvgProduct.Columns["Stock_Qty"].DisplayIndex = 3;        // Fourth column
            dvgProduct.Columns["Category_ID"].DisplayIndex = 4;



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
            dvgProduct.Columns.Add(btnEdit);   // Add Edit button first
            dvgProduct.Columns.Add(btnDelete); // Add Delete button next
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frmProductAdd = new frmProductAdd(_loggedInUserName);
            frmProductAdd.ProductSaved += ProductAddForm_ProductSaved;
            frmProductAdd.ShowDialog();

        }

        // Reload categories after a new category is added
        private void dvgProduct_CellClick(object sender, EventArgs e)
        {
            LoadProductsIntoDataGridView();
        }

        private void ProductAddForm_ProductSaved(object sender, EventArgs e)
        {
            LoadProductsIntoDataGridView();
        }

      


        // Handling Search 
        public void getData(string searchTerm = "")
        {
            var product = _context.Products
                                   .Where(p => p.Name.Contains(searchTerm))
               .Select(p => new { p.Name, p.Price, p.Stock_Qty, p.Category_ID, p.Product_ID })
                                        .ToList();
            dvgProduct.DataSource = product;

            // Setting Arabic column headers
            dvgProduct.Columns["Category_ID"].HeaderText = " رقم التصنيف";
            dvgProduct.Columns["Stock_Qty"].HeaderText = " الكمية";
            dvgProduct.Columns["Price"].HeaderText = " السعر";
            dvgProduct.Columns["Name"].HeaderText = "الاسم";
            dvgProduct.Columns["Product_ID"].HeaderText = "#";

            dvgProduct.Columns["Product_ID"].DisplayIndex = 0;       // First column
            dvgProduct.Columns["Name"].DisplayIndex = 1;     // Second column
            dvgProduct.Columns["Price"].DisplayIndex = 2;    // Third column
            dvgProduct.Columns["Stock_Qty"].DisplayIndex = 3;        // Fourth column
            dvgProduct.Columns["Category_ID"].DisplayIndex = 4;

        }
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the search term from the TextBox
            string searchTerm = txtSearch.Text.Trim();

            // Call getData with the search term to filter the DataGridView
            getData(searchTerm);
        }

        // Handle CellClick event for Edit and Delete buttons
        private void dvgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                int productID = Convert.ToInt32(dvgProduct.Rows[e.RowIndex].Cells["Product_ID"].Value);

                if (e.ColumnIndex == dvgProduct.Columns["btnEdit"].Index)
                {

                    EditProduct(productID);
                }
                else if (e.ColumnIndex == dvgProduct.Columns["btnDelete"].Index)
                {

                    DeleteProduct(productID);
                }
            }
        }
        // Edit staff functionality
        private void EditProduct(int productID)
        {
            var product = _context.Products.Find(productID);
            if (product != null)
            {
                frmProductAdd frmProductAdd = new frmProductAdd(_loggedInUserName)
                {
                    Product_ID = productID,
                    TxtName = { Text = product.Name },
                    TxtPrice = { Value = product.Price },
                    Quantity = { Value = product.Stock_Qty },
                    Categcomco = { SelectedValue = product.Category_ID }
                };

                frmProductAdd.ProductSaved += (s, e) =>
                {
                    if (frmProductAdd.Quantity.Value < 0)
                    {
                        MessageBox.Show("من فضلك ادخل قيمة صحيحه", "خطأ");
                        return;
                    }

                    // Save changes after validating the quantity
                    product.Name = frmProductAdd.TxtName.Text;
                    product.Price = frmProductAdd.TxtPrice.Value;
                    product.Stock_Qty = (int)frmProductAdd.Quantity.Value;
                    product.Category_ID = (int)frmProductAdd.Categcomco.SelectedValue;

                    _context.SaveChanges();
                    LoadProductsIntoDataGridView();
                    MessageBox.Show("تم التعديل بنجاح", "تم التعديل");
                };

                frmProductAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("لا يوجد منتج بهذا المعرف", "خطأ");
            }
        }

        // Delete category functionality
        private void DeleteProduct(int productID)
        {

            var product = _context.Products.Find(productID);
            if (product != null)
            {
                DialogResult result = RTLMessageBoxForm.Show("هل انت متاكد من حذف هذا المنتج؟", "حذف");
                if (result == DialogResult.Yes)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    LoadProductsIntoDataGridView();
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

