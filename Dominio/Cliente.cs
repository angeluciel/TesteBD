using System.Text.RegularExpressions;

namespace Dominio
{
    public class Cliente
    {
        // campos
        private int codigo;
        private string nome;
        private string endereco;
        private string telefone;
        private string email;

        // teste
        public Cliente(int codigo, string nome, string endereco, string telefone, string email)
        {
            if (codigo < 1) throw new ArgumentException("Código Inválido");
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome inválido.");
            if (string.IsNullOrEmpty(endereco)) throw new ArgumentException("Endereço inválido.");
            if (string.IsNullOrEmpty(telefone)) throw new ArgumentException("Telefone inválido.");
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email inválido.");
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email)) throw new ArgumentException("E-mail inválido");

            this.Codigo = codigo;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        // propriedades
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
    }
}