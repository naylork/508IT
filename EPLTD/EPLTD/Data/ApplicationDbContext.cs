using System;
using System.Collections.Generic;
using System.Text;
using EPLTD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPLTD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ActType> ActType { get; set; }
        public DbSet<AssetsNeeded> AssetsNeeded { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentType> EquipmentType { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<OrganizerInfo> OrganizerInfo { get; set; }
        public DbSet<OrganizerRole> OrganizerRole { get; set; }
        public DbSet<OrganizersOccupied> OrganizersOccupied { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<Performers> Performers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ActType>().ToTable("ActType");
            modelBuilder.Entity<AssetsNeeded>().ToTable("AssetsNeeded");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<EquipmentType>().ToTable("EquipmentType");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Location>().ToTable("EventLocation");
            modelBuilder.Entity<Organizer>().ToTable("Organizer");
            modelBuilder.Entity<OrganizerInfo>().ToTable("OrganizerInformation");
            modelBuilder.Entity<OrganizerRole>().ToTable("OrganizerRole");
            modelBuilder.Entity<OrganizersOccupied>().ToTable("OrganizersOccupied");
            modelBuilder.Entity<Participants>().ToTable("Participants");
            modelBuilder.Entity<Performance>().ToTable("Performance");
            modelBuilder.Entity<Performers>().ToTable("Performers");

        }
    }
}
