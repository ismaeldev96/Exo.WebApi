using Exo.WebApi.Models;

namespace Exo.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();
        Usuario GetById(int id);
        void Create(Usuario usuario);
        void Update(int id, Usuario usuario);
        void Delete(int id);
        Usuario Login(string email, string senha);
        Usuario GetByEmail (string email);
    }
}
