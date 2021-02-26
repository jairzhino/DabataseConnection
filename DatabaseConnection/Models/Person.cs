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