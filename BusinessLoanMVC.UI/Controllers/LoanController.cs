using BusinessLoanMVC.DataService;
using BusinessLoanMVC.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessLoanMVC.UI.Controllers
{
    public class LoanController : Controller
    {
        // GET: ApplyLoan
        public LoanRepository loanRepository;
        public LoanController()
        {
            loanRepository = new LoanRepository();

        }
        public ActionResult ViewLoans()
        {
            IEnumerable<Loan> loans = loanRepository.GetAllLoans();
            return View(loans);
        }
        public ActionResult CreateLoan()
        {
            return View();
        }

        public ActionResult CreateLoan(Loan loan)
        {
            loan.LoanId = Guid.NewGuid();
            loanRepository.AddLoan(loan);
            return RedirectToAction("ViewLoans");
        }

    }
}