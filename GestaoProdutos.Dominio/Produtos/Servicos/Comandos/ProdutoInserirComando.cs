using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.Dominio.Produtos.Servicos.Comandos;

public class ProdutoInserirComando
{
    public string Descricao { get; set; }
    public int CodigoFornecedor { get; set; }
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }
}
