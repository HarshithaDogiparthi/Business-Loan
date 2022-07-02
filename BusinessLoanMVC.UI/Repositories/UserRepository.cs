using BusinessLoanMVC.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLoanMVC.UI.Repositories
{
    public class UserRepository
    {
        public BusinessLoanContext Context;
        public UserRepository()
        {
            Context = new BusinessLoanContext();
        }
        public void AddUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
        public void EditUser(User user)
        {
            Context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
        public void DeleteUser(String Username)
        {
            Context.Users.Remove(Context.Users.Find(Username));
            Context.SaveChanges();
        }
        public User GetUserById(String Email)
        {
            User user = Context.Users.Where(u =>  u.Email.Equals(Email)).FirstOrDefault<User>();
            return user;
            
        }
        public IEnumerable<User>GetAllUsers()
        {
            return Context.Users.ToList();
        }

    }
}