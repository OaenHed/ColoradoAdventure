using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ColoradoAdventure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Bio { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
