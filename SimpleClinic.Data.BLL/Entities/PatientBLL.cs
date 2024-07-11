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
    public class PatientBLL : SharedBll
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

        //public async static Task<Patient> GetPatientById(int Id)
        //{
        //    return await Db.Patients.FirstOrDefaultAsync(p => p.Id == Id);    
        //}

        public  static Patient GetPatientById(int Id)
        {
            return  Db.Patients.Include(p => p.Person).FirstOrDefault(p => p.Id == Id);
        }

        public async static Task<List<PatientInfo>> GetAllPatients()
        {
            return await Db.Patients.Select(item => new PatientInfo
            {
                Id = item.Id,
                PersonId = item.PersonId,
                FirstName = item.Person.FirstName,
                LastName = item.Person.LastName,
                DateOfBirth = item.Person.DateOfBirth,
                Gendor = item.Person.Gendor,
                PhoneNo = item.Person.PhoneNo,
                Email = item.Person.Email,
                Address = item.Person.Address,
                CreatorId = item.CreatorId,
                Creator = item.Creator.Username,
                Created = item.Created,
                Modified = item.Modified,
                Modifier = item.Modifier.Username,
                ModifierId = item.ModifierId,
            }).ToListAsync();
        }
    }
}
