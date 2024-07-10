using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.EntitesInfos
{
    public class PrescriptionInfo
    {
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

        public string Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public string Modifier { get; set; }

        public DateTime Modified { get; set; }
    }
}
