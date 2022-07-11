using BusinessLoanMVC.DataService;
using BusinessLoanMVC.UI.Models;
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
        public UserRepository userRepository;
        public DocumentRepository documentRepository;
        public DocumentController documentController;
        public LoanController()
        {
            loanRepository = new LoanRepository();
            userRepository = new UserRepository();
            documentRepository = new DocumentRepository();
            documentController = new DocumentController();
        }
        public ActionResult ViewLoans()
        {
            IEnumerable<Loan> loans = loanRepository.GetAllLoans();
            return View(loans);
        }
        [HttpGet]
        public ActionResult CreateLoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLoan(Loan loan, HttpPostedFileBase upload)
        {
            loan.LoanId = Guid.NewGuid();
            loan.DocumentId = documentController.UploadDocument(new Document(), upload);
            loan.Username = Session["username"].ToString();
            loan.LoanIssueDate = DateTime.Now.ToString("dd/MM/yyyy");
            loan.LoanStatus = "Pending";
            loanRepository.AddLoan(loan);
            return RedirectToAction("ViewLoans","Customer");
        }

        public ActionResult ApproveLoan(Guid loanId) {
            Loan loan = loanRepository.GetLoanById(loanId);
            loanRepository.ApproveLoan(loan);
            return RedirectToAction("ViewLoans");
        }
        public ActionResult RejectLoan(Guid loanId) {
            Loan loan = loanRepository.GetLoanById(loanId);
            loanRepository.RejectLoan(loan);
            return RedirectToAction("ViewLoans");
        }
        public PartialViewResult LoanDetails(Guid loanId) {
            Loan loan = loanRepository.GetLoanById(loanId);
            User user = userRepository.GetUserByName(loan.Username);
            Document doc = documentRepository.GetDocumentById(loan.DocumentId);
            LoanDetailsDTO obj = new LoanDetailsDTO();
            obj.user = user;
            obj.doc = doc;
            return PartialView(obj);
        }
    }
}