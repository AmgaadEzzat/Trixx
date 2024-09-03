using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trixx_CafeSystem
{
    class Salaries
    {
        [Key]
        public int salaryID { get; set; }
        [ForeignKey("Staff_Member")]
        public int staffID { get; set; }
        public virtual Staff Staff_Member { get; set; }
        public double Wage_per_hour { get; set; }

        [Column(TypeName = "Time")]
        public TimeSpan Start_Time{ get; set; } = DateTime.Now.TimeOfDay;

        [Column(TypeName = "Time")]
        public TimeSpan End_Time { get; set; }

      
        public double Salary { get; set; }

    }
}
