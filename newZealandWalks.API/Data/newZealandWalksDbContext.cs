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

            // Seed (populate) data for Difficulty-table (these values "never") 

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

            // Seed/populate data for Regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("3893d6b8-f8f1-4e50-85d2-bfeb4a880a3f"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://dummyUrl.com/auckland"
                },
                new Region()
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new() // IDE vet at obj = Region (var regions = new List<Region>) 
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new()
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://dummyUrl.com/wellington"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://dummyUrl.com/nelson"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}