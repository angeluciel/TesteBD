using Bogus;
using Dominio;

namespace Teste
{
    public class ProdutoBuilder
    {
        private int _id               = 1;
        private string _descricao     = "Fabrica de Minions";
        private decimal _precoCompra  = 200.00m;
        private decimal _precoVenda   = 450.00m;
        private int _quantidade       = 4;
        private string _categoria     = "Utensílio.";


        public static ProdutoBuilder Novo()
        {
            return new ProdutoBuilder();
        }

        public Produto Criar()
        {
            return new Produto(_id, _descricao, _precoCompra, _precoVenda, _quantidade, _categoria);
        }

        public ProdutoBuilder Popular()
        {
            Faker faker = new Faker();
            _id = faker.Random.Int(1, 1000);
            _descricao = faker.Random.Word();
            _precoCompra = Convert.ToDecimal(faker.Commerce.Price());
            _precoVenda = Convert.ToDecimal(faker.Commerce.Price());
            _quantidade = faker.Random.Int();
            _categoria = faker.Random.ListItem(new[] { "30 dias", "60 dias", "90 dias" });
            return this;
        }

        public ProdutoBuilder ComCodigo(int id)
        {
            _id = id;
            return this;
        }

        public ProdutoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public ProdutoBuilder ComPrecoVenda(decimal Venda)
        {
            _precoVenda = Venda;
            return this;
        }
        public ProdutoBuilder ComTelefone(decimal Compra)
        {
            _precoCompra = Compra;
            return this;
        }

        public ProdutoBuilder ComEmail(int quantidade)
        {
            _quantidade = quantidade;
            return this;
        }
        
        public ProdutoBuilder ComTermos(string categoria)
        {
            _categoria = categoria;
            return this;
        }

    }
}