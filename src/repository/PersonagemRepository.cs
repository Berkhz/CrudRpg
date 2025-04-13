using Rpg.Src.Context;
using Rpg.Src.@enum;
using Rpg.Src.Model;
using Microsoft.EntityFrameworkCore;

namespace Rpg.Src.repository
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly RpgContext _context;

        public PersonagemRepository(RpgContext context)
        {
            _context = context;
        }

        public void AdicionarPersonagem(Personagem personagem)
        {
            _context.Personagem.Add(personagem);
            _context.SaveChanges();
        }

        public string AtualizarNomeAventureiro(long id, string novoNomeAventureiro)
        {
            var personagem = _context.Personagem.Find(id);

            if (personagem == null)
                throw new Exception("Não foi possível atualizar o nome pois o personagem informado não foi encontrado.");

            personagem.NomeAventureiro = novoNomeAventureiro;
            _context.SaveChanges();
            return personagem.NomeAventureiro;
        }

        public Personagem ListaPersonagem(long id)
        {
            var personagem = _context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            return personagem;
        }

        public List<Personagem> ListarPersonagens()
        {
            var personagens = _context.Personagem
                .Include(p => p.ItensMagicos)
                .ToList();

            if (personagens == null || personagens.Count == 0)
                throw new Exception("Nenhum personagem encontrado");

            return personagens;
        }

        public void RemoverPersonagem(long id)
        {
            var personagem = _context.Personagem.Find(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            _context.Personagem.Remove(personagem);
            _context.SaveChanges();
        }

        public List<ItemMagico> BuscarAmuletoDoPersonagem(long id)
        {
            var personagem = _context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            return personagem.ItensMagicos
                .Where(item => item.TipoDoItem == TipoItem.Amuleto)
                .ToList();
        }
    }
}