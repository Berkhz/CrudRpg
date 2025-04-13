using Rpg.Src.@enum;

namespace Rpg.Src.Model
{
	public class ItemMagico
	{
        public long Id { get; set; }
        public string Nome { get; set; }
        public TipoItem TipoDoItem { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }

        public ItemMagico() {}

        public ItemMagico(long id, string nome, TipoItem tipoDoItem, int forca, int defesa)
        {
            Id = id;
            Nome = nome;
            TipoDoItem = tipoDoItem;
            Forca = forca;
            Defesa = defesa;
        }
	}
}

