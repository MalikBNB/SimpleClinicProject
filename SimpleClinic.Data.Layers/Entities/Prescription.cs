using System;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public string MedicationName { get; set; }

        public string Dosage { get; set; }  

        public string Freauency { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string SpecialInstructions { get; set; }

        public int Creator { get; set; }

        public DateTime Created { get; set; }

        public int MedicalRecordId { get; set; } 
        
        public MedicalRecord MedicalRecord { get; set; }    

    }

}
