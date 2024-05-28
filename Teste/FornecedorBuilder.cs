using Bogus;
using Dominio;

namespace Teste
{
    public class FornecedorBuilder
    {
        private int _codigo         = 1;
        private string _nomeEmpresa = "Fabrica de Minions";
        private string _endereco    = "Porao do Gru";
        private string _telefone    = "58999398371";
        private string _email       = "doutor@exemplo.com";
        private string _termosPag   = "30 dias";


        public static FornecedorBuilder Novo()
        {
            return new FornecedorBuilder();
        }

        public Fornecedor Criar()
        {
            return new Fornecedor(_codigo, _nomeEmpresa, _endereco,
                _telefone, _email, _termosPag);
        }

        public FornecedorBuilder Popular()
        {
            Faker faker   = new Faker();
            _codigo       = faker.Random.Int(1, 1000);
            _nomeEmpresa  = faker.Person.FullName;
            _endereco     = faker.Person.Address.Street;
            _telefone     = faker.Person.Phone;
            _email        = faker.Person.Email;
            _termosPag    = faker.Random.ListItem(new[] { "30 dias", "60 dias", "90 dias" });
            return this;
        }

        public FornecedorBuilder ComCodigo(int codigo)
        {
            _codigo = codigo;
            return this;
        }

        public FornecedorBuilder ComNome(string nomeEmpresa)
        {
            _nomeEmpresa = nomeEmpresa;
            return this;
        }

        public FornecedorBuilder ComEndereco(string endereco)
        {
            _endereco = endereco;
            return this;
        }
        public FornecedorBuilder ComTelefone(string  telefone)
        {
            _telefone = telefone;
            return this;
        }

        public FornecedorBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }
        
        public FornecedorBuilder ComTermos(string termosPag)
        {
            _termosPag = termosPag;
            return this;
        }

    }
}