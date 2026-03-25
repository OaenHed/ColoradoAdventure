using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColoradoAdventure.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int TourId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime TripDate { get; set; }

        [Range(1, 20)]
        public int NumberOfPeople { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Tour Tour { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
