using crud_rpg.src.context;
using crud_rpg.src.model;
using crud_rpg.src.repository.Interface;

namespace crud_rpg.src.repository
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

            var personagem = context.Personagem.Find(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = context.ItemMagico.Find(idItemMagico);

            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            if (personagem.ItemMagico != 0 || personagem.ItemMagico != null)
                throw new Exception("Personagem já possui um item mágico");

            personagem.ItemMagico = itemMagico.Id;
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

            if (personagem.ItemMagico != itemMagico.Id)
                throw new Exception("Item mágico não pertence ao personagem");

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
            var personagem = context.Personagem.Find(id);
            if (personagem == null)
                throw new Exception("Personagem não encontrado");

            var itemMagico = context.ItemMagico.Find(idItemMagico);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            if (personagem.ItemMagico != itemMagico.Id)
                throw new Exception("Item mágico não pertence ao personagem");
            personagem.ItemMagico = 0;
            context.ItemMagico.Remove(itemMagico);
            context.SaveChanges();
        }
    }
}

