using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_donuz.Model;
using Projeto_donuz.Repositories;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Projeto_donuz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoController(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        [HttpGet]
        public IActionResult ObterTodasTransacoes()
        {
            var transacoes = _transacaoRepository.ObterTodasTransacoes();
            return Ok(transacoes);
        }

        [HttpPost]
        public IActionResult AdicionarTransacao([FromBody] Transacao transacao)
        {
            if (transacao == null)
            {
                return BadRequest();
            }

            _transacaoRepository.AdicionarTransacao(transacao);

            return CreatedAtAction("ObterTodasTransacoes", new { id = transacao.Id }, transacao);
        }
    }
}
