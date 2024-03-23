using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Produtos.Entidades;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Lotes.Entidades;

public class LoteTestes
{
    private readonly Lote sut;
    public LoteTestes()
    {
        sut = Builder<Lote>.CreateNew().Build();
    }

    public class SetQuantidadeMetodo : LoteTestes
    {
        [Theory]
        [InlineData(-1)]
        public void Dado_QuantidadeMenorQueZero__Espero_Excecao(int quantidade)
        {
            sut.Invoking(x => x.SetQuantidade(quantidade)).Should().Throw<AtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_QuantidadeValido_Espero_PropriedadesPreenchidas()
        {
            int quantidade = 10;
            sut.SetQuantidade(quantidade);
            sut.Quantidade.Should().BeGreaterThan(-1);
            sut.Quantidade.Should().Be(10);
        }
    }
    public class SetDataFabricacao : LoteTestes
    {
        [Fact]
        public void Dado_DataFabricacaoValida_Espero_DataFabricacaoSetada()
        {
            var dataFabricacao = DateTime.Now;
            sut.SetDataFabricacao(dataFabricacao);
            sut.DataFabricacao.Should().Be(dataFabricacao);
        }
    }

    public class SetDataValidade : LoteTestes
    {
        [Fact]
        public void Quando_DataFabricaoMaiorQueDataValidade_Espero_RegraDeNegocioExcecao()
        {
            var dataFabricacao = DateTime.Now;
            var dataValidade = dataFabricacao.AddDays(-1);
            sut.SetDataFabricacao(dataFabricacao);

            Action action = () => sut.SetDataValidade(dataValidade);

            action.Should().Throw<RegraDeNegocioExcecao>();
        }

        [Fact]
        public void Quando_DataValidadeForAMesmaQueDataFabricacao_Espero_RegraDeNegocioExcecao()
        {
            var dataFabricacao = DateTime.Now;
            var dataValidade = dataFabricacao;
            sut.SetDataFabricacao(dataFabricacao);

            Action action = () => sut.SetDataValidade(dataValidade);

            action.Should().Throw<RegraDeNegocioExcecao>();
        }

        [Fact]
        public void Quando_DataValidadeValida_Espero_PropriedadeSetada()
        {
            var dataFabricacao = DateTime.Now;
            var dataValidade = dataFabricacao.AddMonths(1);
            sut.SetDataFabricacao(dataFabricacao);

            Action action = () => sut.SetDataValidade(dataValidade);

            action.Should().NotThrow();
            sut.DataValidade.Should().Be(dataValidade);
        }
    }

    public class SetProdutoMetodo : LoteTestes
    {
        [Fact]
        public void Dado_ProdutoNulo_Espero_AtributoObrigatorioExcecao()
        {
            Produto produto = null;

            sut.Invoking<Lote>(x => x.SetProduto(produto)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_PrdutoValido_Espero_PropriedadePreenchida()
        {
            Produto produto = Builder<Produto>.CreateNew().Build();

            sut.SetProduto(produto);

            sut.Produto.Should().BeSameAs(produto);
        }
    }
}




