using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Projeto_donuz.Model;
using SQLitePCL;
using System.Security.Cryptography.X509Certificates;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Projeto_donuz.Controllers
{
    [Route("api/Transacoes")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private List<Cliente> _cliente = new List<Cliente>
        {
            new Cliente { Id = 1, Name = "Cliente 1", Saldo = 1000},
            new Cliente { Id = 2, Name = "Cliente 2", Saldo = 500}
        };


        [HttpPost("credito")]
        public IActionResult Creditar(int clienteId, decimal valor)
        {
            var cliente = _cliente.FirstOrDefault(c => c.Id == clienteId);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            cliente.Saldo += valor;
            var transacao = new Transacao
            {
                Valor = valor,
                Date = DateTime.Now,
                Tipo = TipoTransacao.Credito
            };
            cliente.Transacaos.Add(transacao);
            return Ok(transacao);
        }

        [HttpPost("debito")]
        public IActionResult Debitar(int clienteId, decimal valor)
        {
            var cliente = _cliente.FirstOrDefault(c => c.Id == clienteId);
           
            if(cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            if (cliente.Saldo < valor)
            {
                return BadRequest("Você não possue saldo suficiente para esta transação");
            }

            cliente.Saldo -= valor;
            var transacao = new Transacao
            {
                Valor = valor,
                Date = DateTime.Now,
                Tipo = TipoTransacao.Debito
            };
            cliente.Transacaos.Add(transacao);
            
            return Ok(transacao);
           
            
        }
    }
}
