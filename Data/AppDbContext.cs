using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Models;

namespace OnlineVoting.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserElection>().HasKey(ue => new { ue.UserId,ue.ElectionId});
            modelBuilder.Entity<UserElection>()
            .HasOne<ApplicationUser>(sc => sc.User)
            .WithMany(s => s.UserElections)
            .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserElection>()
                .HasOne<Election>(sc => sc.Election)
                .WithMany(s => s.UserElections)
                .HasForeignKey(sc => sc.ElectionId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet <Election> Elections { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<UserElection> UserElections { get; set; }
    }
}
