using Rpg.Src.Business.Interface;
using Rpg.Src.Model;
using Rpg.Src.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg.Src.Business
{
    public class PersonagemBusiness : IPersonagemBusiness
    {
        private readonly IPersonagemRepository _personagemRepository;
        public PersonagemBusiness(IPersonagemRepository personagemRepository)
        {
            _personagemRepository = personagemRepository;
        }

        public void AdicionarPersonagem(Personagem personagem)
        {
            ValidarPontosPersonagem(personagem.Forca, personagem.Defesa);
            _personagemRepository.AdicionarPersonagem(personagem);
        }

        public string AtualizarNomeAventureiro(long id, string novoNomeAventureiro)
        {
            _personagemRepository.AtualizarNomeAventureiro(id, novoNomeAventureiro);
            return "Nome do aventureiro atualizado com sucesso!";
        }

        public Personagem ListarPersonagemPorId(long id)
        {
            var personagem = _personagemRepository.ListaPersonagem(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");
            return personagem;
        }

        public List<Personagem> ListarPersonagens()
        {
            var personagens = _personagemRepository.ListarPersonagens();
            if (personagens == null)
                throw new Exception("Nenhum personagem encontrado");
            return personagens;
        }

        public void DeletarPersonagem(long id)
        {
            var personagem = _personagemRepository.ListaPersonagem(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");
            _personagemRepository.RemoverPersonagem(id);
        }

        public long BuscarAmuletoDoPersonagem(long id)
        {
            var personagem = _personagemRepository.ListaPersonagem(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");
            return _personagemRepository.BuscarAmuletoDoPersonagem(id);
        }

        private void ValidarPontosPersonagem(int forca, int defesa)
        {
            var totalPontos = forca + defesa;

            if (totalPontos > 10)
                throw new Exception("O personagem não pode ter mais de 10 pontos de força e defesa.");
            else if (forca < 0 || defesa < 0)
                throw new Exception("O personagem não pode ter pontos negativos.");
        }
    }
}
