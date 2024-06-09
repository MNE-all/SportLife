using Microsoft.EntityFrameworkCore;
using SportLife.Context.Models;

namespace SportLife.Context
{
    public class SportLifeContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<User> Users { get; set; }


        public SportLifeContext(DbContextOptions<SportLifeContext> options) 
            : base(options)
        { 
            Database.EnsureCreated();
        }
    }
}
