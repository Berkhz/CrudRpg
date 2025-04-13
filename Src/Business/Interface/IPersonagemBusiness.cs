using Rpg.Src.Model;

namespace Rpg.Src.Business.Interface
{
    public interface IPersonagemBusiness
    {
        public void AdicionarPersonagem(Personagem personagem);
        public List<Personagem> ListarPersonagens();
        public Personagem ListarPersonagemPorId(long id);
        public string AtualizarNomeAventureiro(long id, string novoNomeAventureiro);
        public void DeletarPersonagem(long id);
        public List<ItemMagico> BuscarAmuletoDoPersonagem(long id);
    }
}
