using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection.Business
{
    public class BPerson : IDisposable
    {
        private readonly DatabaseContext _db;

        public BPerson(DatabaseContext context)
        {
            _db = context;
        }
        public async Task<List<Person>> GetAll()
        {
            return await _db.Persons.Include(person => person.phones).ToListAsync();
        }

        public async Task<int> Save(Person person)
        {
            // person.phones = new List<Phone>();
            var item = await _db.Persons.AddAsync(person);
            await _db.SaveChangesAsync();
            return item.Entity.id;
        }

        public async Task<bool> Update(Person person)
        {
            var item = await _db.Persons.FirstOrDefaultAsync(p => p.id.Equals(person.id));
            if (item == null)
                return false;
            item.name = person.name;
            item.surname = person.surname;
            item.address = person.address;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Persons.FirstOrDefaultAsync(p => p.id.Equals(id));
            if (item == null)
                return false;
            _db.Persons.Remove(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
        }
    }
}