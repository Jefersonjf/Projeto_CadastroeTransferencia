namespace Projeto_donuz.Model
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal? Saldo { get; set; }
        public List<Transacao> Transacaos { get; set; } = new List<Transacao>();

        public Cliente(string name, string cpf, string endereco, string telefone, string email, decimal saldo)
        {
            Name = name;
            CPF = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Saldo = saldo;
        }
    }       

}
