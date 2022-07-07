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
            loan.LoanIssueDate = DateTime.Now.ToString("dd/MM/yyyy");
            loan.LoanStatus = "Pending";
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
            return context.Loans.Where(loan => loan.Username == username);

        }
        public IEnumerable<Loan> GetAllLoans()
        {
            return context.Loans.ToList();
        }
        public IEnumerable<Loan> GetApprovedLoansByUser(String username)
        {

            return context.Loans.Where(loan => (loan.Username == username && loan.LoanStatus == "Approved"));
        }
        public IEnumerable<Loan> GetRejectedLoansByUser(String username)
        {
            return context.Loans.Where(loan => (loan.Username == username && loan.LoanStatus == "Rejected"));
        }

        public void ApproveLoan(Loan loan) {
            loan.LoanStatus = "Approved";
            context.Entry<Loan>(loan).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void RejectLoan(Loan loan) {
            loan.LoanStatus = "Rejected";
            context.Entry<Loan>(loan).State = EntityState.Modified;
            context.SaveChanges();
        }
        
    }

}