using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Cidades.Entidades;

namespace GestaoProdutos.Dominio.Filiais.Entidades;

public class Filial
{
    public virtual int Codigo { get; protected set; }
    public virtual string Descricao { get; protected set; }
    public virtual string Sigla { get; protected set; }
    public virtual Cidade Cidade { get; protected set; }
    public virtual AtivoInativoEnum Situacao { get; protected set; }

    protected Filial() { }

    public Filial(string descricao, string sigla, Cidade cidade)
    {
        SetDescricao(descricao);
        SetSigla(sigla);
        SetCidade(cidade);
        SetSituacao(AtivoInativoEnum.Ativo);
    }

    public virtual void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new AtributoObrigatorioExcecao("Descrição");

        if (descricao.Length > 150)
            throw new TamanhoDeAtributoInvalidoExcecao("Descrição", null, tamanhoMaximo: 150);

        Descricao = descricao;
    }

    public virtual void SetSigla(string sigla)
    {
        if (string.IsNullOrWhiteSpace(sigla))
            throw new AtributoObrigatorioExcecao("Sigla");

        if (sigla.Length != 4)
            throw new TamanhoDeAtributoInvalidoExcecao("Sigla", 4, 4);

        Sigla = sigla;
    }

    public virtual void SetCidade(Cidade cidade)
    {
        Cidade = cidade;
    }

    public virtual void SetSituacao(AtivoInativoEnum situacao)
    {
        Situacao = situacao;
    }
}
