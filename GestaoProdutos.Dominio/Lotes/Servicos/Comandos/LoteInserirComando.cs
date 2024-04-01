namespace GestaoProdutos.Dominio.Lotes.Servicos.Comandos;

public class LoteInserirComando
{
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataFabricacao { get; set; }
    public DateTime DataValidade { get; set; }
    public int IdEnderecamento { get; set; }
}
