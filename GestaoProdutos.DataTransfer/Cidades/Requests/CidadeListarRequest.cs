using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;
using GestaoProdutos.DataTransfer.Estados.Responses;

namespace GestaoProdutos.DataTransfer.Cidades.Requests;

public class CidadeListarRequest : PaginacaoFiltro
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public EstadoResponse Estado { get; set; }
    public CidadeListarRequest() : base(cpOrd: "Id", TipoOrdenacaoEnum.Asc) { }
}
