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
               
                Usuario usuarioEmail = _iUsuarioRepository.GetByEmail(usuario.Email);
                
                if(usuarioEmail != null)
                {
                    return StatusCode(406, new { msg = "Email já cadastrado!"});
                }

                _iUsuarioRepository.Create(usuario);

                return StatusCode(201);
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
                if(usuarioEncontrado == null)
                {
                    return NotFound();
                }
                _iUsuarioRepository.Update(id, usuario);
                return StatusCode(201, new { msg = "Usuario Atualizado com Sucesso!" });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
