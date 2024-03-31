using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Estados.Entidades;

namespace GestaoProdutos.Dominio.Cidades.Entidades;

public class Cidade
{
    public virtual int Id { get; protected set; }
    public virtual string Descricao { get; protected set; }
    public virtual Estado Estado { get; protected set; }

    protected Cidade() { }

    public Cidade(string descricao, Estado estado)
    {
        SetNome(descricao);
        SetEstado(estado);
    }

    public virtual void SetNome(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new AtributoObrigatorioExcecao("Descrição");

        if (descricao.Length > 150)
            throw new TamanhoDeAtributoInvalidoExcecao("Descrição", null, tamanhoMaximo: 150);

        Descricao = descricao;
    }
    
    public virtual void SetEstado(Estado estado)
    {
        Estado = estado;
    }
}

