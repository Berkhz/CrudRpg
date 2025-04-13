using Rpg.Src.Context;
using Rpg.Src.@enum;
using Rpg.Src.Model;
using Rpg.Src.repository.Interface;
using Microsoft.EntityFrameworkCore

namespace Rpg.Src.repository
{
    public class ItemMagicoRepository : IItemMagicoRepository
    {
        public void AdicionarItemMagico(ItemMagico itemMagico)
        {
            using var context = new RpgContext();
            context.ItemMagico.Add(itemMagico);
            context.SaveChanges();
        }

        public void AdicionarItemMagicoAoPersonagem(long id, long idItemMagico)
        {
            using var context = new RpgContext();

            var personagem = context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = context.ItemMagico.Find(idItemMagico);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            personagem.ItensMagicos ??= new List<ItemMagico>();

            if (itemMagico.TipoDoItem == TipoItem.Amuleto && personagem.ItensMagicos.Any(i => i.TipoDoItem == TipoItem.Amuleto))
                throw new Exception("O personagem já possui um amuleto");

            personagem.ItensMagicos.Add(itemMagico);
            context.SaveChanges();
        }

        public ItemMagico ListaItemMagico(long id)
        {
            using var context = new RpgContext();
            var itemMagico = context.ItemMagico.Find(id);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");
            return itemMagico;
        }

        public List<ItemMagico> ListarItemMagicoPorPersonagem(long id, long idItemMagico)
        {
            using var context = new RpgContext();
            var personagem = context.Personagem.Find(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = context.ItemMagico.Find(idItemMagico);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            //if (personagem.ItensMagicos != itemMagico.Id)
            //    throw new Exception("Item mágico não pertence ao personagem");

            var itensMagicos = context.ItemMagico.Where(i => i.Id == itemMagico.Id).ToList();
            if (itensMagicos == null)
                throw new Exception("Nenhum item mágico encontrado");

            return itensMagicos;
        }

        public List<ItemMagico> ListarItensMagicos()
        {
            using var context = new RpgContext();
            var itensMagicos = context.ItemMagico.ToList();
            if (itensMagicos == null)
                throw new Exception("Nenhum item mágico encontrado");
            return itensMagicos;
        }

        public void RemoverItemMagicoDoPeronagem(long id, long idItemMagico)
        {
            using var context = new RpgContext();

            var personagem = context.Personagem
                .Include(p => p.ItensMagicos)
                .FirstOrDefault(p => p.Id == id);

            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = personagem.ItensMagicos.FirstOrDefault(i => i.Id == idItemMagico);
            if (itemMagico == null)
                throw new Exception("Item mágico não está associado a este personagem");

            personagem.ItensMagicos.Remove(itemMagico);
            context.SaveChanges();
        }
    }
}

