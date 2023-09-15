using Microsoft.EntityFrameworkCore;
using Projeto_donuz.Model;

namespace Projeto_donuz.Repositories
{
    public class ClienteRepositories : IClienteRepositories
    {

        public readonly ClienteContext _context;

        public ClienteRepositories(ClienteContext context)
        {
            _context = context;
        }

       
        public async Task<int> Create(Cliente cadastro)
        {
            var newCliente = _context.cadastros.Add(cadastro);
            await _context.SaveChangesAsync();

            return newCliente.Entity.Id;
            
        }

        public async Task DeleteById(int id)
        {
            var DeleteById = await _context.cadastros.FindAsync(id);
            _context.cadastros.Remove(DeleteById);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
           return await _context.cadastros.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.cadastros.FindAsync(id);
        }

        public async Task Update(Cliente cadastro)
        {
            _context.Entry(cadastro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
