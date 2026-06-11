using Microsoft.EntityFrameworkCore;
using LojaPerfume.Models;

namespace LojaPerfume.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<clientes> Clientes { get; set; }
    }
}