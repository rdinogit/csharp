using CsharpKT.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace CsharpKTApi.Persistence
{
    public class CsharpDbContext : DbContext
    {
        public CsharpDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
    }
}
