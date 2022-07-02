using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLoanMVC.DataService
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Index(IsUnique =true),StringLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string UserRole { get; set; }
    }
}
