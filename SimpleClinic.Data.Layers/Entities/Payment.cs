using System;

namespace SimpleClinic.Data.Layers.Entities
{
    public class Payment
    {
        public int PaymentId { set; get; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public decimal AmountPaid { get; set; } 

        public string AdditionalNotes { get; set; }

        public int Creator { set; get; }
        public DateTime Created { get; set; }
    }
}
