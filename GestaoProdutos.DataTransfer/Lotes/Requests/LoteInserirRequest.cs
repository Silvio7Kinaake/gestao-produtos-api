namespace GestaoProdutos.DataTransfer.Lotes.Request;

public record LoteInserirRequest(int CodigoProduto, int Quantidade, DateTime DataFabricacao, DateTime DataValidade, int IdEnderecamento);
