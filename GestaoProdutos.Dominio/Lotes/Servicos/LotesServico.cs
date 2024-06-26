using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Repositorios;
using GestaoProdutos.Dominio.Lotes.Servicos.Comandos;
using GestaoProdutos.Dominio.Lotes.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Lotes.Servicos;

public class LotesServico : ILotesServico
{
    private readonly ILotesRepositorio lotesRepositorio;
    private readonly IProdutosServico produtosServico;
    private readonly IEnderecamentosServico enderecamentosServico;

    public LotesServico(ILotesRepositorio lotesRepositorio, IProdutosServico produtosServico, IEnderecamentosServico enderecamentosServico)
    {
        this.lotesRepositorio = lotesRepositorio;
        this.produtosServico = produtosServico;
        this.enderecamentosServico = enderecamentosServico;
    }

    public Lote Editar(LoteEditarComando comando)
    {
        Lote lote = Validar(comando.Id);
        Produto produto = produtosServico.Validar(comando.CodigoProduto);
        Enderecamento enderecamento = enderecamentosServico.Validar(comando.IdEnderecamento);
        lote.SetQuantidade(comando.Quantidade);
        lote.SetDataValidade(comando.DataValidade);
        lote.SetDataFabricacao(comando.DataFabricacao);
        lote.SetProduto(produto);
        lotesRepositorio.Editar(lote);
        return lote;
    }

    public Lote Inserir(LoteInserirComando comando)
    {
        Lote lote = Instanciar(comando);
        lotesRepositorio.Inserir(lote);
        return lote;
    }

    public Lote Instanciar(LoteInserirComando comando)
    {
        Produto produto = produtosServico.Validar(comando.CodigoProduto);
        Enderecamento enderecamento = enderecamentosServico.Validar(comando.IdEnderecamento);
        return new Lote(produto, comando.Quantidade, comando.DataFabricacao, comando.DataValidade, enderecamento);
    }

    public Lote Validar(int id)
    {
        Lote lote = lotesRepositorio.Recuperar(id);
        if (lote is null)
        {
            throw new RegraDeNegocioExcecao("Produto não encontrado");
        }
        return lote;
    }
}


