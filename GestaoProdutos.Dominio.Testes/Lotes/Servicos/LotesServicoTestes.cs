using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Repositorios;
using GestaoProdutos.Dominio.Lotes.Servicos;
using GestaoProdutos.Dominio.Lotes.Servicos.Comandos;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Lotes.Servicos;

public class LotesServicoTestes
{
    private readonly LotesServico sut;
    private readonly ILotesRepositorio lotesRepositorio;
    private readonly IProdutosServico produtosServico;
    private readonly IEnderecamentosServico enderecamentosServico;
    private readonly Lote loteValido;
    private readonly LoteInserirComando comando;
    private readonly LoteEditarComando editarComando;

    public LotesServicoTestes()
    {
        loteValido = Builder<Lote>.CreateNew().Build();
        lotesRepositorio = Substitute.For<ILotesRepositorio>();
        produtosServico = Substitute.For<IProdutosServico>();
        enderecamentosServico = Substitute.For<IEnderecamentosServico>();
        sut = new LotesServico(lotesRepositorio, produtosServico, enderecamentosServico);

        var dataFabricacao = DateTime.Now;
        var dataValidade = dataFabricacao.AddMonths(1);
        comando = Builder<LoteInserirComando>.CreateNew()
        .With(x => x.DataFabricacao, dataFabricacao)
        .With(x => x.DataValidade, dataValidade)
        .Build();

        editarComando = Builder<LoteEditarComando>.CreateNew()
        .With(x => x.DataFabricacao, dataFabricacao)
        .With(x => x.DataValidade, dataValidade)
        .Build();
    }

    public class ValidarMetodo : LotesServicoTestes
    {
        [Fact]
        public void Quando_LoteNaoEncontrado_Espero_Excecao()
        {
            lotesRepositorio.Recuperar(Arg.Any<int>()).ReturnsNull();
            sut.Invoking(x => x.Validar(1)).Should().Throw<RegraDeNegocioExcecao>();
        }

        [Fact]
        public void Dado_LoteEncontrado_Espero_LoteValido()
        {
            lotesRepositorio.Recuperar(Arg.Any<int>()).Returns(loteValido);
            var resultado = sut.Validar(1);
            resultado.Should().BeSameAs(loteValido);
        }
    }

    public class EditarMetodo : LotesServicoTestes
    {
        [Fact]
        public void Dado_MetodoChamado_Espero_loteAtualizado()
        {
            lotesRepositorio.Recuperar(1).Returns(loteValido);

            sut.Editar(editarComando);

            loteValido.Quantidade.Should().Be(editarComando.Quantidade);

            loteValido.DataFabricacao.Should().Be(editarComando.DataFabricacao);
            loteValido.DataValidade.Should().Be(editarComando.DataValidade);

            lotesRepositorio.Received().Editar(loteValido);
        }

        public class InserirMetodo : LotesServicoTestes
        {
            [Fact]
            public void Dado_LoteValido_Espero_LoteInserido()
            {
                lotesRepositorio.Inserir(Arg.Any<Lote>());

                Lote resultado = sut.Inserir(comando);

                lotesRepositorio.Received(1).Inserir(Arg.Any<Lote>());

                resultado.Should().BeOfType<Lote>();
            }
        }

    }

    public class InstanciarMetodo : LotesServicoTestes
    {
        [Fact]
        public void Dado_ParametrosParaCriarLote_Espero_LoteInstanciado()
        {
            var resultado = sut.Instanciar(comando);

            resultado.Should().NotBeNull();

            resultado.Quantidade.Should().Be(comando.Quantidade);

            resultado.DataFabricacao.Should().Be(comando.DataFabricacao);
            resultado.DataValidade.Should().Be(comando.DataValidade);
        }
    }

}


