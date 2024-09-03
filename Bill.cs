using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trixx_CafeSystem
{
    internal class Bill
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public double TotalPrice { get; set; }
        [Column(TypeName = ("date"))]
        public DateTime BillDate { get; set; }
        [Column(TypeName = ("time"))]
        public TimeSpan BillTime { get; set; }
        [ForeignKey("Cashier_User")]
        public int CashierID { get; set; }
        public Login_User Cashier_User { get; set; }
    }
}
