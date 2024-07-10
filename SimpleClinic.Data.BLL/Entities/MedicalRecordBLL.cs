using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll.Entities
{
    public  class MedicalRecordBLL : SharedBll
    {
        public static async void Add(AppDbContext db, MedicalRecord medicalRecord)
        {
            db.MedicalRecords.Add(medicalRecord);
            await db.SaveChangesAsync();
        }

        public static async void Update(AppDbContext db, MedicalRecord medicalRecord)
        {
            var oldMedicalRecord = await db.MedicalRecords.FirstOrDefaultAsync(mr => mr.Id == medicalRecord.Id);
            if (oldMedicalRecord == null) return;

            oldMedicalRecord.Id = medicalRecord.Id;
            oldMedicalRecord.VisitDescription = medicalRecord.VisitDescription;
            oldMedicalRecord.Diagnosis = medicalRecord.Diagnosis;
            oldMedicalRecord.AdditionalNotes = medicalRecord.AdditionalNotes;

            await db.SaveChangesAsync();
        }

        public static async void Delete(int Id)
        {
            using (var db = new AppDbContext())
            {
                var mr = await db.MedicalRecords.FirstOrDefaultAsync(m => m.Id == Id);
                if (mr == null) return;

                db.MedicalRecords.Remove(mr);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<MedicalRecord> GetMedicalRecordById(int Id)
        {
            return await Db.MedicalRecords.FirstOrDefaultAsync(mr => mr.Id == Id);
        }

        public static async Task<List<MedicalRecord>> GetAllMedicalRecords()
        {
            return await Db.MedicalRecords.ToListAsync();
        }
    }
}
