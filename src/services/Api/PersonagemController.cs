using Rpg.Src.Business;
using Rpg.Src.Business.Interface;
using Rpg.Src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rpg.Src.Services.Api
{
    [RoutePrefix("api/Personagem")]
    public class PersonagemController : ApiController
    {
        private readonly IPersonagemBusiness _personagemBusiness;
        public PersonagemController(IPersonagemBusiness personagemBusiness)
        {
            _personagemBusiness = personagemBusiness;
        }

        [HttpPost]
        [Route("AdicionarPersonagem")]
        public IHttpActionResult AdicionarPersonagem(Personagem personagem)
        {
            try
            {
                _personagemBusiness.AdicionarPersonagem(personagem);
                return Ok("Personagem criado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível adicionar o personagem. " + "Erro: " + e);
            }
        }

        [HttpGet]
        [Route("ListarPersonagens")]
        public IHttpActionResult ListarPersonagens()
        {
            try
            {
                var personagens = _personagemBusiness.ListarPersonagens();
                return Ok(personagens);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível listar os personagens. " + "Erro: " + e);
            }
        }

        [HttpGet]
        [Route("ListarPersonagemPorId")]
        public IHttpActionResult ListarPersonagemPorId(long id)
        {
            try
            {
                var personagem = _personagemBusiness.ListarPersonagemPorId(id);
                return Ok(personagem);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível listar o personagem. " + "Erro: " + e);
            }
        }

        [HttpPut]
        [Route("AtualizarNomeAventureiro")]
        public IHttpActionResult AtualizarNomeAventureiro(long id, string novoNomeAventureiro)
        {
            try
            {
                var novo = _personagemBusiness.AtualizarNomeAventureiro(id, novoNomeAventureiro);
                return Ok(novo);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível atualizar o nome aventureiro do personagem. " + "Erro: " + e);
            }
        }

        [HttpDelete]
        [Route("DeletarPersonagem")]
        public IHttpActionResult DeletarPersonagem(long id)
        {
            try
            {
                _personagemBusiness.DeletarPersonagem(id);
                return Ok("Personagem deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível deletar o personagem. " + "Erro: " + e);
            }
        }

        [HttpGet]
        [Route("BuscarAmuletoDoPersonagem")]
        public IHttpActionResult BuscarAmuletoDoPersonagem(long id)
        {
            try
            {
                var amuletoPersonagem = _personagemBusiness.BuscarAmuletoDoPersonagem(id);
                return Ok(amuletoPersonagem);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível buscar o amuleto do personagem. " + "Erro: " + e);
            }
        }
    }
}
