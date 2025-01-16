using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _77CarRental.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } // Removed nullable, since [Required] is used

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; } // Removed nullable

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } // Removed nullable

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(25, ErrorMessage = "Phone number cannot be longer than 25 characters.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } // Removed nullable

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();


        // Add a FullName property if it doesn't exist
        [NotMapped] // This makes sure EF Core doesn't try to map this to your database
        public string FullName => $"{FirstName} {LastName}";
    }
}

