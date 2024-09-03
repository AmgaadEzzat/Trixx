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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Trixx_CafeSystem
{
    public partial class frmPOS : Form
    {
        private string _loggedInUserName;
        Context Context = new Context();

        public frmPOS(string loggedInUserName)
        {
            InitializeComponent();
            _loggedInUserName = loggedInUserName;
        }
       
      
        private void LoadProductsByCategory(string categoryName)
        {
            using (var context = new Context())
            {
                var category = context.Categories.FirstOrDefault(c => c.Name == categoryName);
                if (category == null) return;

                var products = context.Products
                                      .Where(p => p.Category_ID == category.Category_ID)
                                      .ToList();

                ProductPanel.Controls.Clear();

                foreach (var product in products)
                {
                    var productLabel = new Label
                    {
                        Text = product.Name,
                        Font = new Font("Segoe UI", 16.2F),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(150, 150),
                        Margin = new Padding(10),
                        BackColor = Color.FromArgb(50, 55, 89),
                        ForeColor = Color.White // Set the font color to white
                    };


                    // Store product object in Tag property for easy retrieval
                    productLabel.Tag = product;

                    // Attach the click event to the label
                    productLabel.Click += ProductLabel_Click;

                    ProductPanel.Controls.Add(productLabel);
                }
            }
        }

        private void LoadAllProducts()
        {
            using (var context = new Context())
            {
                var products = context.Products.ToList();
                ProductPanel.Controls.Clear();

                foreach (var product in products)
                {
                    var productLabel = new Label
                    {
                        Text = product.Name,
                        Font = new Font("Segoe UI", 16.2F),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(150, 150),
                        Margin = new Padding(10),
                        BackColor = Color.FromArgb(50, 55, 89),
                        ForeColor = Color.White // Set the font color to white
                    };


                    productLabel.Tag = product;
                    productLabel.Click += ProductLabel_Click;

                    ProductPanel.Controls.Add(productLabel);
                }
            }
        }
        private void UpdateRowNumbers()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells["Column1"].Value = i + 1;
            }
        }
        private void ProductLabel_Click(object sender, EventArgs e)
        {
            var productLabel = sender as Label;
            if (productLabel == null) return;

            var product = productLabel.Tag as Product;
            if (product == null) return;

            // Check if the product is already in the DataGridView
            bool productExists = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Column2"].Value?.ToString() == product.Name)
                {
                    // Product already in , increase quantity
                    int currentQuantity = (int)row.Cells["Column3"].Value;
                    row.Cells["Column3"].Value = currentQuantity + 1;

                    // Update the total price 
                    row.Cells["Column4"].Value = product.Price * (currentQuantity + 1);

                    productExists = true;
                    break;
                }
            }

            if (!productExists)
            {
                // Product not in , add new row
                int newRowIndex = dataGridView2.Rows.Add();
                DataGridViewRow newRow = dataGridView2.Rows[newRowIndex];
                newRow.Cells["Column1"].Value = dataGridView2.Rows.Count; // Row number
                newRow.Cells["Column2"].Value = product.Name;
                newRow.Cells["Column3"].Value = 1; // Default
                newRow.Cells["Column4"].Value = product.Price; // Price  for 1 item
            }

            // Update all row numbers in Column1
            UpdateRowNumbers();
        }

        

        private void Drinks_Click(object sender, EventArgs e)
        {
            LoadProductsByCategory("مشروبات");
        }

        private void Desserts_Click(object sender, EventArgs e)
        {
            LoadProductsByCategory("حلويات");
        }

        private void Close_Click(object sender, EventArgs e)
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

        private void Category_Click_1(object sender, EventArgs e)
        {
            LoadAllProducts();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Commit any pending changes in the DataGridView
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            // Ensure that at least one row is selected
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Loop through all selected rows
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    // Check if the row is the new row being edited
                    if (row.IsNewRow)
                    {
                        // Cancel the edit if the row is new and uncommitted
                        dataGridView2.CancelEdit();
                    }
                    else
                    {
                        // Remove the selected row from the DataGridView
                        dataGridView2.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("اختر صف للمسح", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void save_Order_Click(object sender, EventArgs e)
        {
            // Check if the DataGridView contains any valid product rows
            bool hasValidProduct = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Column2"].Value != null) // Check if product name is not null
                {
                    hasValidProduct = true;
                    break;
                }
            }

            // If no valid product rows are found, display a warning and exit
            if (!hasValidProduct)
            {
                MessageBox.Show("يجب اختيار طلب قبل التأكيد.", "No Products Ordered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new Context())
            {
                // Create a new Order
                var order = new Order
                {
                    User_Id = GetCurrentUserId(),
                    Date = DateTime.Now
                };

                context.Orders.Add(order);
                context.SaveChanges(); // Save to generate the Order_Id

                var orderProducts = new List<OrderProducts>();

                // Iterate through the DataGridView rows to create OrderProducts
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Column2"].Value == null) continue; // Skip rows with no product

                    var productName = row.Cells["Column2"].Value.ToString();
                    var product = context.Products.FirstOrDefault(p => p.Name == productName);
                    if (product == null) continue; // Skip if product is not found

                    int quantity = Convert.ToInt32(row.Cells["Column3"].Value);
                    double amountPrice = Convert.ToDouble(row.Cells["Column4"].Value);

                    var orderProduct = new OrderProducts
                    {
                        OrderId = order.Order_Id,
                        ProductId = product.Product_ID,
                        Quantity = quantity,
                        AmountPrice = amountPrice
                    };
                    context.OrderProducts.Add(orderProduct);
                    orderProducts.Add(orderProduct);                  
                }
                //Store the order to bill
                double totalPrice = orderProducts
                                    .Where(op => op.OrderId == order.Order_Id)
                                    .Sum(op => (double)op.AmountPrice);
                var bill = new Bill
                {
                    OrderId = order.Order_Id,
                    BillDate = DateTime.Now,
                    BillTime = DateTime.Now.TimeOfDay,
                    CashierID = GetCurrentUserId(),
                    TotalPrice = totalPrice
                };
                context.Bills.Add(bill);
                context.SaveChanges();
                MessageBox.Show("تم حفظ الطلب بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.Rows.Clear();
                // Display the saved order in frmBillList
                frmBillList billForm = new frmBillList();
                billForm.Show();
            }
        }

        //  method to simulate getting the current user's ID
        private int GetCurrentUserId()
        {
            int? userId = Context.Login_Users
                .Where(u => u.User_Name == _loggedInUserName)
                .Select(u => (int?)u.User_ID).FirstOrDefault();

            return userId.Value; // Replace with actual user ID retrieval logic
        }

        

    }
}
