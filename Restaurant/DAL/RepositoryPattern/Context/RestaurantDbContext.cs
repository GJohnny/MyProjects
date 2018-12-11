using DAL.RepositoryPattern.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.RepositoryPattern.Context
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SingerBranch>()
                .HasKey(sb => new { sb.BranchID, sb.SingerID });

            modelBuilder.Entity<Menu>()
                .Property(menu => menu.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Menu> MenuItems { get; set; }
        public DbSet<SingerBranch> SingerBranches { get; set; }

    }
}
