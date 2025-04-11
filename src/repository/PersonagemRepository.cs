using System;
using System.Data.Entity;
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

        public Personagem AtualizarNomeAventureiro(long id)
        {
            throw new NotImplementedException();
        }

        public Personagem ListaPersonagem(long id)
        {
            throw new NotImplementedException();
        }

        public List<Personagem> ListarPersonagens()
        {
            throw new NotImplementedException();
        }

        public void RemoverPersonagem(long id)
        {
            throw new NotImplementedException();
        }
    }
}

