using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.EntitesInfos
{
    public class MedicalRecordInfo
    {
        public int Id { get; set; }

        public string VisitDescription { get; set; }

        public string Diagnosis { get; set; }

        public string AdditionalNotes { get; set; }

        public int CreatorId { get; set; }

        public string Creator { get; set; }

        public DateTime Created { get; set; }

        public int ModifierId { get; set; }

        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

    }
}
