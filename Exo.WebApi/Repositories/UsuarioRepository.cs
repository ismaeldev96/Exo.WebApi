using Exo.WebApi.Contexts;
using Exo.WebApi.Interfaces;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ExoContext _context;
        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public void Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);
            if (usuarioEncontrado != null)
            {
                _context.Usuarios.Remove(usuarioEncontrado);
                _context.SaveChanges();
            }
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.First(u => u.Email == email && u.Senha == senha);
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.First(u =>u.Email == email);
        }
        public void Update(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);
   
            if(usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Nome = usuario.Nome;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Acesso = usuario.Acesso;
            }

            _context.Usuarios.Update(usuarioEncontrado);
            _context.SaveChanges();
        }
    }
}
