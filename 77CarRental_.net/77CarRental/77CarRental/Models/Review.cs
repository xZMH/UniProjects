using System.ComponentModel.DataAnnotations;

namespace _77CarRental.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Comment { get; set; }

        public DateTime? ReviewDate { get; set; }

        public Reservation Reservation { get; set; }

        public string? AppUserID { get; set; }
    }
}
