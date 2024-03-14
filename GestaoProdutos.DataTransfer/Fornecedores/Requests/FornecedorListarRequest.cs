using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Fornecedores.Requests;

public class FornecedorListarRequest : PaginacaoFiltro
{
    public string Descricao {get; set; }
    public string Cnpj {get; set; }
    public FornecedorListarRequest() : base(cpOrd: "Codigo", TipoOrdenacaoEnum.Asc){}
}
