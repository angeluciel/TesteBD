using Bogus;
using Dominio;

namespace Teste
{
    public class ClienteBuilder
    {
        private int _codigo       = 1;
        private string _nome      = "Kevin";
        private string _endereco  = "Casa do Gru";
        private string _telefone  = "58999398372";
        private string _email     = "notaminion@banana.com";


        public static ClienteBuilder Novo()
        {
            return new ClienteBuilder();
        }

        public Cliente Criar()
        {
            return new Cliente(_codigo, _nome, _endereco,
                _telefone, _email);
        }

        public ClienteBuilder Popular()
        {
            Faker faker = new Faker();
            _codigo = faker.Random.Int(1, 1000);
            _nome = faker.Person.FullName;
            _endereco = faker.Person.Address.Street;
            _telefone = faker.Person.Phone;
            _email = faker.Person.Email;
            return this;
        }

        public ClienteBuilder ComCodigo(int codigo)
        {
            _codigo = codigo;
            return this;
        }

        public ClienteBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ClienteBuilder ComEndereco(string endereco)
        {
            _endereco = endereco;
            return this;
        }
        public ClienteBuilder ComTelefone(string  telefone)
        {
            _telefone = telefone;
            return this;
        }

        public ClienteBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

    }
}