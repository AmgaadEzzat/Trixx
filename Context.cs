using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trixx_CafeSystem
{
    class Context:DbContext
    {

        public Context() : base(@"data source=.;initial catalog=Trixx;integrated security=True;")
        {


        }

        public virtual DbSet<Login_User> Login_Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }
    }
}
