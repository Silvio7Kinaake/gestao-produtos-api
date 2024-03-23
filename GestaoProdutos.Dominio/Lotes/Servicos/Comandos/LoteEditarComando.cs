namespace GestaoProdutos.Dominio.Lotes.Servicos.Comandos;

public class LoteEditarComando
{
    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade {get; set; }
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }
}
