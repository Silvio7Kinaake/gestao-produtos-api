using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Enderecamentos.Requests;

public class EnderecamentoListarRequest : PaginacaoFiltro
{
    public int Id { get; set; }
    public string Rua { get; set; }
    public int Posicao { get; set; }
    public int Altura { get; set; }
    public int Profundidade { get; set; }
    public int CodigoFilial { get; set; }

    public EnderecamentoListarRequest() : base(cpOrd: "Id", TipoOrdenacaoEnum.Asc) { }
}
