using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PåPinden.Components.Models;

namespace PåPinden.Components.Data
{
    public class PaaPindenDbContext : IdentityDbContext<ApplicationUser>
    {
        public PaaPindenDbContext(DbContextOptions<PaaPindenDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Follow> Follows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfigurer Follows-tabellen til at undgå cascade-delete konflikter
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Follows)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict); //Tillader ikke automatisk sletning

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}