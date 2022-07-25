using Exo.WebApi.Models;

namespace Exo.WebApi.Interfaces
{
    public interface IProjetoRepository
    {
        List<Projeto> Get();
        Projeto GetById(int id);
        void Create(Projeto projeto);
        void Update(int id, Projeto projeto);
        void Delete(int id);
    }
}
