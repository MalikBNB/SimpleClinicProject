using System;
using System.Collections.Generic;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string Specialization { get; set; }  

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int Creator { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
