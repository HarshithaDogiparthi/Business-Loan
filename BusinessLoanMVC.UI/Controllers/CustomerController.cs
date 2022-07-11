using BusinessLoanMVC.DataService;
using BusinessLoanMVC.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessLoanMVC.UI.Controllers
{
    public class CustomerController : Controller

    {
        public LoanRepository loanRepository;
        public UserRepository userRepository;
        public CustomerController()
        {
            loanRepository = new LoanRepository();
            userRepository = new UserRepository();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult ViewLoans()
        {
            IEnumerable<Loan> loans = loanRepository.GetLoanByUser(Session["username"].ToString());
            return View(loans);
            
        }
        public PartialViewResult RejectedLoans()
        {
            IEnumerable<Loan> loans = loanRepository.GetRejectedLoansByUser(Session["username"].ToString());
            return PartialView(loans);
        }
        public PartialViewResult ApprovedLoans()
        {
            IEnumerable<Loan> loans= loanRepository.GetApprovedLoansByUser(Session["username"].ToString());
            return PartialView(loans);
        }
        public ActionResult Profile()
        {
            var x = userRepository.GetUserByName(Session["username"].ToString());
            return View(x);

        }
    }
}