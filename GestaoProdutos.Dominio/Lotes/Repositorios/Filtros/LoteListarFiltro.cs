namespace GestaoProdutos.Dominio.Lotes.Repositorios.Filtros;

public class LoteListarFiltro
{
    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade {get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
}
