namespace GestaoProdutos.DataTransfer.Enderecamentos.Requests;

public record EnderecamentoInserirRequest(string Rua, int Posicao, int Altura, int Profundidade, int CodigoFilial);
