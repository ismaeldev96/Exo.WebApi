using Exo.WebApi.Contexts;
using Exo.WebApi.Interfaces;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ExoContext _context;
        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public void Create(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Projeto projetoEncontrado = _context.Projetos.Find(id);
            _context.Projetos.Remove(projetoEncontrado);
            _context.SaveChanges();
        }

        public List<Projeto> Get()
        {
            return _context.Projetos.ToList();
        }

        public Projeto GetById(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Update(int id, Projeto projeto)
        {
            Projeto projetoEncontrado = _context.Projetos.Find(id);
            if (projetoEncontrado != null)
            {
                projetoEncontrado.Titulo = projeto.Titulo;
                projetoEncontrado.DataInicio = projeto.DataInicio;
                projetoEncontrado.Tecnologia = projeto.Tecnologia;
                projetoEncontrado.Area = projeto.Area;
            }
            _context.Projetos.Add(projetoEncontrado);
            _context.SaveChanges();
        }
    }
}
