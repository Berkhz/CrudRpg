using crud_rpg.Src.Dto;
using Microsoft.AspNetCore.Mvc;
using Rpg.Src.Business.Interface;
using Rpg.Src.Model;

namespace Rpg.Src.Services.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemMagicoController : ControllerBase
    {
        private readonly IItemMagicoBusiness _itemMagicoBusiness;

        public ItemMagicoController(IItemMagicoBusiness itemMagicoBusiness)
        {
            _itemMagicoBusiness = itemMagicoBusiness;
        }

        [HttpPost("AdicionarItemMagico")]
        public IActionResult AdicionarItemMagico(ItemMagicoDto dto)
        {
            try
            {
                var itemMagico = new ItemMagico
                {
                    Nome = dto.Nome,
                    TipoDoItem = dto.TipoDoItem,
                    Forca = dto.Forca,
                    Defesa = dto.Defesa
                };

                _itemMagicoBusiness.AdicionarItemMagico(itemMagico);
                return Ok("Item mágico criado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpGet("ListarItensMagicos")]
        public IActionResult ListarItensMagicos()
        {
            try
            {
                var itens = _itemMagicoBusiness.ListarItensMagicos();
                return Ok(itens);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpGet("ListarItemMagicoPorId")]
        public IActionResult ListarItemMagicoPorId(long id)
        {
            try
            {
                var item = _itemMagicoBusiness.ListaItemMagico(id);
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpPut("AdicionarItemMagicoAoPersonagem")]
        public IActionResult AdicionarItemMagicoAoPersonagem(long id, long idItemMagico)
        {
            try
            {
                _itemMagicoBusiness.AdicionarItemMagicoAoPersonagem(id, idItemMagico);
                return Ok("Item adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpGet("ListarItemMagicoPorPersonagem")]
        public IActionResult ListarItemMagicoPorPersonagem(long id, long idItemMagico)
        {
            try
            {
                var itemPersonagem = _itemMagicoBusiness.ListarItemMagicoPorPersonagem(id, idItemMagico);
                return Ok(itemPersonagem);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpDelete("RemoverItemMagicoDoPersonagem")]
        public IActionResult RemoverItemMagicoDoPersonagem(long id, long idItemMagico)
        {
            try
            {
                _itemMagicoBusiness.RemoverItemMagicoDoPeronagem(id, idItemMagico);
                return Ok("Item removido com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }
    }
}