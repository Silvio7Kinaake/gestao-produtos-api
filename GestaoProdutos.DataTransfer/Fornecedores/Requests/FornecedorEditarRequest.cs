namespace GestaoProdutos.DataTransfer.Fornecedores.Requests;

public record FornecedorEditarRequest(string Descricao, string Cnpj, int situacao);
