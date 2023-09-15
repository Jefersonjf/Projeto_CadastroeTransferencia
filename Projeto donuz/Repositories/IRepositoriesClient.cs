using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projeto_donuz.Model;

namespace Projeto_donuz.Repositories
{
    public interface IRepositoriesClient
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente> GetById(int id);
        Task Creat(Cliente cadastro);
        Task Update(Cliente cadastro);
        Task DeleteById(int id);
    }
}
