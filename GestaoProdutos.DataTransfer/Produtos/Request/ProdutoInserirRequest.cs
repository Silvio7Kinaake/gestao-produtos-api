using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.DataTransfer.Produtos.Request;

public record ProdutoInserirRequest(string Descricao, int CodigoFornecedor, DateTime DataFabricacao, DateTime DataValidade);
