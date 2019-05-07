using Domain;
using Domain.Animals;
using Domain.Map;
using Domain._Shared.Statuses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<StatusInMapSegment> StatusInMapSegment { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<ConservationStatus> ConservationStatus { get; set; }
        public DbSet<MediaInAnimal> MediaInAnimal { get; set; }
        public DbSet<ScientificClassification> ScientificClassification { get; set; }
        public DbSet<AppMap> AppMap { get; set; }
        public DbSet<MapSegment> MapSegment { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<SoundTrack> SoundTrack { get; set; }
        public DbSet<SoundTrackInAnimal> SoundTrackInAnimal { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.MapSegment)
                .WithOne(a => a.Animal)
                .HasForeignKey<MapSegment>(c => c.AnimalId);
        }

    }
}