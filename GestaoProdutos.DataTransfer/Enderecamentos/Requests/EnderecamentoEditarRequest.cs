namespace GestaoProdutos.DataTransfer.Enderecamentos.Requests;

public record EnderecamentoEditarRequest(string Rua, int Posicao, int Altura, int Profundidade, int CodigoFilial);
