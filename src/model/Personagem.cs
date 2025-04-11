using System;
namespace crud_rpg.src.model
{
	public class Personagem
	{
        private long Id { get; set; }
		private string Nome { get; set; }
		private string NomeAventureiro { get; set; }
		private Enum Classe { get; set; }
		private int Level { get; set; }
		private long ItemMagico { get; set; }
		private int Forca { get; set; }
		private int Defesa { get; set; }

        public Personagem(long id, string nome, string nomeAventureiro, Enum classe, int level, long itemMagico, int forca, int defesa)
        {
            Id = id;
            Nome = nome;
            NomeAventureiro = nomeAventureiro;
            Classe = classe;
            Level = level;
            ItemMagico = itemMagico;
            Forca = forca;
            Defesa = defesa;
        }
    }
}