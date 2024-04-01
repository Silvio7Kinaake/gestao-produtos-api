namespace GestaoProdutos.DataTransfer.Lotes.Request;

public record LoteEditarRequest( int CodigoProduto,int Quantidade, DateTime DataFabricacao, DateTime DataValidade, int IdEnderecamento);
