using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }

        public User(string firstName, string lastName, string email, string password, string phoneNumber, string bio)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Bio = bio;
        }
    }
}
