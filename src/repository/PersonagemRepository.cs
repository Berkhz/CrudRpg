using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using crud_rpg.src.context;
using crud_rpg.src.model;

namespace crud_rpg.src.repository
{
    public class PersonagemRepository : IPersonagemRepository
    {
        public void AdicionarPersonagem(Personagem personagem)
        {
            using var context = new RpgContext();
            context.Personagem.Add(personagem);
            context.SaveChanges();
        }

        public Personagem AtualizarNomeAventureiro(long id, string novoNomeAventureiro)
        {
            using var context = new RpgContext();
            var personagem = context.Personagem.Find(id);

            if (personagem == null)
                throw new Exception("Não foi possível atualizar o nome pois o personagem informado não foi encontrado.");

            personagem.NomeAventureiro = novoNomeAventureiro;
            return personagem;
        }

        public Personagem ListaPersonagem(long id)
        {
            using var context = new RpgContext();
            var personagem = context.Personagem.Find(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");
            return personagem;
        }

        public List<Personagem> ListarPersonagens()
        {
            using var context = new RpgContext();
            var personagens = context.Personagem.ToList();
            if (personagens == null)
                throw new Exception("Nenhum personagem encontrado");
            return personagens;
        }

        public void RemoverPersonagem(long id)
        {
            using var context = new RpgContext();
            context.Personagem.Remove(context.Personagem.Find(id));
            context.SaveChanges();
        }

        public long BuscarAmuletoDoPersonagem(long id)
        {
            using var context = new RpgContext();
            var personagem = context.Personagem.Add(context.Personagem.Find(id));
            return personagem.ItemMagico;
        }
    }
}

