using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Filiais.Entidades;

namespace GestaoProdutos.Dominio.Enderecamentos.Entidades;

public class Enderecamento
{
    public virtual int Id { get; protected set; }
    public virtual Filial Filial { get; protected set; }
    public virtual string Rua { get; protected set; }
    public virtual int Posicao { get; protected set; }
    public virtual int Altura { get; protected set; }
    public virtual int Profundidade { get; protected set; }
    public virtual AtivoInativoEnum Situacao { get; protected set; }

    protected Enderecamento() { }

    public Enderecamento(string rua, int posicao, int altura, int profundidade, Filial filial)
    {
        SetFilial(filial);
        SetRua(rua);
        SetPosicao(posicao);
        SetAltura(altura);
        SetProfundidade(profundidade);
        SetSituacao(AtivoInativoEnum.Ativo);
    }

    public virtual void SetFilial(Filial filial)
    {
        if (filial is null)
        {
            throw new AtributoObrigatorioExcecao("Filial");
        }
        Filial = filial;
    }

    public virtual void SetRua(string rua)
    {
        if (string.IsNullOrWhiteSpace(rua))
            throw new AtributoObrigatorioExcecao("Rua");

        Rua = rua;
    }

    public virtual void SetPosicao(int posicao)
    {
        if (posicao < 0 || posicao > 1000)
        {
            throw new RegraDeNegocioExcecao("Posicao");
        }

        Posicao = posicao;
    }

    public virtual void SetAltura(int altura)
    {
        if (altura < 0 || altura > 100)
        {
            throw new RegraDeNegocioExcecao("Altura");
        }

        Altura = altura;
    }

    public virtual void SetProfundidade(int profundidade)
    {
        if (profundidade < 0 || profundidade >10)
        {
            throw new RegraDeNegocioExcecao("Profundidade");
        }

        Profundidade = profundidade;
    }

    public virtual void SetSituacao(AtivoInativoEnum situacao)
    {
        Situacao = situacao;
    }
}
