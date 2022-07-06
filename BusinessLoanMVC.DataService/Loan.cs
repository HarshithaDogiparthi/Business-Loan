using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLoanMVC.DataService
{
    public class Loan
    {
        [Key]
        public Guid LoanId { get; set; }
        public int LoanAmountRequired { get; set; }
        public int LoanRepaymentMonths { get; set; }
        public string LoanIssueDate { get; set; } 
        public string LoanStatus { get; set; }
        [ForeignKey("Document")]
        public Guid DocumentId { get; set; }
        [JsonIgnore]
        public Document Document { get; set; }
        [ForeignKey("User")]
        public string Username { get; set; }
        [JsonIgnore]
        public User User { get; set; }

    }
}
