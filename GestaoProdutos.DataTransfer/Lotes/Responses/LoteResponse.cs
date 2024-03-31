using GestaoProdutos.DataTransfer.Produtos.Response;

namespace GestaoProdutos.DataTransfer.Lotes.Response;

public class LoteResponse
{
    public int Id { get; set; }
    public int Quantidade {get; set; }
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }
     public ProdutoResponse Produto { get; set; }
}
