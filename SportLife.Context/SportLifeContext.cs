using Microsoft.EntityFrameworkCore;
using SportLife.Context.Models;

namespace SportLife.Context
{
    public class SportLifeContext : DbContext
    {
        DbSet<Record> Records { get; set; }
        DbSet<User> Users { get; set; }

    }
}
