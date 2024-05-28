namespace Dominio
{
    public class Produto
    {
        public static List<ProdutoDTO> lista = new List<ProdutoDTO>;

        private int id;
        private string descricao;
        private string codBarras;
        private decimal precoCompra;
        private decimal precoVenda;
        private int quantidade;
        private string categoria;

        public Produto(int id, string descricao, decimal precoCompra, decimal precoVenda, int quantidade, string categoria)
        {
            if (id < 1) throw new ArgumentException("Código Inválido");
            if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descricao Inválida!");
            if (precoCompra >= 0) throw new ArgumentException("Preço de Compra inválido.");
            if (precoVenda >= 0) throw new ArgumentException("Preço de Venda inválido.");
            if (quantidade < 0) throw new ArgumentException("Quantidade inválida.");
            if (string.IsNullOrEmpty(categoria)) throw new ArgumentException("Categoria Inválida.");

            this.id = id;
            this.descricao = descricao;
            this.precoCompra = precoCompra;
            this.precoVenda = precoVenda;
            this.quantidade = quantidade;
            this.categoria = categoria;
        }

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal PrecoCompra { get => precoCompra; set => precoCompra = value; }
        public decimal PrecoVenda { get => precoVenda; set => precoVenda = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}