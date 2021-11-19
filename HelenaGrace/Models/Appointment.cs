using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public DateTime dateTime { get; set; }
        public string phoneNumber { get; set; }

        public Appointment(int id, string email, string name, DateTime dateTime, string phoneNumber)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.dateTime = dateTime;
            this.phoneNumber = phoneNumber;
        }

        public Appointment() { }
    }
}
