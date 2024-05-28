using System.Text.RegularExpressions;

namespace Dominio
{
    public class Fornecedor
    {
        private int codigo;
        private string nomeEmpresa;
        private string endereco;
        private string telefone;
        private string email;
        private string termosPag;

        public Fornecedor(int codigo, string nomeEmpresa, string endereco, string telefone, string email, string termosPag)
        {
            if (codigo < 1) throw new ArgumentException("Codigo Inválido.");
            if (string.IsNullOrEmpty(nomeEmpresa)) throw new ArgumentException("Nome de Empresa inválido.");
            if (string.IsNullOrEmpty(endereco)) throw new ArgumentException("Endereço Inválido.");
            if (string.IsNullOrEmpty(telefone)) throw new ArgumentException("Telefone Inválido.");
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email inválido.");
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email)) throw new ArgumentException("E-mail inválido");
            if (string.IsNullOrEmpty(termosPag)) throw new ArgumentException("Termos de Pagamento inválidos.");

            this.Codigo = codigo;
            this.NomeEmpresa = nomeEmpresa;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.TermosPag = termosPag;
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string NomeEmpresa { get => nomeEmpresa; set => nomeEmpresa = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string TermosPag { get => termosPag; set => termosPag = value; }
    }
}