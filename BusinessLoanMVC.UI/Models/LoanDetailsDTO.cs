using BusinessLoanMVC.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLoanMVC.UI.Models
{
    public class LoanDetailsDTO
    {
        public User user { get; set; }
        public Document doc { get; set; }
    }
}