using Microsoft.EntityFrameworkCore;
using Rpg.Src.Model;

namespace Rpg.Src.Context
{
    public class RpgContext : DbContext
    {
        public RpgContext(DbContextOptions<RpgContext> options) : base(options) { }

        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<ItemMagico> ItemMagico { get; set; }
    }
}

