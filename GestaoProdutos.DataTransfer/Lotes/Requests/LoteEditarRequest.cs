namespace GestaoProdutos.DataTransfer.Lotes.Request;

public record LoteEditarRequest( int codigoProduto,int Quantidade, DateTime DataFabricacao, DateTime DataValidade);
