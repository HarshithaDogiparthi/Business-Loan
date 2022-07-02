using BusinessLoanMVC.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLoanMVC.UI.Repositories
{
    public class LoanRepository
    {
        public BusinessLoanContext context;
        public LoanRepository()
        {
            context = new BusinessLoanContext();
        }
        public void AddLoan(LoanApplicant loan)
        {
            context.LoanApplicants.Add(loan);
            context.SaveChanges();
        }
        public void EditLoan(LoanApplicant loan)
        {
            context.Entry<LoanApplicant>(loan).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteLoan(String loanId)
        {
            LoanApplicant loan = context.LoanApplicants.Find(loanId);
            context.LoanApplicants.Remove(loan);
            context.SaveChanges();

        }
        public LoanApplicant GetLoanById(string loanId)
        {
            LoanApplicant loan = context.LoanApplicants.Find(loanId);
            return loan;
        }
        public IEnumerable<LoanApplicant> GetAllLoans()
        {
            return context.LoanApplicants.ToList();
        }
    }
}