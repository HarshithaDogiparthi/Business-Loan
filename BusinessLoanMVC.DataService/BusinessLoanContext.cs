
using System;
using System.Data.Entity;
using System.Linq;

namespace BusinessLoanMVC.DataService
{
    public class BusinessLoanContext : DbContext
    {
        //public static string con = @"Data Source=LAPTOP-M47IO616;Initial Catalog=BusinessLoanMVC;Integrated Security=True";
        //public static string con = @"Data Source=DESKTOP-B2UVGO5;Initial Catalog=BusinessLoanMVC;Integrated Security=True";
        public static string con = @"Data Source=DESKTOP-4UR8BQQ;Initial Catalog=BusinessLoanMVC;Integrated Security=True";
        public BusinessLoanContext(): base(con)
        {
        }
         public DbSet<User> Users { get; set; }
         public DbSet<Loan> Loans { get; set; }
         public DbSet<Document> Documents { get; set; }
    }

   
}