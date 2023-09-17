namespace Projeto_donuz.Model
{
    public class Cliente
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public decimal Saldo { get; set; }
        public List<Transacao> Transacaos { get; set; } = new List<Transacao>();
    }

    public class Transacao
    {
        public string? Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Date { get; set; }
        public TipoTransacao Tipo { get; set; }
    }
    public enum TipoTransacao
    {
        Credito,
        Debito
    }

}
