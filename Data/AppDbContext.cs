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

            base.OnModelCreating(modelBuilder);
        }
        public DbSet <Election> Elections { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
