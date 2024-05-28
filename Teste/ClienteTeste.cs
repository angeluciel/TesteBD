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

            this._codigo = faker.Random.Int();
            this._nome = faker.Person.FirstName;
            this._endereco = faker.Random.Words();
            this._telefone = faker.Phone.ToString();
            this._email = faker.Person.Email;
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
        [InlineData("emailinvalido")]
        [InlineData("email@invalido")]
        [InlineData("email@invalido.")]
        [InlineData("email@.com")]
        [InlineData("@invalido.com")]
        [InlineData(null)]
        [InlineData("")]

        public void ClienteEmailInvalido(string emailErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComEmail(emailErrado).Criar());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-200)]

        public void ClienteCodigoInvalido(int codigoErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComCodigo(codigoErrado).Criar());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]

        public void ClienteNomeErrado(string nomeErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComNome(nomeErrado).Criar());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]

        public void ClienteEnderecoErrado(string enderecoErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComEndereco(enderecoErrado).Criar());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]

        public void ClienteTelefoneErrado(string telefoneErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComTelefone(telefoneErrado).Criar());
        }
    }
}