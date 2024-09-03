using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Trixx_CafeSystem
{
   public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        [ForeignKey("Login_User")]
        public int? User_Id { get; set; }
        public Login_User Login_User { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }

    }
}
