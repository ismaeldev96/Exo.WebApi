using Exo.WebApi.Interfaces;
using Exo.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _iProjectRepository;
        public ProjetoController(IProjetoRepository iProjectRepository)
        {
            _iProjectRepository = iProjectRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_iProjectRepository.Get());
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try 
            { 
                return Ok(_iProjectRepository.GetById(id)); 
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Projeto projeto)
        {
            try
            {
                _iProjectRepository.Create(projeto);
                return StatusCode(201, new { msg = $"Projeto Cadastrado com sucesso!" });
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Projeto projeto)
        {
            try
            {
               Projeto projetoBuscado = _iProjectRepository.GetById(id);
               if(projetoBuscado == null)
                {
                    return NotFound();
                }

                _iProjectRepository.Update(id, projeto);
               return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var projeto = _iProjectRepository.GetById(id);
                if(projeto == null)
                {
                    return StatusCode(403, new { msg = "Projeto não existe em nossa base de dados" });
                }
                return StatusCode(204, new { msg = "Projeto Deletado com Sucesso" });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
