using Rpg.Src.Business.Interface;
using Rpg.Src.Model;
using System.Web.Http;

namespace Rpg.Src.Services.Api
{
    [RoutePrefix("api/ItemMagico")]
    public class ItemMagicoController : ApiController
    {
        private readonly IItemMagicoBusiness _itemMagicoBusiness;
        public ItemMagicoController(IItemMagicoBusiness itemMagicoBusiness)
        {
            _itemMagicoBusiness = itemMagicoBusiness;
        }

        [HttpPost]
        [Route("AdicionarItemMagico")]
        public void AdicionarItemMagico(ItemMagico itemMagico)
        {
            try
            {
                _itemMagicoBusiness.AdicionarItemMagico(itemMagico);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível adicionar o item mágico. " + "Erro: " + e);
            }
            finally
            {
                Ok("Item mágico criado com sucesso!");
            }
        }

        [HttpGet]
        [Route("ListarItensMagicos")]
        public List<ItemMagico> ListarItensMagicos()
        {
            try
            {
                return _itemMagicoBusiness.ListarItensMagicos();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível listar os itens mágicos. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }

        [HttpGet]
        [Route("ListarItemMagicoPorId")]
        public ItemMagico ListarItemMagicoPorId(long id)
        {
            try
            {
                return _itemMagicoBusiness.ListaItemMagico(id);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível listar o item mágico. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }

        [HttpPut]
        [Route("AdicionarItemMagicoAoPersonagem")]
        public void AdicionarItemMagicoAoPersonagem(long id, long idItemMagico)
        {
            try
            {
                _itemMagicoBusiness.AdicionarItemMagicoAoPersonagem(id, idItemMagico);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível adicionar o item mágico ao personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok("Item mágico adicionado ao personagem com sucesso!");
            }
        }

        [HttpGet]
        [Route("ListarItemMagicoPorPersonagem")]
        public List<ItemMagico> ListarItemMagicoPorPersonagem(long id, long idItemMagico)
        {
            try
            {
                return _itemMagicoBusiness.ListarItemMagicoPorPersonagem(id, idItemMagico);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível listar o item mágico do personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }
    }
}
