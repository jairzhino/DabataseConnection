using System;
using System.Threading.Tasks;
using DatabaseConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection.Business
{
    public class BPhone:IDisposable
    {
        private readonly DatabaseContext _db;

        public BPhone(DatabaseContext context)
        {
            _db = context;
        }

        public async Task<int> Save(Phone phone)
        {
            var item = await _db.Phones.AddAsync(phone);
            await _db.SaveChangesAsync();
            return item.Entity.id;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Phones.FirstOrDefaultAsync(phone => phone.id.Equals(id));
            if (item == null)
                return false;
            _db.Phones.Remove(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}