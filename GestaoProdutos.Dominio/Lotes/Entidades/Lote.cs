using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Dominio.Lotes.Entidades;

public class Lote
{
    public virtual int Id { get; protected set; }
    public virtual Produto Produto { get; protected set; }
    public virtual int Quantidade { get; protected set; }
    public virtual DateTime DataFabricacao { get; protected set; }
    public virtual DateTime DataValidade { get; protected set; }

    protected Lote() { }

    public Lote(Produto produto, int quantidade, DateTime dataFabricacao, DateTime dataValidade)
    {
        SetProduto(produto);
        SetQuantidade(quantidade);
        SetDataFabricacao(dataFabricacao);
        SetDataValidade(dataValidade);
    }

    public virtual void SetQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new AtributoInvalidoExcecao("quantidade");

        Quantidade = quantidade;
    }

    public virtual void SetProduto(Produto produto)
    {
        if (produto is null)
        {
            throw new AtributoObrigatorioExcecao("Produto");
        }

        Produto = produto;
    }

    public virtual void SetDataFabricacao(DateTime dataFabricacao)
    {
        DataFabricacao = dataFabricacao;
    }

    public virtual void SetDataValidade(DateTime dataValidade)
    {
        if (DataFabricacao >= dataValidade)
        {
            throw new RegraDeNegocioExcecao("A data de fabricação não pode ser maior ou igual a data de validade");
        }
        if (dataValidade <= DataFabricacao)
        {
            throw new RegraDeNegocioExcecao("A data de validade não pode ser menor ou igual a data de fabricação.");
        }

        DataValidade = dataValidade;
    }
}
