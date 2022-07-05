using BusinessLoanMVC.DataService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void AddLoan(Loan loan)
        {
            context.Loans.Add(loan);
            context.SaveChanges();
        }
        public void EditLoan(Loan loan)
        {
            context.Entry<Loan>(loan).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteLoan(Guid loanId)
        {
            Loan loan = context.Loans.Find(loanId);
            context.Loans.Remove(loan);
            context.SaveChanges();

        }
        public Loan GetLoanById(Guid loanId)
        {
            Loan loan = context.Loans.Find(loanId);
            return loan;
        }
       public IEnumerable<Loan> GetLoanByUser(String username)
        {
           return  context.Loans.Where(loan => loan.Username == username);
            
        }
        public IEnumerable<Loan> GetAllLoans()
        {
            return context.Loans.ToList();
        }
    }
}