using Bogus;
using Dominio;
using ExpectedObjects;

namespace Teste
{
    public class ProdutoTeste
    {
        private int _id;
        private string _descricao;
        private string _codBarras;
        private decimal _precoVenda;
        private decimal _precoCompra;
        private int _quantidade;
        private string _categoria;

        public ProdutoTeste()
        {
            Faker faker = new Faker();

            this._id          = faker.Random.Int(1, 1000);
            this._descricao   = faker.Random.String();
            this._precoVenda  = Convert.ToDecimal(faker.Commerce.Price());
            this._precoCompra = Convert.ToDecimal(faker.Commerce.Price());
            this._quantidade  = faker.Random.Int(1,1000);
            this._categoria   = faker.Random.Word();

        }

        [Fact]
        public void criarObjetoProduto()
        {
            var produtoEsperado = new
            {
                id = _id,
                descricao = _descricao,
                precoVenda = _precoVenda,
                precoCompra = _precoCompra,
                quantidade = _quantidade,
                categoria = _categoria
            };

            Produto pro = new Produto(
                produtoEsperado.id,
                produtoEsperado.descricao,
                produtoEsperado.precoVenda,
                produtoEsperado.precoCompra,
                produtoEsperado.quantidade,
                produtoEsperado.categoria
                );

            produtoEsperado.ToExpectedObject().ShouldMatch(pro);
        }

        [Theory]
        [InlineData(0)]

    }
}