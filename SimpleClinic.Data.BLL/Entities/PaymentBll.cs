using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll.Entities
{
    public class PaymentBll : SharedBll
    {
        public static async void Add(AppDbContext db, Payment payment)
        {
            db.Payments.Add(payment);
            await db.SaveChangesAsync();
        }

        public static async void Update(AppDbContext db, Payment payment)
        {
            var oldPayment = await db.Payments.FirstOrDefaultAsync(x => x.Id == payment.Id);
            if (oldPayment == null) return;

            oldPayment.Id = payment.Id;
            oldPayment.PaymentDate = payment.PaymentDate;
            oldPayment.PaymentMethod = payment.PaymentMethod;   
            oldPayment.AmountPaid = payment.AmountPaid;
            oldPayment.AdditionalNotes = payment.AdditionalNotes;

            await db.SaveChangesAsync();
        }

        public static async void Delete(int Id)
        {
            using (var db = new AppDbContext())
            {
                var payment = await db.Payments.FirstOrDefaultAsync(p => p.Id == Id);
                if (payment == null) return;

                db.Payments.Remove(payment);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<Payment> GetPaymentById(int Id)
        {
            return await Db.Payments.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public static async Task<List<Payment>> GetAllPayments()
        {
            return await Db.Payments.ToListAsync();
        }
    }
}
