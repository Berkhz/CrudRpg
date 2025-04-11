using System.Data.Entity;
using crud_rpg.src.model;

namespace crud_rpg.src.context
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

