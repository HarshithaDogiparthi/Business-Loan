using BusinessLoanMVC.DataService;
using BusinessLoanMVC.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BusinessLoanMVC.UI.Controllers
{
    public class UserController : Controller
    {

        public UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            user.UserRole = "User";
            userRepository.AddUser(user);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(User user)
        {
            User x=userRepository.GetUserById(user.Email);
            
            
            string status = "3";
            if (x == null) { }
            else
            {
                bool val = x.Email.Equals(user.Email) && x.Password.Equals(user.Password);
                if (val)
                {
                    Session["username"] = x.Username;
                    Session["role"] = x.UserRole;

                    if (x.UserRole == "Admin") status = "1";
                   

                    else if (x.UserRole == "User") status = "2";
                    
                }

            }
            return new JsonResult { Data = new { status = status } };
            /*return RedirectToAction("Login");*/
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        public ActionResult ViewAllUsers()
        {
            var x = userRepository.GetAllUsers();
            return View(x);
        }
        [HttpGet]
        public PartialViewResult EditUser(string userName)
        {
            var x = userRepository.GetUserByName(userName);
            return PartialView(x);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            userRepository.EditUser(user);
            return RedirectToAction("ViewAllUsers");
        }
        [HttpGet]
        public PartialViewResult EditProfile(string userName)
        {
            var x = userRepository.GetUserByName(userName);
            return PartialView(x);
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            userRepository.EditUser(user);
            return RedirectToAction("Profile","Customer");
        }

    }
}