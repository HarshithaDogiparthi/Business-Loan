using BusinessLoanMVC.DataService;
using BusinessLoanMVC.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            User usr=userRepository.GetUserById(user.Email);
            if(user.Password.Equals(usr.Password))
            {
                if(usr.UserRole.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if(usr.UserRole.Equals("User"))
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            return RedirectToAction("Login");
        }
    }
}