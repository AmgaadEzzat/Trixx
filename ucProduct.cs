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
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }

        // Additional logic and methods for the ucProduct control can be added here
        public void SetProductName(string name)
        {
            label1.Text = name;
        }

       
    }
}
