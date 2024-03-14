using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Fornecedores;

public class FornecedorTestes
{
    private readonly Fornecedor sut;
    public FornecedorTestes()
    {
        sut = Builder<Fornecedor>.CreateNew().Build();
    }

    public class SetDescricaoMetodo : FornecedorTestes
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

    public class SetCnpj : FornecedorTestes
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Dado_CnpNuloOuEspacoEmBranco_Espero_Excecao(string cnpj)
        {
            sut.Invoking(s => s.SetCnpj(cnpj)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("12.345.678/0001-900")]
        public void Dado_CnpjTiverTamanhoInvalido(string cnpj)
        {
            sut.Invoking(s => s.SetCnpj(cnpj)).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
        }

        [Theory]
        [InlineData("12.345.678/0001-9a")]
        [InlineData("12.345.678/0001-a ")]
        [InlineData("12.345.678/0001-as")]
        public void Dado_CnpjContemCaracteresEspeciais_E_FormatoInvalido(string cnpj)
        {
            sut.Invoking(s => s.SetCnpj(cnpj)).Should().Throw<AtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_CnpjValido_Espero_PropriedadePreenchida()
        {
            sut.SetCnpj("12345678910123");
            sut.Cnpj.Should().NotBeNullOrWhiteSpace();
            sut.Cnpj.Should().Be("12345678910123");
        }
    }


}
