using GestaoProdutos.DataTransfer.Estados.Responses;

namespace GestaoProdutos.DataTransfer.Cidades.Responses;

public class CidadeResponse
{
    public int Id { get; init; }
    public string Descricao { get; init; }
    public EstadoResponse Estado { get; init; }
}
