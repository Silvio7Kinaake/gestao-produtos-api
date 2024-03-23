using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Produtos.Entidades;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Produtos.Entidades;

public class ProdutoTestes
{
    private readonly Produto sut;
    public ProdutoTestes()
    {
        sut = Builder<Produto>.CreateNew().Build();
    }

    public class SetDescricaoMetodo : ProdutoTestes
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Dado_DescricaoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string descricao)
        {
            sut.Invoking(x => x.SetDescricao(descricao)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_DescricaoMaiorQue_255Caracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
        {
            sut.Invoking(x => x.SetDescricao(new string('*', 256)))
                .Should()
                .Throw<TamanhoDeAtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_DescricaoMenorQue3Caracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
        {
            sut.Invoking(x => x.SetDescricao(new string('*', 2)))
                .Should()
                .Throw<TamanhoDeAtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_DescricaoValida_Espero_PropriedadesPreenchidas()
        {
            sut.SetDescricao("Descricao Teste");
            sut.Descricao.Should().Be("Descricao Teste");
        }
    }

    public class SetFornecedorMetodo : ProdutoTestes
    {
        [Fact]
        public void Dado_FornecedorNulo_Espero_AtributoObrigatorioExcecao()
        {
            Fornecedor fornecedor = null;

            sut.Invoking<Produto>(x => x.SetFornecedor(fornecedor)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_FornecedorValido_Espero_PropriedadePreenchida()
        {
            Fornecedor fornecedor = Builder<Fornecedor>.CreateNew().Build();

            sut.SetFornecedor(fornecedor);

            sut.Fornecedor.Should().BeSameAs(fornecedor);
        }
    }

    public class SetSituacaoMetodo : ProdutoTestes
    {
        [Fact]
        public void Quando_SituacaoForValido_Espero_PropriedadePreenchida()
        {
            sut.SetSituacao(AtivoInativoEnum.Inativo);
            sut.Situacao.Should().Be(AtivoInativoEnum.Inativo);
        }
    }

}
