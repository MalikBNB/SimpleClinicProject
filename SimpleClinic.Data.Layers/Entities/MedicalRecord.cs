using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleClinic.Data.Layers.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        public string VisitDescription { get; set; }    

        public string Diagnosis { get; set; }   

        public string AdditionalNotes { get; set; }

        public int? CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime Created { get; set; }
    }

}
