namespace GestaoProdutos.Dominio.Enderecamentos.Servicos.Comandos;

public class EnderecamentoEditarComando
{
    public int Id { get; set; }
    public string Rua { get; set; }
    public int Posicao { get; set; }
    public int Altura { get; set; }
    public int Profundidade { get; set; }
    public int CodigoFilial { get; set; }
}
