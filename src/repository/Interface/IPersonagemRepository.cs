using System;
using System.Data.Entity;
using crud_rpg.src.model;

namespace crud_rpg.src.repository
{
	public interface IPersonagemRepository
	{
        public void AdicionarPersonagem(Personagem personagem);
		public List<Personagem> ListarPersonagens();
		public Personagem ListaPersonagem(long id);
		public Personagem AtualizarNomeAventureiro(long id);
		public void RemoverPersonagem(long id);
	}
}