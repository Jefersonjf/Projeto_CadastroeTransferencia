using Projeto_donuz.Model;

namespace Projeto_donuz.Repositories
{
    public interface ITransacaoRepository
    {
        IEnumerable<Transacao> ObterTodasTransacoes();
        void AdicionarTransacao(Transacao transacao);
    }
}
