using Rpg.Src.Business.Interface;
using Rpg.Src.Model;
using Rpg.Src.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (itemMagico == null)
                throw new Exception("Item mágico não pode ser nulo");
            if (string.IsNullOrEmpty(itemMagico.Nome))
                throw new Exception("Nome do item mágico não pode ser nulo ou vazio");
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
    }
}
