using Microsoft.EntityFrameworkCore;
using LojaPerfume.Models;
using Perfumaria.Models;

namespace LojaPerfume.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<clientes> Clientes { get; set; }
        public DbSet<Produtos> produtos { get; set; }
        public DbSet<Admin> admin { get; set; }
    }
}