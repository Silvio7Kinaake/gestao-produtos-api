using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Estados.Requests;

public class EstadoListarRequest : PaginacaoFiltro
{
    public string Descricao { get; set; }
    public string Sigla { get; set; }
    public EstadoListarRequest() : base(cpOrd: "Codigo", TipoOrdenacaoEnum.Asc) { }
}
