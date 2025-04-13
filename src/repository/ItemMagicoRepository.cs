using Rpg.Src.Context;
using Rpg.Src.@enum;
using Rpg.Src.Model;
using Rpg.Src.repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Rpg.Src.repository
{
    public class ItemMagicoRepository : IItemMagicoRepository
    {
        private readonly RpgContext _context;

        public ItemMagicoRepository(RpgContext context)
        {
            _context = context;
        }

        public void AdicionarItemMagico(ItemMagico itemMagico)
        {
            _context.ItemMagico.Add(itemMagico);
            _context.SaveChanges();
        }

        public void AdicionarItemMagicoAoPersonagem(long id, long idItemMagico)
        {
            var personagem = _context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = _context.ItemMagico.Find(idItemMagico);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            personagem.ItensMagicos ??= new List<ItemMagico>();

            if (itemMagico.TipoDoItem == TipoItem.Amuleto &&
                personagem.ItensMagicos.Any(i => i.TipoDoItem == TipoItem.Amuleto))
                throw new Exception("O personagem já possui um amuleto");

            personagem.ItensMagicos.Add(itemMagico);
            _context.SaveChanges();
        }

        public ItemMagico ListaItemMagico(long id)
        {
            var itemMagico = _context.ItemMagico.Find(id);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            return itemMagico;
        }

        public List<ItemMagico> ListarItemMagicoPorPersonagem(long id, long idItemMagico)
        {
            var personagem = _context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itensMagicos = personagem.ItensMagicos
                .Where(i => i.Id == idItemMagico)
                .ToList();

            if (itensMagicos.Count == 0)
                throw new Exception("Item mágico não encontrado para este personagem");

            return itensMagicos;
        }

        public List<ItemMagico> ListarItensMagicos()
        {
            return _context.ItemMagico.ToList();
        }

        public void RemoverItemMagicoDoPeronagem(long id, long idItemMagico)
        {
            var personagem = _context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = personagem.ItensMagicos.FirstOrDefault(i => i.Id == idItemMagico);
            if (itemMagico == null)
                throw new Exception("Item mágico não está associado a este personagem");

            personagem.ItensMagicos.Remove(itemMagico);
            _context.SaveChanges();
        }
    }
}
