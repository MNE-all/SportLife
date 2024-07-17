using Microsoft.EntityFrameworkCore;
using SportLife.Context.Models;

namespace SportLife.Context
{
    public class SportLifeContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseStep> ExerciseSteps { get; set; }


        public SportLifeContext(DbContextOptions<SportLifeContext> options) 
            : base(options)
        { 
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=home-server.tech;Port=5432;Database=SportLifeDev;Username=postgres;Password=QmR4uzNvgnELLP3");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
