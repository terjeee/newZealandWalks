﻿using Microsoft.EntityFrameworkCore;
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

    }
}