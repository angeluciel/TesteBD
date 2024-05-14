using Bogus;
using Dominio;
using ExpectedObjects;

namespace Teste
{
    public class ClienteTeste
    {
        private int _codigo;
        private string _nome;
        private string _endereco;
        private string _telefone;
        private string _email;


        public ClienteTeste()
        {
            Faker faker = new Faker();

            this._codigo   = faker.Random.Int();
            this._nome     = faker.Person.FirstName;
            this._endereco = faker.Random.Words();
            this._telefone = faker.Phone.ToString();
            this._email    = faker.Person.Email;
        }

        [Fact]
        public void criarObjetoCliente()
        {
            var clienteEsperado = new
            {
                Codigo = _codigo,
                Nome = _nome,
                Endereco = _endereco,
                Telefone = _telefone,
                Email = _email
            };

            Cliente cli = new Cliente(
                clienteEsperado.Codigo,
                clienteEsperado.Nome,
                clienteEsperado.Endereco,
                clienteEsperado.Telefone,
                clienteEsperado.Email
                );

            clienteEsperado.ToExpectedObject().ShouldMatch(cli);
        }

        [Theory]
        [InlineData(null)]

        public void ClienteEmailInvalido(string emailErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComEmail(emailErrado).Criar());
        }
    }
}