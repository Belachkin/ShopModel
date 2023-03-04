using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    internal class User
    {
        public string Username { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }       
        public string Address { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public User(string username, string lastName, string firstName, string middleName, string role, string address, string password)
        {
            Username = username;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Role = role;
            Address = address;
            Password = password;
        }
    }
}
