using Bogus;
using Dominio;
using ExpectedObjects;

namespace Teste
{
    public class FornecedorTeste
    {
        private int _codigo;
        private string _nomeEmpresa;
        private string _endereco;
        private string _telefone;
        private string _email;
        private string _termosPag;


        public FornecedorTeste()
        {
            Faker faker = new Faker();

            this._codigo = faker.Random.Int();
            this._nomeEmpresa = faker.Company.CompanyName();
            this._endereco = faker.Person.Address.Street;
            this._telefone = faker.Person.Phone;
            this._email = faker.Person.Email;
            this._termosPag = faker.Random.ListItem(new[] { "30 dias", "60 dias", "90 dias" });

        }

        [Fact]
        public void CriarObjetoFornecedor()
        {

            // Arrange
            var fornecedorEsperado = new
            {
                Codigo = _codigo,
                NomeEmpresa = _nomeEmpresa,
                Endereco = _endereco,
                Telefone = _telefone,
                Email = _email,
                TermosPag = _termosPag
            };

            // ACT

            Fornecedor forne = new Fornecedor(
                fornecedorEsperado.Codigo,
                fornecedorEsperado.NomeEmpresa,
                fornecedorEsperado.Endereco,
                fornecedorEsperado.Telefone,
                fornecedorEsperado.Email,
                fornecedorEsperado.TermosPag);

            fornecedorEsperado.ToExpectedObject().ShouldMatch(forne);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]

        
    }
}