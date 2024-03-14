using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Produtos.Servicos;

public class ProdutosServico : IProdutosServico
{
    private readonly IProdutosRepositorio produtosRepositorio;
    private readonly IFornecedoresServico fornecedoresServico;

    public ProdutosServico(IProdutosRepositorio produtosRepositorio, IFornecedoresServico fornecedoresServico)
    {
        this.produtosRepositorio = produtosRepositorio;
        this.fornecedoresServico = fornecedoresServico;
    }

    public Produto Inserir(ProdutoInserirComando comando)
    {
        Produto produto = Instanciar(comando);
        produtosRepositorio.Inserir(produto);
        return produto;
    }


    public Produto Validar(int codigo)
    {
        Produto produto = produtosRepositorio.Recuperar(codigo);
        if (produto is null)
        {
            throw new RegraDeNegocioExcecao("Fornecedor não encontrado");
        }
        return produto;
    }

    public Produto Editar(ProdutoEditarComando comando)
    {
        Produto produto = Validar(comando.Codigo);
        Fornecedor fornecedor = fornecedoresServico.Validar(comando.Codigo);
        produto.SetDescricao(comando.Descricao);
        produto.SetDataValidade(comando.DataValidade);
        produto.SetDataFabricacao(comando.DataFabricacao);
        produto.SetFornecedor(fornecedor);
        produtosRepositorio.Editar(produto);
        return produto;
    }

    public Produto Instanciar(ProdutoInserirComando comando)
    {
        Fornecedor fornecedor = fornecedoresServico.Validar(comando.CodigoFornecedor);
        return new Produto(comando.Descricao, fornecedor, comando.DataFabricacao, comando.DataValidade);
    }
}
