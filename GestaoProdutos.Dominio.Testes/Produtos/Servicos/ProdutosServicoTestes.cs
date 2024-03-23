using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Produtos.Servicos;

public class ProdutosServicoTestes
{
    private readonly ProdutosServico sut;
    private readonly IProdutosRepositorio produtosRepositorio;
    private readonly IFornecedoresServico fornecedoresServico;
    private readonly Produto produtoValido;
    private readonly ProdutoInserirComando comando;
    private readonly ProdutoEditarComando editarComando;

    public ProdutosServicoTestes()
    {
        produtoValido = Builder<Produto>.CreateNew().Build();
        produtosRepositorio = Substitute.For<IProdutosRepositorio>();
        fornecedoresServico = Substitute.For<IFornecedoresServico>();
        sut = new ProdutosServico(produtosRepositorio, fornecedoresServico);

        comando = Builder<ProdutoInserirComando>.CreateNew()
        .With(x => x.Descricao, "Produto Teste")
        .Build();

        editarComando = Builder<ProdutoEditarComando>.CreateNew()
        .With(x => x.Descricao, "Produto Teste")
        .Build();

    }

    public class ValidarMetodo : ProdutosServicoTestes
    {
        [Fact]
        public void Quando_ProdutoNaoEncontrado_Espero_Excecao()
        {
            produtosRepositorio.Recuperar(Arg.Any<int>()).ReturnsNull();
            sut.Invoking(x => x.Validar(1)).Should().Throw<RegraDeNegocioExcecao>();
        }

        [Fact]
        public void Dado_ProdutoEncontrado_Espero_ProdutoValido()
        {
            produtosRepositorio.Recuperar(Arg.Any<int>()).Returns(produtoValido);
            var resultado = sut.Validar(1);
            resultado.Should().BeSameAs(produtoValido);
        }
    }

    public class EditarMetodo : ProdutosServicoTestes
    {
        [Fact]
        public void Dado_MetodoChamado_Espero_ProdutoAtualizado()
        {
            produtosRepositorio.Recuperar(1).Returns(produtoValido);

            sut.Editar(editarComando);

            produtoValido.Descricao.Should().Be(comando.Descricao);

            produtosRepositorio.Received().Editar(produtoValido);
        }
    }

    public class InstanciarMetodo : ProdutosServicoTestes
    {
        [Fact]
        public void Dado_ParametrosParaCriarProdutoEspero_ProdutoInstanciado()
        {
            var resultado = sut.Instanciar(comando);

            resultado.Should().NotBeNull();

            resultado.Descricao.Should().Be(comando.Descricao);
        }
    }


    public class InserirMetodo : ProdutosServicoTestes
    {
        [Fact]
        public void Dado_produtoValido_Espero_ProdutoInserido()
        {
            produtosRepositorio.Inserir(Arg.Any<Produto>());

            Produto resultado = sut.Inserir(comando);

            produtosRepositorio.Received(1).Inserir(Arg.Any<Produto>());

            resultado.Should().BeOfType<Produto>();
        }
    }

}
