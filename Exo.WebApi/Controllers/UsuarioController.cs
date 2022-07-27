using Exo.WebApi.Interfaces;
using Exo.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_iUsuarioRepository.Get());
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
                Usuario usuarioEncontrado = _iUsuarioRepository.GetById(id);
                if (usuarioEncontrado == null)
                {
                    return NotFound("Usuario não encontrado");
                }
                return Ok(usuarioEncontrado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.GetByEmail(usuario.Email);
                if (usuarioBuscado != null)
                {
                    return StatusCode(406, new { msg = $"Email {usuario.Email} já cadastrado!" });
                }
                
                
                _iUsuarioRepository.Create(usuario);
                return StatusCode(201, new { msg = $"Usuario Cadastrado com sucesso!" });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario usuario)
        {
            try
            {
                Usuario usuarioEncontrado = _iUsuarioRepository.GetById(id);
                Usuario usuarioBuscado = _iUsuarioRepository.GetByEmail(usuario.Email);
                if (usuarioEncontrado == null)
                {
                    return NotFound();
                }
                else if (usuarioBuscado != null)
                {
                    return StatusCode(406, new { msg = $"Email {usuario.Email} já cadastrado!" });
                }
                _iUsuarioRepository.Update(id, usuario);
                return StatusCode(201, new { msg = "Usuario Atualizado com Sucesso!" });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuarioBuscado = _iUsuarioRepository.GetById(id);
            if(usuarioBuscado == null)
            {
                return NotFound();
            }
            _iUsuarioRepository.Delete(id);
            return StatusCode(204, new { msg = "Usuario Deletado Com Sucesso" });
        }


    }
}
