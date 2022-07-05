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
        public CustomerController()
        {
            loanRepository = new LoanRepository();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
       /* public ActionResult ViewLoans()
        {
            IEnumerable<Loan> loans = loanRepository.GetLoanByUser(username);
            return View(loans);
            
        }*/
    }
}