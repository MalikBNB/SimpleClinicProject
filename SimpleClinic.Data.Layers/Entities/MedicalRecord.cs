using System;

namespace SimpleClinic.Data.Layers.Entities
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }

        public string VisitDescription { get; set; }    

        public string Diagnosis { get; set; }   

        public string AdditionalNotes { get; set; } 

        public int Creator {  get; set; }   

        public DateTime Created { get; set; }
    }

}
