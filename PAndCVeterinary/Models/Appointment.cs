using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAndCVeterinary.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //Should this be Distinct? Or allow multiple appointments at the same time in the case of multiple doctors.
        public DateTime AppointmentTime { get; set; }
        [Required]
        public string FirstName { get; set; }
        //Considered making last name required, but what about Cher or the Emperor of Japan?
        public string LastName { get; set; }
        public string? PetName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string? PhoneNumber { get; set; } 
        public string? EmailAddress { get; set; }
        public string? Reason { get; set; }
    }
}
