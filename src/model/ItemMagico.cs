using System;
namespace crud_rpg.src.model
{
	public class ItemMagico
	{
        private long Id { get; set; }
        private string Nome { get; set; }
        private Enum TipoDoItem { get; set; }
        private int Forca { get; set; }
        private int Defesa { get; set; }

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

