using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _77CarRental.Models
{
    public class Users : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public ICollection<Review> Reviews { get; set; }


    }
}
