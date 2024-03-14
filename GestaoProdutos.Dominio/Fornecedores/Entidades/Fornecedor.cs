using System.Text.RegularExpressions;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace GestaoProdutos.Dominio.Fornecedores.Entidades;

public class Fornecedor
{
    public virtual int Codigo { get; protected set; }
    public virtual string Descricao { get; protected set; }
    public virtual string Cnpj { get; protected set; }

    protected Fornecedor(){}

    public Fornecedor(string descricao, string cnpj)
    {
        SetDescricao(descricao);
        SetCnpj(cnpj);
    }

    public virtual void SetDescricao(string descricao)
    {
        if (String.IsNullOrWhiteSpace(descricao))
        {
            throw new AtributoObrigatorioExcecao("O campo Descricao deve ser preenchido.");
        }
        if (descricao.Length > 255 || descricao.Length < 3)
        {
            throw new TamanhoDeAtributoInvalidoExcecao("Descrição inválida.");
        }
        Descricao = descricao;
    }

    public virtual void SetCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            throw new AtributoObrigatorioExcecao("CNPJ");

        bool validador = Regex.IsMatch(cnpj, @"^(\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}|\d{14})$");

        if (cnpj!.Replace(".", "").Replace("-", "").Replace("/", "").Length != 14)
            throw new TamanhoDeAtributoInvalidoExcecao("CNPJ");

        if (!validador)
            throw new AtributoInvalidoExcecao("CNPJ");

        Cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
    }
 
}
