using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseConnection.Business;
using DatabaseConnection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnection.Controllers
{
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PhoneController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Phone phone)
        {
            int id;
            using (var bPhone = new BPhone(_context))
            {
                id = await bPhone.Save(phone);
            }

            return id;
        }

        [HttpDelete("id")]
        public async Task<bool> Delete(int id)
        {
            using (var bPerson = new BPerson(_context))
            {
                await bPerson.Delete(id);
            }
            return true;
        }
    }
}