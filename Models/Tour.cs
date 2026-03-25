using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColoradoAdventure.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public Difficulty Difficulty { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [StringLength(100)]
        public string Duration { get; set; } = string.Empty;

        public int MaxCapacity { get; set; }

        public string? ImageUrl { get; set; }

        [Column(TypeName = "decimal(3,1)")]
        public decimal Rating { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
