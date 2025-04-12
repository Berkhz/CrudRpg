using System;
namespace crud_rpg.src.model
{
	public class Personagem
	{
        public long Id { get; set; }
        public string Nome { get; set; }
        public string NomeAventureiro { get; set; }
        public Enum Classe { get; set; }
        public int Level { get; set; }
        public long ItemMagico { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }

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