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