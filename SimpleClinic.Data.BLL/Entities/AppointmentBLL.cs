using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.EntitesInfos;
using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll.Entities
{
    public class AppointmentBLL : SharedBll
    {
        public async static void Add(AppDbContext db, Appointment appointment)
        {
            db.Appointments.Add(appointment);
            await db.SaveChangesAsync();
        }

        public async static void Update(AppDbContext db, Appointment appointment)
        {
            var oldAppointment = db.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (oldAppointment == null) return;

            oldAppointment.Id = appointment.Id;
            oldAppointment.PatientId = appointment.PatientId;
            oldAppointment.DoctorId = appointment.DoctorId; 
            oldAppointment.AppointmentDate = appointment.AppointmentDate;
            oldAppointment.AppointmentStatus = appointment.AppointmentStatus;   
            oldAppointment.MedicalRecordId = appointment.MedicalRecordId;
            oldAppointment.PaymentId = appointment.PaymentId;   
            oldAppointment.CreatorId = appointment.CreatorId;
            oldAppointment.Created = appointment.Created;
            oldAppointment.ModifierId = appointment.ModifierId;
            oldAppointment.Modified = appointment.Modified; 

            await db.SaveChangesAsync();
        }

        public async static void Delete(Appointment appointment)
        {
            using (var db = new AppDbContext())
            {
                var ToDeleteAppointment = db.Appointments.FirstOrDefault(a => a.Id == appointment.Id); 
                if (ToDeleteAppointment == null) return;

                db.Appointments.Remove(ToDeleteAppointment);
                await db.SaveChangesAsync();
            }
        }

        public async static Task<AppointmentInfo> GetAppointmentByIdNoTracking(AppDbContext Db, int Id)
        {
            return await Db.Appointments.AsNoTracking().Where(x => x.Id == Id).Select(item => new AppointmentInfo
            {
                Id = item.Id,
                Patient = item.Patient.Person.FullName(),
                PatientPhoneNo = item.Patient.Person.PhoneNo,
                Doctor = item.Doctor.Person.FullName(),
                DoctorPhoneNo = item.Doctor.Person.PhoneNo,
                AppointmentDate = item.AppointmentDate,
                AppointmentStatus = item.AppointmentStatus,
                MedicalRecord = item.MedicalRecord,
                Payment = item.Payment,
                Creator = item.Creator.Username,
                Created = item.Created,
                Modifier = item.Modifier.Username,
                Modified = item.Modified
            }).FirstOrDefaultAsync();
        }

        public async static Task<Appointment> GetAppointmentById(AppDbContext Db, int Id)
        {
            return await Db.Appointments.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<AppointmentInfo>> GetAppointments()
        {
            return await Db.Appointments.AsNoTracking().Select(item => new AppointmentInfo
            {
                Id = item.Id,
                Patient = item.Patient.Person.FullName(),
                PatientPhoneNo = item.Patient.Person.PhoneNo,
                Doctor = item.Doctor.Person.FullName(),
                DoctorPhoneNo = item.Doctor.Person.PhoneNo,
                AppointmentDate = item.AppointmentDate,
                AppointmentStatus = item.AppointmentStatus,
                MedicalRecord = item.MedicalRecord,
                Payment = item.Payment,
                Creator = item.Creator.Username,
                Created = item.Created,
                Modifier = item.Modifier.Username,
                Modified = item.Modified
            }).ToListAsync();
        }

    }
}
