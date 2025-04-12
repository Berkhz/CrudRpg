using System;
namespace crud_rpg.src.model
{
	public class ItemMagico
	{
        public long Id { get; set; }
        public string Nome { get; set; }
        public Enum TipoDoItem { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }

        public ItemMagico(long id, string nome, Enum tipoDoItem, int forca, int defesa)
        {
            Id = id;
            Nome = nome;
            TipoDoItem = tipoDoItem;
            Forca = forca;
            Defesa = defesa;
        }
	}
}

