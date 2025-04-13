using Microsoft.AspNetCore.Mvc;
using Rpg.Src.Business.Interface;
using Rpg.Src.Dto;
using Rpg.Src.Model;
using System.Drawing;

namespace Rpg.Src.Services.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemBusiness _personagemBusiness;
        private readonly IItemMagicoBusiness _itemMagicoBusiness;

        public PersonagemController(IPersonagemBusiness personagemBusiness, IItemMagicoBusiness itemMagicoBusiness)
        {
            _personagemBusiness = personagemBusiness;
            _itemMagicoBusiness = itemMagicoBusiness;
        }

        [HttpPost("AdicionarPersonagem")]
        public IActionResult AdicionarPersonagem(PersonagemDto dto)
        {
            try
            {
                var itens = dto.ItensMagicos
                    .Select(id => _itemMagicoBusiness.ListaItemMagico(id))
                    .Where(item => item != null)
                    .ToList();

                var personagem = new Personagem
                {
                    Nome = dto.Nome,
                    NomeAventureiro = dto.NomeAventureiro,
                    Classe = dto.Classe,
                    Level = dto.Level,
                    ItensMagicos = itens,
                    Forca = dto.Forca,
                    Defesa = dto.Defesa
                };

                _personagemBusiness.AdicionarPersonagem(personagem);
                return Ok("Personagem criado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpGet("ListarPersonagens")]
        public IActionResult ListarPersonagens()
        {
            try
            {
                var personagens = _personagemBusiness.ListarPersonagens();
                return Ok(personagens);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpGet("ListarPersonagemPorId")]
        public IActionResult ListarPersonagemPorId(long id)
        {
            try
            {
                var personagem = _personagemBusiness.ListarPersonagemPorId(id);
                return Ok(personagem);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpPut("AtualizarNomeAventureiro")]
        public IActionResult AtualizarNomeAventureiro(long id, string novoNomeAventureiro)
        {
            try
            {
                var novo = _personagemBusiness.AtualizarNomeAventureiro(id, novoNomeAventureiro);
                return Ok(novo);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpDelete("DeletarPersonagem")]
        public IActionResult DeletarPersonagem(long id)
        {
            try
            {
                _personagemBusiness.DeletarPersonagem(id);
                return Ok("Personagem deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        [HttpGet("BuscarAmuletoDoPersonagem")]
        public IActionResult BuscarAmuletoDoPersonagem(long id)
        {
            try
            {
                var amuletoPersonagem = _personagemBusiness.BuscarAmuletoDoPersonagem(id);
                return Ok(amuletoPersonagem);
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }
    }
}