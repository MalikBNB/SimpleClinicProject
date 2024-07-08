using System;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }  
        public Patient Patient { get; set; }    

        public int DoctorId { get; set; }   
        public Doctor Doctor { get; set; }

        public int MedicalRecordId { get; set; }    
        public MedicalRecord MedicalRecord { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool AppointmentStatus { get; set; }

        public int PaymentId { get; set; }  
        public Payment Payment { get; set; }    

        public int Creator {  set; get; }   
        public DateTime Created { get; set; }
    }
}
