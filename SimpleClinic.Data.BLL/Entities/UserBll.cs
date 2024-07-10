using SimpleClinic.Data.Layers;
using SimpleClinic.Data.Layers.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
namespace SimpleClinic.Data.Bll.Entities
{
    public class UserBll : SharedBll
    {
        public static async void Add(AppDbContext db, User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public static async void Update(AppDbContext db, User user)
        {
            var oldUser = db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (oldUser == null) return;


        }

        public static async void Delete(int Id)
        {
            using(var db = new AppDbContext())
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Id == Id);
                if (user == null) return;

                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<User> GetUserById(int Id)
        {
            return await Db.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public static async Task<List<User>> GetAllUsers()
        {
            return await Db.Users.ToListAsync();
        }
    }
}
