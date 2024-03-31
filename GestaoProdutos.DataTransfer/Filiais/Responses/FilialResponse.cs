using GestaoProdutos.DataTransfer.Cidades.Responses;

namespace GestaoProdutos.DataTransfer.Filiais.Responses;

public class FilialResponse
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public string Sigla { get; set; }
    public int Situacao { get; set; }
    public CidadeResponse Cidade { get; set; }
}
