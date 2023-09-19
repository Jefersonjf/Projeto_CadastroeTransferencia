using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projeto_donuz.Model;

namespace Projeto_donuz.Repositories
{
    public interface IClienteRepositories
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente?> GetById(int id);
        Task<int> Create(Cliente cadastro);
        Task Update(Cliente cadastro);
        Task DeleteById(int id);
        
    }  
}
