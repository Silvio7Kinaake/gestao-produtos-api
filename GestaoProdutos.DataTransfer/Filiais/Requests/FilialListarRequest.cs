using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Filiais.Requests;

public class FilialListarRequest : PaginacaoFiltro
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public string Sigla { get; set; }
    public int IdCidade { get; set; }
    public FilialListarRequest(): base(cpOrd: "Codigo", TipoOrdenacaoEnum.Asc){}
}
