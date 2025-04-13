using Rpg.Src.Model;

namespace Rpg.Src.Dto
{
    public class PersonagemDto
    {
        public string Nome { get; set; }
        public string NomeAventureiro { get; set; }
        public Personagem.ClassePersonagem Classe { get; set; }
        public int Level { get; set; }
        public List<long> ItensMagicos { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
    }
}
