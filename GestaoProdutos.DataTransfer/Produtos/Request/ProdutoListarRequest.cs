using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.DataTransfer.Produtos.Request;

public class ProdutoListarRequest : PaginacaoFiltro
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public int CodigoFornecedor { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
    public ProdutoListarRequest(): base(cpOrd: "Codigo", TipoOrdenacaoEnum.Asc){}
}
