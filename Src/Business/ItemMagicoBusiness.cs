using Rpg.Src.Business.Interface;
using Rpg.Src.@enum;
using Rpg.Src.Model;
using Rpg.Src.repository.Interface;

namespace Rpg.Src.Business
{
    public class ItemMagicoBusiness : IItemMagicoBusiness
    {
        private readonly IItemMagicoRepository _itemMagicoRepository;
        public ItemMagicoBusiness(IItemMagicoRepository itemMagicoRepository) 
        {
            _itemMagicoRepository = itemMagicoRepository;
        }

        public void AdicionarItemMagico(ItemMagico itemMagico)
        {
            ValidarItemMagico(itemMagico);
            _itemMagicoRepository.AdicionarItemMagico(itemMagico);
        }

        public void AdicionarItemMagicoAoPersonagem(long id, long idItemMagico)
        {
            if (id <= 0)
                throw new Exception("Id do personagem não pode ser menor ou igual a zero");
            if (idItemMagico <= 0)
                throw new Exception("Id do item mágico não pode ser menor ou igual a zero");
            _itemMagicoRepository.AdicionarItemMagicoAoPersonagem(id, idItemMagico);
        }

        public ItemMagico ListaItemMagico(long id)
        {
            if (id <= 0)
                throw new Exception("Id do item mágico não pode ser menor ou igual a zero");
            var itemMagico = _itemMagicoRepository.ListaItemMagico(id);
            if (itemMagico == null)
                throw new Exception("Item mágico não encontrado");

            return itemMagico;
        }

        public List<ItemMagico> ListarItemMagicoPorPersonagem(long id, long idItemMagico)
        {
            if (id <= 0)
                throw new Exception("Id do personagem não pode ser menor ou igual a zero");

            if (idItemMagico <= 0)
                throw new Exception("Id do item mágico não pode ser menor ou igual a zero");

            var itensMagicos = _itemMagicoRepository.ListarItemMagicoPorPersonagem(id, idItemMagico);

            if (itensMagicos == null || itensMagicos.Count == 0)
                throw new Exception("Nenhum item mágico encontrado para o personagem");

            return itensMagicos;
        }

        public List<ItemMagico> ListarItensMagicos()
        {
            var itensMagicos = _itemMagicoRepository.ListarItensMagicos();

            if (itensMagicos == null || itensMagicos.Count == 0)
                throw new Exception("Nenhum item mágico encontrado");

            return itensMagicos;
        }

        public void RemoverItemMagicoDoPeronagem(long id, long idItemMagico)
        {
            if (id <= 0)
                throw new Exception("Id do personagem não pode ser menor ou igual a zero");
            if (idItemMagico <= 0)
                throw new Exception("Id do item mágico não pode ser menor ou igual a zero");
            _itemMagicoRepository.RemoverItemMagicoDoPeronagem(id, idItemMagico);
        }

        private void ValidarItemMagico(ItemMagico itemMagico)
        {
            if (itemMagico == null)
                throw new Exception("Item mágico não pode ser nulo");

            if (string.IsNullOrEmpty(itemMagico.Nome))
                throw new Exception("Nome do item mágico não pode ser nulo ou vazio");

            if (itemMagico.Forca < 0 || itemMagico.Defesa < 0)
                throw new Exception("Força e Defesa não podem ser negativas.");

            if (itemMagico.Forca > 10 || itemMagico.Defesa > 10)
                throw new Exception("Força e Defesa não podem ultrapassar 10.");

            if (itemMagico.Forca == 0 && itemMagico.Defesa == 0)
                throw new Exception("Item mágico não pode ter Força e Defesa iguais a zero.");

            switch (itemMagico.TipoDoItem)
            {
                case TipoItem.Arma:
                    if (itemMagico.Defesa != 0)
                        throw new Exception("Item do tipo Arma deve ter Defesa igual a 0.");
                    break;

                case TipoItem.Armadura:
                    if (itemMagico.Forca != 0)
                        throw new Exception("Item do tipo Armadura deve ter Força igual a 0.");
                    break;
            }
        }
    }
}
