using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.EntitesInfos
{
    public class AppointmentInfo
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public string Patient { get; set; }

        public string PatientPhoneNo { get; set; }

        public int? DoctorId { get; set; }

        public string Doctor { get; set; }

        public string DoctorPhoneNo { get; set; }

        public int? MedicalRecordId { get; set; }

        public virtual MedicalRecord MedicalRecord { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool AppointmentStatus { get; set; }

        public int? PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public int? CreatorId { get; set; }

        public string Creator { get; set; }

        public DateTime Created { get; set; }

        public int? ModifierId { get; set; }

        public string Modifier { get; set; }

        public DateTime Modified { get; set; }
    }
}
