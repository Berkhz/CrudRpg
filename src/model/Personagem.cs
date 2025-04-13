namespace Rpg.Src.Model
{
	public class Personagem
	{
        public long Id { get; set; }
        public string Nome { get; set; }
        public string NomeAventureiro { get; set; }
        public enum ClassePersonagem { Guerreiro, Mago, Arqueiro, Ladino, Bardo }
        public ClassePersonagem Classe { get; set; }
        public int Level { get; set; }
        public List<ItemMagico> ItensMagicos { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }

        public Personagem() { }

        public Personagem(long id, string nome, string nomeAventureiro, ClassePersonagem classe, int level, List<ItemMagico> itensMagicos, int forca, int defesa)
        {
            Id = id;
            Nome = nome;
            NomeAventureiro = nomeAventureiro;
            Classe = classe;
            Level = level;
            ItensMagicos = itensMagicos;
            Forca = forca;
            Defesa = defesa;
        }
    }
}