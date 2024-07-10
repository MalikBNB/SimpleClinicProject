using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.EntitesInfos;
using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll.Entities
{
    public class PtientBLL : SharedBll
    {
        public async static void Add(AppDbContext db, Patient patient)
        {
            db.Patients.Add(patient);
            await db.SaveChangesAsync();
        }

        public async static void Delete(int Id)
        {
            using (var db = new AppDbContext())
            {
                var patient = db.Patients.FirstOrDefault(x => x.Id == Id);
                db.Patients.Remove(patient);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<PatientInfo>> GetAllPatientsInfo()
        {
            return await Db.Patients.Include(p => p.Person).AsNoTracking().Select(item => new PatientInfo
            {
                Id = item.Id,
                Person = item.Person,
                CreatorId = item.CreatorId,
                Created = item.Created, 
                ModifierId = item.ModifierId,   
                Modified = item.Modified,
            }).ToListAsync();
        }
    }
}
