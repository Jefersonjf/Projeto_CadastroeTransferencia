using Microsoft.EntityFrameworkCore;
using Projeto_donuz.AppDbContex;
using Projeto_donuz.Model;
using System.Linq;

namespace Projeto_donuz.Repositories
{
    public class ClienteRepositories : IClienteRepositories
    {

        public readonly AppDbContext _context;

        public ClienteRepositories(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<int> Create(Cliente cadastro)
        {
            var newCliente = _context.Cadastros.Add(cadastro);
            await _context.SaveChangesAsync();

            return newCliente.Entity.Id;
            
        }

        public async Task DeleteById(int id)
        {
            var DeleteById = await _context.Cadastros.FindAsync(id);
            _context.Cadastros.Remove(DeleteById);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
           return await _context.Cadastros.ToListAsync();
        }                    

        public async Task Update(Cliente cadastro)
        {
            _context.Entry(cadastro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> GetById(int id)
        {
            var cliente = await _context.Cadastros.Where(s => s.Id == id).FirstOrDefaultAsync();

            return cliente;

        }
    }
}
