using System;
using System.Collections.Generic;
using System.Text;
using EventsPlusLTD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsPlusLTD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }

        public DbSet<ActType> ActType { get; set; }
        public DbSet<AssetsNeeded> AssetsNeeded { get; set; }
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
        public DbSet<TypeOfEvent> TypeOfEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ActType>().ToTable("Act Type");
            modelBuilder.Entity<AssetsNeeded>().ToTable("Assets Needed");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<EquipmentType>().ToTable("Equipment Type");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Organizer>().ToTable("Organizer");
            modelBuilder.Entity<OrganizerInfo>().ToTable("Organizer Information");
            modelBuilder.Entity<OrganizerRole>().ToTable("Organizer Role");
            modelBuilder.Entity<OrganizersOccupied>().ToTable("Organizers Occupied");
            modelBuilder.Entity<Participants>().ToTable("Participants");
            modelBuilder.Entity<Performance>().ToTable("Performance");
            modelBuilder.Entity<Performers>().ToTable("Performers");
            modelBuilder.Entity<TypeOfEvent>().ToTable("Type Of Event");

        }



    }


}


