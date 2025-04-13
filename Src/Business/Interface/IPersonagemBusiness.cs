using Rpg.Src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg.Src.Business.Interface
{
    public interface IPersonagemBusiness
    {
        public void AdicionarPersonagem(Personagem personagem);
        public List<Personagem> ListarPersonagens();
        public Personagem ListarPersonagemPorId(long id);
        public string AtualizarNomeAventureiro(long id, string novoNomeAventureiro);
        public void DeletarPersonagem(long id);
        public long BuscarAmuletoDoPersonagem(long id);
    }
}
