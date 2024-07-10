using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll.Entities
{
    public class PrescriptionBll : SharedBll
    {
        public static async void Add(AppDbContext db, Prescription prescription)
        {
            db.Prescriptions.Add(prescription);
            await db.SaveChangesAsync();
        }

        public static async void Update(AppDbContext db, Prescription prescription)
        {
            var oldprescription = await db.Prescriptions.FirstOrDefaultAsync(p => p.Id == prescription.Id);
            if (oldprescription == null) return;

            oldprescription.Id = prescription.Id;
            oldprescription.MedicalRecordId = prescription.MedicalRecordId;
            oldprescription.MedicationName = prescription.MedicationName;
            oldprescription.Dosage = prescription.Dosage;
            oldprescription.Frequency = prescription.Frequency;
            oldprescription.StartDate = prescription.StartDate;
            oldprescription.EndDate = prescription.EndDate;
            oldprescription.SpecialInstructions = prescription.SpecialInstructions;

            await db.SaveChangesAsync();
        }

        public static async void Delete(int Id)
        {
            using(var Db = new AppDbContext())
            {
                var PrescriptionToDelete = await Db.Prescriptions.FirstOrDefaultAsync(p => p.Id == Id);
                if (PrescriptionToDelete == null) return;

                Db.Prescriptions.Remove(PrescriptionToDelete);
                await Db.SaveChangesAsync();
            }
        }

        public static async Task<Prescription> GetPrescriptionById(int Id)
        {
            return await Db.Prescriptions.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public static async Task<List<Prescription>> GetAllPrescriptionBy()
        {
            return await Db.Prescriptions.ToListAsync();
        }
    }
}
