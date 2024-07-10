using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        public int? PersonId { get; set; }
        
        public virtual Person Person { get; set; }

        public string Specialization { get; set; }

        public int? CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public virtual User Modifier { get; set; }

        public DateTime Modified { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
