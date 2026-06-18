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

        public DbSet<clientes> clientes { get; set; }
        public DbSet<Produtos> produtos { get; set; }
        public DbSet<administradores> administradores  { get; set; }
        public DbSet<ItensPedidos> itensPedidos{ get; set;}
        public DbSet<Pedidos> pedidos { get; set; }
    }
}