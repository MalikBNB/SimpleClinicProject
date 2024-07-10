using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.EntitesInfos
{
    public class PaymentInfo
    {
        public int Id { set; get; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal AmountPaid { get; set; }

        public string AdditionalNotes { get; set; }

        public int? CreatorId { get; set; }

        public string Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public string Modifier { get; set; }

        public DateTime Modified { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        Check
    }
}
