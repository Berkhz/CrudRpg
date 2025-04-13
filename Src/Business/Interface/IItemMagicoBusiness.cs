using Rpg.Src.Model;

namespace Rpg.Src.Business.Interface
{
    public interface IItemMagicoBusiness
    {
        public void AdicionarItemMagico(ItemMagico itemMagico);
        public List<ItemMagico> ListarItensMagicos();
        public ItemMagico ListaItemMagico(long id);
        public void AdicionarItemMagicoAoPersonagem(long id, long idItemMagico);
        public List<ItemMagico> ListarItemMagicoPorPersonagem(long id, long idItemMagico);
        public void RemoverItemMagicoDoPeronagem(long id, long idItemMagico);
    }
}
