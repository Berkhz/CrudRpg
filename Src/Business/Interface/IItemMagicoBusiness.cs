using Rpg.Src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
