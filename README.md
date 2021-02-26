# DabataseConnection
Web-api: connected with a SQLite database.

## Tools - Libraries for Database with EF-Core
1. https://docs.microsoft.com/en-us/ef/core/cli/dotnet // this is for install the Entity Framework CLI (global installation)
2. https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/ // this is the library for SQLite
3. https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/ //this is for use the (dotnet ef migrations add 

## Model
Person class
```c#
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseConnection.Models
{
    public class Person
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)] // for disable autogenerate Id
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string surname { get; set; }
        
        public string address { get; set; }
        
        [ForeignKey("idPerson")]
        public List<Phone> phones { get; set; }
    }
}
```

Phone Class
```c#
using System.ComponentModel.DataAnnotations;

namespace DatabaseConnection.Models
{
    public class Phone
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)] // for disable autogenerate Id
        public int id { get; set; }

        [Required]
        public int idPerson { get; set; }

        public string phoneNumber { get; set; }
    }
}
```

## Business Layer
DatabaseContext class
```c#
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
```

## Add the context in the file Startup.cs
In the method ConfigureService add the dbContex
```c#
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // Add SqliteService
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlite(Configuration.GetConnectionString("sqlite")));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "DatabaseConnection", Version = "v1"});
            });
        }
```