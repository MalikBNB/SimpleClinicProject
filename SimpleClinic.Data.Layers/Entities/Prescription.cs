using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        public string MedicationName { get; set; }

        public int? MedicalRecordId { get; set; }
       
        public virtual MedicalRecord MedicalRecord { get; set; }

        public string Dosage { get; set; }  

        public string Frequency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string SpecialInstructions { get; set; }

        public int? CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public virtual User Modifier { get; set; }

        public DateTime Modified { get; set; }
    }

}
