using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.EntitesInfos;
using SimpleClinic.Data.Layers.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll.Entities
{
    public class DoctorBLL : SharedBll
    {
        public async static void Add(AppDbContext db, Doctor doctor)
        {
            db.Doctors.Add(doctor);
            await db.SaveChangesAsync();
        }

        public async static void Update(AppDbContext db, DoctorInfo doctorInfo)
        {
            var oldDoctor = db.Doctors.FirstOrDefault(d => d.Id == doctorInfo.Id);

            if (oldDoctor == null) return;

            oldDoctor.Specialization = doctorInfo.Specialization;
            await db.SaveChangesAsync();
        }

        public async static void Delete(int Id)
        {
            using (var db = new AppDbContext())
            {
                var Doctor = db.Doctors.FirstOrDefault(x => x.Id == Id);
                db.Doctors.Remove(Doctor);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<DoctorInfo>> GetAllDoctorsInfo()
        {
            return await Db.Doctors.Include(p => p.Person).AsNoTracking().Select(item => new DoctorInfo
            {
                Id = item.Id,
                Person = item.Person,
                Specialization = item.Specialization,
                CreatorId = item.CreatorId,
                Created = item.Created,
                ModifierId = item.ModifierId,
                Modified = item.Modified
            }).ToListAsync();
        }
    }
}
