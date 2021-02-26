using DatabaseConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection.Business
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}