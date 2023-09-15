using Microsoft.AspNetCore.Mvc;
using Projeto_donuz.Model;
using Projeto_donuz.Repositories;

namespace Projeto_donuz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteRepositories _clienteRepositories;
        public ClientController(IClienteRepositories clienteRepositories)
        {
            _clienteRepositories = clienteRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clienteRepositories.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            return await _clienteRepositories.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            await _clienteRepositories.Create(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clienteToDelete = await _clienteRepositories.GetById(id);
           
                if (clienteToDelete != null)
                    return NotFound();

                await _clienteRepositories.DeleteById(clienteToDelete.Id);
                return NoContent();
            
           
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id == cliente.Id)
                 return BadRequest();

                await _clienteRepositories.Update(cliente);

            return NoContent();
        }
    }
}
