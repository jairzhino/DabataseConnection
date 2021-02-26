using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseConnection.Business;
using DatabaseConnection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnection.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PersonController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            List<Person> list;
            using (var bPerson = new BPerson(_context))
            {
                list = await bPerson.GetAll();
            }

            return list;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Person person)
        {
            int id;
            using (var bPerson = new BPerson(_context))
            {
                id = await bPerson.Save(person);
            }

            return id;
        }
        [HttpPut]
        public async Task<bool> Put([FromBody] Person person)
        {
            using (var bPerson = new BPerson(_context))
            {
                await bPerson.Update(person);
            }
            return true;
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