using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexts
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) 
        : base(options) { }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Speaker> Speaker { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvent { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        
        // Associação entre evento e palestrante no banco de dados
        // Association between event and speaker in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(SE => new {SE.EventId, SE.SpeakerId});

            modelBuilder.Entity<Event>()
            .HasMany(e => e.SocialMedias)
            .WithOne(sm => sm.Event)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
            .HasMany(s => s.SocialMedias)
            .WithOne(sm => sm.Speaker)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}