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
        public IHttpActionResult AdicionarItemMagico(ItemMagico itemMagico)
        {
            try
            {
                _itemMagicoBusiness.AdicionarItemMagico(itemMagico);
                return Ok("Item mágico criado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível adicionar o item mágico. " + "Erro: " + e);
            }
        }

        [HttpGet]
        [Route("ListarItensMagicos")]
        public IHttpActionResult ListarItensMagicos()
        {
            try
            {
                var itens = _itemMagicoBusiness.ListarItensMagicos();
                return Ok(itens);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível listar os itens mágicos. " + "Erro: " + e);
            }
        }

        [HttpGet]
        [Route("ListarItemMagicoPorId")]
        public IHttpActionResult ListarItemMagicoPorId(long id)
        {
            try
            {
                var item = _itemMagicoBusiness.ListaItemMagico(id);
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível listar o item mágico. " + "Erro: " + e);
            }
        }

        [HttpPut]
        [Route("AdicionarItemMagicoAoPersonagem")]
        public IHttpActionResult AdicionarItemMagicoAoPersonagem(long id, long idItemMagico)
        {
            try
            {
                _itemMagicoBusiness.AdicionarItemMagicoAoPersonagem(id, idItemMagico);
                return Ok("Item mágico adicionado ao personagem com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível adicionar o item mágico ao personagem. " + "Erro: " + e);
            }
        }

        [HttpGet]
        [Route("ListarItemMagicoPorPersonagem")]
        public IHttpActionResult ListarItemMagicoPorPersonagem(long id, long idItemMagico)
        {
            try
            {
                var itemPersonagem = _itemMagicoBusiness.ListarItemMagicoPorPersonagem(id, idItemMagico);
                return Ok(itemPersonagem);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível listar o item mágico do personagem. " + "Erro: " + e);
            }
        }

        [HttpDelete]
        [Route("RemoverItemMagicoDoPersonagem")]
        public IHttpActionResult RemoverItemMagicoDoPersonagem(long id, long idItemMagico)
        {
            try
            {
                _itemMagicoBusiness.RemoverItemMagicoDoPeronagem(id, idItemMagico);
                return Ok("Item mágico removido do personagem com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível remover o item mágico do personagem. " + "Erro: " + e);
            }
        }
    }
}
