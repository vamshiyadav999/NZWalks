using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext: DbContext 
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding the data for difficulties
            //Easy, medium and hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("077d5b86-b89c-41c3-83d3-71f6cede5aa2"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("38366b78-5f37-4079-aa37-b7ce3face9f8"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("63912060-f0b2-4926-a971-c54bee89074e"),
                    Name = "Hard"
                }
            };
            // Operation Enables in Seeding difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed Data for Regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("9e9c14f1-b4f1-44f9-ab98-bff2faa0bd2a"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "179003-North-Island.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("d9d3c9d5-9ac5-4c47-9f8e-cd4c0b1fdb61"),
                    Name = "Wellington",
                    Code = "WEL",
                    RegionImageUrl = null 
                },
                new Region()
                {
                    Id = Guid.Parse("74f9d399-c607-45bb-a3f2-f7e5f28c9a7d"),
                    Name = "Christchurch",
                    Code = "CHC",
                    RegionImageUrl = "christchurch-image.jpg" 
                },
                new Region()
                {
                    Id = Guid.Parse("5f23a7a3-756f-4415-b81a-392ea1f74b88"),
                    Name = "Dunedin",
                    Code = "DUN",
                    RegionImageUrl = null  
                },
                new Region()
                {
                    Id = Guid.Parse("0cb89754-9bbf-49b9-a674-4de2b9d7ed16"),
                    Name = "Hamilton",
                    Code = "HAM",
                    RegionImageUrl = "hamilton-region-image.jpg"  
                }
            };
            // Operation Enables in Seeding Regions to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
