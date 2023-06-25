using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Typee> Types { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventParticipant> EventsParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Typee>()
                .HasData(new Typee()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Typee()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Typee()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Typee()
                {
                    Id = 4,
                    Name = "Work"
                });

            modelBuilder.Entity<EventParticipant>()
               .HasKey(x => new { x.EventId, x.HelperId });

            modelBuilder.Entity<Event>()
              .HasMany(e => e.EventsParticipants)
              .WithOne(ep => ep.Event)
              .HasForeignKey(ep => ep.EventId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(e => e.EventsParticipants)
                .HasForeignKey(ep => ep.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}