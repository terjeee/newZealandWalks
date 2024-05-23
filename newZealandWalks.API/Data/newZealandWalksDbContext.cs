using Microsoft.EntityFrameworkCore;
using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Data
{
    public class newZealandWalksDbContext : DbContext
    {
        public newZealandWalksDbContext(DbContextOptions<newZealandWalksDbContext> options) : base(options)
        {
            // Constructor body
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed (populate) data for difficulties - these values "never" changes
            // easy, medium, hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("4003444c-5939-4920-88f0-e7f122d6d168"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("d1d455a9-4b90-4eab-9380-1996a5fc6d35"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("8e716e7c-9018-4e57-bfa4-aef9b1d8c6ce"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}