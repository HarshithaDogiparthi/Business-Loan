
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLoanMVC.DataService
{
    public class Seed
    {
        public BusinessLoanContext _context;

        private string BasePath = "C:/Users/mohan/source/repos/BusinessLoanMVC/BusinessLoanMVC.DataService/Data/";
        public Seed(BusinessLoanContext context)
        {
            _context = context;

            if (CreateInitDb())
            {
                SeedUsers();
            }
        }
        public bool CreateInitDb()
        {
            if (_context.Database.CreateIfNotExists()) return true;
            return false;
        }
        public void SeedUsers()
        {
            var path = $"{BasePath}users.json";
            var Data = System.IO.File.ReadAllText(path);
            var JsonData = JsonSerializer.Deserialize<List<User>>(Data);

            foreach (var x in JsonData)
            {
                Console.WriteLine(x);
                _context.Users.Add(x);
            }
            _context.SaveChanges();

            Console.WriteLine("Users Seeding Done");
        }

    }
}
