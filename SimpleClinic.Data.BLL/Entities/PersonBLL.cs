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
    public class PersonBLL : SharedBll
    {
        public async static void Add(AppDbContext db, Person person)
        {
            db.Persons.Add(person);
            await db.SaveChangesAsync();
        }

        public async static void Update(AppDbContext db, Person person)
        {
            var oldPerson = await db.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);

            if (oldPerson == null) return;

            oldPerson.Id = person.Id;
            oldPerson.FirstName = person.FirstName;
            oldPerson.LastName = person.LastName;
            oldPerson.DateOfBirth = person.DateOfBirth;
            oldPerson.Gendor = person.Gendor;
            oldPerson.PhoneNo = person.PhoneNo;
            oldPerson.Email = person.Email;
            oldPerson.Address = person.Address; 
            oldPerson.CreatorId = person.CreatorId;
            oldPerson.Created = person.Created;
            oldPerson.ModifierId = person.ModifierId;
            oldPerson.Modified = person.Modified;

            await db.SaveChangesAsync();
        }

        public async static void Delete(int Id)
        {
            using (var db = new AppDbContext())
            {
                var Person = await Db.Persons.FirstOrDefaultAsync(p => p.Id == Id);

                if (Person == null) return;

                db.Persons.Remove(Person);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<PersonInfo>> GetPersonInfos()
        {
            return await Db.Persons.AsNoTracking().Select(item => new PersonInfo
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                DateOfBirth = item.DateOfBirth,
                Gendor = item.Gendor,
                PhoneNo = item.PhoneNo,
                Email = item.Email,
                Address = item.Address,
                CreatorId = item.CreatorId,
                Created = item.Created,
                ModifierId = item.ModifierId,
                Modified = item.Modified
            }).ToListAsync();
        }
    }
}
