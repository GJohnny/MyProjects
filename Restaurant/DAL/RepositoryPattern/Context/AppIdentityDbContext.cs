using DAL.RepositoryPattern.Entities;
using DAL.RepositoryPattern.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.RepositoryPattern.Context
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SingerBranch>()
                .HasKey(sb => new { sb.BranchId, sb.SingerId });

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Tables).WithOne(t => t.Branch);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reserves).WithOne(r => r.User);
            modelBuilder.Entity<Table>()
                .HasMany(t => t.Reserves).WithOne(r => r.Table);

            modelBuilder.Entity<Menu>()
                .Property(menu => menu.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
        public new DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Menu> MenuItems { get; set; }
        public DbSet<SingerBranch> SingerBranches { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
    }
}
