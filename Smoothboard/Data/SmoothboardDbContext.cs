using Microsoft.EntityFrameworkCore;
using Smoothboard.Models.Domain;

namespace Smoothboard.Data
{
    public class SmoothboardDbContext : DbContext
    {
        public SmoothboardDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }
    }
}
