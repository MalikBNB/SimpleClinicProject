using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public int? PatientId { get; set; }  
      
        public virtual Patient Patient { get; set; }    

        public int? DoctorId { get; set; }   
      
        public virtual Doctor Doctor { get; set; }

        public int? MedicalRecordId { get; set; }    
        
        public virtual MedicalRecord MedicalRecord { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool AppointmentStatus { get; set; }

        public int? PaymentId { get; set; }  
        
        public virtual Payment Payment { get; set; }

        public int? CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public virtual User Modifier { get; set; }

        public DateTime Modified { get; set; }
    }
}
