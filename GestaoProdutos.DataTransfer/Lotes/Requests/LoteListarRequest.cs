using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Lotes.Request;

public class LoteListarRequest : PaginacaoFiltro
{
    public int Id { get; set; }
    public int Quantidade {get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
    public int CodigoProduto { get; set; }
    public LoteListarRequest(): base(cpOrd: "Id", TipoOrdenacaoEnum.Asc){}
}
