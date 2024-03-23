using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Servicos;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comandos;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Fornecedores.Servicos;

public class FornecedoresServicoTestes
{

    private readonly FornecedoresServico sut;
    private readonly IFornecedoresRepositorio fornecedoresRepositorio;
    private readonly Fornecedor fornecedorValido;
    private readonly FornecedorInserirComando comando;
    private readonly FornecedorEditarComando editarComando;

    public FornecedoresServicoTestes()
    {
        fornecedorValido = Builder<Fornecedor>.CreateNew().Build();
        fornecedoresRepositorio = Substitute.For<IFornecedoresRepositorio>();
        sut = new FornecedoresServico(fornecedoresRepositorio);
        comando = Builder<FornecedorInserirComando>.CreateNew()
            .With(x => x.Descricao, "Teste Fornecedor")
            .With(x => x.Cnpj, "12345678901234")
            .Build();
        editarComando = Builder<FornecedorEditarComando>.CreateNew()
           .With(x => x.Descricao, "Teste Fornecedor")
           .With(x => x.Cnpj, "12345678901234")
           .Build();
    }


    public class ValidarMetodo : FornecedoresServicoTestes
    {
        [Fact]
        public void Quando_FornecedorNaoEncontrado_Espero_Excecao()
        {
            fornecedoresRepositorio.Recuperar(Arg.Any<int>()).ReturnsNull();
            sut.Invoking(x => x.Validar(1)).Should().Throw<RegraDeNegocioExcecao>();
        }

        [Fact]
        public void Dado_FornecedorEncontrado_Espero_FornecedorValidado()
        {
            fornecedoresRepositorio.Recuperar(Arg.Any<int>()).Returns(fornecedorValido);
            Fornecedor fornecedorRetorno = sut.Validar(1);
            fornecedorRetorno.Should().BeSameAs(fornecedorValido);
        }
    }

    public class EditarMetodo : FornecedoresServicoTestes
    {
        [Fact]
        public void Dado_MetodoChamado_Espero_FornecedorAtualizado()
        {
            fornecedoresRepositorio.Recuperar(1).Returns(fornecedorValido);

            sut.Editar(editarComando);

            fornecedorValido.Descricao.Should().Be(comando.Descricao);

            fornecedorValido.Cnpj.Should().Be(comando.Cnpj);

            fornecedoresRepositorio.Received().Editar(fornecedorValido);
        }
    }

    public class InstanciarMetodo : FornecedoresServicoTestes
    {
        [Fact]
        public void Dado_ParametrosParaCriarFornecedor_Espero_FornecedorInstanciado()
        {
            Fornecedor fornecedor = sut.Instanciar(comando);

            fornecedor.Should().NotBeNull();

            fornecedor.Descricao.Should().Be(comando.Descricao);

            fornecedor.Cnpj.Should().Be(comando.Cnpj);
        }
    }


    public class InserirMetodo : FornecedoresServicoTestes
    {
        [Fact]
        public void Dado_FornecedorValido_Espero_FornecedorInserido()
        {
            fornecedoresRepositorio.Inserir(Arg.Any<Fornecedor>());

            Fornecedor fornecedor = sut.Inserir(comando);

            fornecedoresRepositorio.Received(1).Inserir(Arg.Any<Fornecedor>());

            fornecedor.Should().BeOfType<Fornecedor>();
        }
    }

}
