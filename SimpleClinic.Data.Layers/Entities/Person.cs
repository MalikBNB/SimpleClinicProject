using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public char Gendor { get; set; }

        public string PhoneNo { get; set; } 

        public string Email { get; set; }

        public string Address { get; set; } 

        public int Creator { get; set; }

        public DateTime Created { get; set; }
    }
}
