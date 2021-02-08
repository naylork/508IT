using System;
using System.Collections.Generic;
using System.Text;
using EventsPlus.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsPlus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<AT> ActType { get; set; }
        public DbSet<AN> AssetsNeeded { get; set; }
        public DbSet<Cust> Customer { get; set; }
        public DbSet<EventLoc> EventLocation { get; set; }
        public DbSet<Equip> Equipment { get; set; }
        public DbSet<EquipType> EquipmentType { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Organizers> Organizer { get; set; }
        public DbSet<OrgInfo> OrganizerInfo { get; set; }
        public DbSet<OrgRole> OrganizerRole { get; set; }
        public DbSet<OrgOcc> OrganizersOccupied { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<Performers> Performers { get; set; }
        public DbSet<TOE> TypeOfEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AT>().ToTable("ActType");
            modelBuilder.Entity<AN>().ToTable("AssetsNeeded");
            modelBuilder.Entity<Cust>().ToTable("Customer");
            modelBuilder.Entity<Equip>().ToTable("Equipment");
            modelBuilder.Entity<EquipType>().ToTable("EquipmentType");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<EventLoc>().ToTable("EventLocation");
            modelBuilder.Entity<Organizers>().ToTable("Organizer");
            modelBuilder.Entity<OrgInfo>().ToTable("OrganizerInformation");
            modelBuilder.Entity<OrgRole>().ToTable("OrganizerRole");
            modelBuilder.Entity<OrgOcc>().ToTable("OrganizersOccupied");
            modelBuilder.Entity<Participants>().ToTable("Participants");
            modelBuilder.Entity<Performance>().ToTable("Performance");
            modelBuilder.Entity<Performers>().ToTable("Performers");
            modelBuilder.Entity<TOE>().ToTable("TypeOfEvent");

            modelBuilder.Entity<Event>().HasKey(c => new { c.TypeOfEventID });
            modelBuilder.Entity<EventLoc>().HasKey(c => new { c.EventID });
            modelBuilder.Entity<Cust>().HasKey(c => new { c.EventID });
            modelBuilder.Entity<Performance>().HasKey(c => new { c.EventID });
            modelBuilder.Entity<OrgOcc>().HasKey(c => new { c.PerformanceID, c.OrganizerID });
            modelBuilder.Entity<Participants>().HasKey(c => new { c.PerformanceID, c.PerformerID });
            modelBuilder.Entity<AN>().HasKey(c => new { c.PerformanceID, c.EquipmentID });
            modelBuilder.Entity<Performers>().HasKey(c => new { c.ActTypeID });
            modelBuilder.Entity<Equip>().HasKey(c => new { c.EquipmentTypeID });
            modelBuilder.Entity<OrgOcc>().HasKey(c => new { c.OrganizerID, c.PerformanceID });
            modelBuilder.Entity<Organizers>().HasKey(c => new { c.OrganizerInfoID, c.OrganizerRoleID });
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
