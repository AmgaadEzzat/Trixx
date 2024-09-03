using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trixx_CafeSystem
{
    internal class Staff
    {
        [Key]
        public int Staff_ID { get; set; }
        public string Staff_Name { get; set; }
        [ForeignKey("Login_User")]
        public int User_ID {  get; set; }
        [MaxLength(14), Column(TypeName = "varchar")]
        public string NID { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "date")]
        public DateTime Assign_Date { get; set; }
        [MaxLength(11)]
        public string Staff_Phone { get; set; }
        public virtual Login_User Login_User { get; set; }

        // Don't forget to name the table => Salaries when you create it  
        public virtual ICollection<Salaries> Salaries { get; set; } // one to one relationship

    }
}
