namespace GestaoProdutos.DataTransfer.Lotes.Request;

public record LoteInserirRequest(int codigoProduto, int Quantidade, DateTime DataFabricacao, DateTime DataValidade);
