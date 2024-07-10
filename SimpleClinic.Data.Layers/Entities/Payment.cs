using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Payment
    {
        [Key]
        public int Id { set; get; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal AmountPaid { get; set; } 

        public string AdditionalNotes { get; set; }

        public int? CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public virtual User Modifier { get; set; }

        public DateTime Modified { get; set; }

    }

    public enum PaymentMethod
    { 
        Cash,
        Check
    }
}
