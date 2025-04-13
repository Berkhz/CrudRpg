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
        public void AdicionarPersonagem(Personagem personagem)
        {
            try
            {
                _personagemBusiness.AdicionarPersonagem(personagem);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível adicionar o personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok("Personagem criado com sucesso!");
            }
        }

        [HttpGet]
        [Route("ListarPersonagens")]
        public List<Personagem> ListarPersonagens()
        {
            try
            {
                return _personagemBusiness.ListarPersonagens();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível listar os personagens. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }

        [HttpGet]
        [Route("ListarPersonagemPorId")]
        public Personagem ListarPersonagemPorId(long id)
        {
            try
            {
                return _personagemBusiness.ListarPersonagemPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível listar o personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }

        [HttpPut]
        [Route("AtualizarNomeAventureiro")]
        public string AtualizarNomeAventureiro(long id, string novoNomeAventureiro)
        {
            try
            {
                return _personagemBusiness.AtualizarNomeAventureiro(id, novoNomeAventureiro);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível atualizar o nome aventureiro do personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }

        [HttpDelete]
        [Route("DeletarPersonagem")]
        public void DeletarPersonagem(long id)
        {
            try
            {
                _personagemBusiness.DeletarPersonagem(id);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível deletar o personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok("Personagem deletado com sucesso!");
            }
        }

        [HttpGet]
        [Route("BuscarAmuletoDoPersonagem")]
        public long BuscarAmuletoDoPersonagem(long id)
        {
            try
            {
                return _personagemBusiness.BuscarAmuletoDoPersonagem(id);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível buscar o amuleto do personagem. " + "Erro: " + e);
            }
            finally
            {
                Ok();
            }
        }
    }
}
