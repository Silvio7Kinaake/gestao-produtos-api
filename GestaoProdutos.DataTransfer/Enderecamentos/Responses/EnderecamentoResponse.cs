using GestaoProdutos.DataTransfer.Filiais.Responses;

namespace GestaoProdutos.DataTransfer.Enderecamentos.Responses;

public class EnderecamentoResponse
{
    public int Id { get; set; }
    public string Rua { get; set; }
    public int Posicao { get; set; }
    public int Altura { get; set; }
    public int Profundidade { get; set; }
    public int Situacao { get; set; }
    public FilialResponse Filial { get; set; }
}
