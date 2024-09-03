using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trixx_CafeSystem
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [ForeignKey("Login_User")]
        public int User_ID { get; set; }
        public Login_User Login_User { get; set; }

        [ForeignKey("Category")]
        public int Category_ID { get; set; }
        public virtual Category Category { get; set; }

        public int Stock_Qty { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
