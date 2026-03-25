using ColoradoAdventure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ColoradoAdventure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tour>().HasData(
                new Tour { Id = 1, Name = "Colorado River Float Trip", Description = "Perfect for families and first-time kayakers, this gentle float along the Colorado River offers stunning red rock scenery and calm waters. No experience necessary!", Difficulty = Difficulty.Beginner, Price = 49m, Duration = "3 Hours", MaxCapacity = 15, ImageUrl = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=800", Rating = 4.8m, CreatedDate = new DateTime(2024, 1, 1), IsActive = true },
                new Tour { Id = 2, Name = "Grand Canyon Day Trip", Description = "Experience the grandeur of the Grand Canyon from the water. This intermediate paddle takes you through some of the most breathtaking scenery on earth with exciting rapids.", Difficulty = Difficulty.Intermediate, Price = 129m, Duration = "6 Hours", MaxCapacity = 10, ImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800", Rating = 4.9m, CreatedDate = new DateTime(2024, 1, 2), IsActive = true },
                new Tour { Id = 3, Name = "Westwater Canyon Whitewater", Description = "One of the most thrilling whitewater runs in the American West. Westwater Canyon features Class III-IV rapids through a narrow, deep gorge carved in ancient black schist.", Difficulty = Difficulty.Advanced, Price = 179m, Duration = "Full Day", MaxCapacity = 8, ImageUrl = "https://images.unsplash.com/photo-1530866495561-507c9faab2ed?w=800", Rating = 4.7m, CreatedDate = new DateTime(2024, 1, 3), IsActive = true },
                new Tour { Id = 4, Name = "Cataract Canyon Expedition", Description = "A legendary multi-day adventure through Cataract Canyon in Canyonlands National Park. Experience over 25 rapids including some of the biggest whitewater in North America.", Difficulty = Difficulty.Expert, Price = 299m, Duration = "3 Days", MaxCapacity = 6, ImageUrl = "https://images.unsplash.com/photo-1504280390367-361c6d9f38f4?w=800", Rating = 5.0m, CreatedDate = new DateTime(2024, 1, 4), IsActive = true },
                new Tour { Id = 5, Name = "Glenwood Canyon Paddle", Description = "Paddle through the spectacular Glenwood Canyon, one of Colorado's most dramatic river corridors. This scenic beginner trip offers beautiful limestone walls and calm waters.", Difficulty = Difficulty.Beginner, Price = 59m, Duration = "4 Hours", MaxCapacity = 12, ImageUrl = "https://images.unsplash.com/photo-1569949381669-ecf31ae8e613?w=800", Rating = 4.6m, CreatedDate = new DateTime(2024, 1, 5), IsActive = true },
                new Tour { Id = 6, Name = "Ruby-Horsethief Canyon", Description = "A stunning one-day journey through Ruby and Horsethief Canyons, featuring towering red sandstone walls, desert wildlife, and ancient petroglyphs. A true Colorado River gem.", Difficulty = Difficulty.Intermediate, Price = 89m, Duration = "1 Day", MaxCapacity = 10, ImageUrl = "https://images.unsplash.com/photo-1501854140801-50d01698950b?w=800", Rating = 4.7m, CreatedDate = new DateTime(2024, 1, 6), IsActive = true },
                new Tour { Id = 7, Name = "Desolation Canyon Multi-Day", Description = "Journey through one of the largest roadless areas in the lower 48 states. This incredible 5-day expedition through Desolation and Gray Canyons offers unparalleled solitude.", Difficulty = Difficulty.Intermediate, Price = 249m, Duration = "5 Days", MaxCapacity = 8, ImageUrl = "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?w=800", Rating = 4.9m, CreatedDate = new DateTime(2024, 1, 7), IsActive = true },
                new Tour { Id = 8, Name = "Gore Canyon Extreme", Description = "For expert kayakers only. Gore Canyon on the upper Colorado River features relentless Class V rapids through a spectacular granite gorge. One of Colorado's most challenging runs.", Difficulty = Difficulty.Expert, Price = 199m, Duration = "Full Day", MaxCapacity = 4, ImageUrl = "https://images.unsplash.com/photo-1519451241324-20b4ea2c4220?w=800", Rating = 4.8m, CreatedDate = new DateTime(2024, 1, 8), IsActive = true },
                new Tour { Id = 9, Name = "Colorado River Sunset Tour", Description = "End your day with a magical sunset paddle on the Colorado River. This short but breathtaking tour offers golden hour lighting on the red canyon walls - perfect for photography.", Difficulty = Difficulty.Beginner, Price = 79m, Duration = "2 Hours", MaxCapacity = 15, ImageUrl = "https://images.unsplash.com/photo-1500534314209-a25ddb2bd429?w=800", Rating = 4.9m, CreatedDate = new DateTime(2024, 1, 9), IsActive = true },
                new Tour { Id = 10, Name = "Black Rocks Kayak Adventure", Description = "Explore the dramatic Black Rocks section of the Colorado River near Grand Junction. This half-day adventure features fun Class II-III rapids and stunning dark volcanic formations.", Difficulty = Difficulty.Intermediate, Price = 99m, Duration = "Half Day", MaxCapacity = 10, ImageUrl = "https://images.unsplash.com/photo-1506197603052-3cc9c3a201bd?w=800", Rating = 4.6m, CreatedDate = new DateTime(2024, 1, 10), IsActive = true }
            );
        }
    }
}
