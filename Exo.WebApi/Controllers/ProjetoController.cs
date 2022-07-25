using Exo.WebApi.Interfaces;
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
    }
}
