using Rpg.Src.Model;

namespace Rpg.Src.repository
{
	public interface IPersonagemRepository
	{
        public void AdicionarPersonagem(Personagem personagem);
		public List<Personagem> ListarPersonagens();
		public Personagem ListaPersonagem(long id);
		public string AtualizarNomeAventureiro(long id, string novoNomeAventureiro);
		public void RemoverPersonagem(long id);
        public List<ItemMagico> BuscarAmuletoDoPersonagem(long id);
    }
}