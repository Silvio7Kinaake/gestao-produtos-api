using GestaoProdutos.DataTransfer.Responses;

namespace GestaoProdutos.DataTransfer.Produtos.Response;

public class ProdutoResponse
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public int Situacao { get; set; }
    public FornecedorResponse Fornecedor { get; set; }
}
