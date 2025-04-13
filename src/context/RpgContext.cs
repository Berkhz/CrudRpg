using System.Data.Entity;
using Rpg.Src.Model;

namespace Rpg.Src.Context
{
    public class RpgContext : DbContext
	{
		public DbSet<Personagem> Personagem { get; set; }
		public DbSet<ItemMagico> ItemMagico { get; set; }

        public RpgContext() : base("TB_RPG")
		{
		}
	}
}

