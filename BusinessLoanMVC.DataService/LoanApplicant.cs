using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLoanMVC.DataService
{
    public class LoanApplicant
    {
        [Key]
        public Guid LoanId { get; set; }
        public string LoanType  { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public string ApplicantMobile { get; set; }
        public string ApplicantEmail { get; set; }
        public string ApplicantAadhar { get; set; }
        public string ApplicantPan { get; set; }
        public string ApplicantSalary { get; set; }
        public int LoanAmountRequired { get; set; }
        public int LoanRepaymentMonths { get; set; }
    }
}
