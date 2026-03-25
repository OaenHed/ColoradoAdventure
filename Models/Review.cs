using System;
using System.ComponentModel.DataAnnotations;

namespace ColoradoAdventure.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int TourId { get; set; }

        public string UserId { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Tour Tour { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
