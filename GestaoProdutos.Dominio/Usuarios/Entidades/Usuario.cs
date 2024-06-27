using System.Text.RegularExpressions;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace GestaoProdutos.Dominio.Usuarios.Entidades;

public class Usuario
{
    public virtual int Id { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual string Email { get; protected set; }
    public virtual string Senha { get; protected set; }
    public virtual AtivoInativoEnum Situacao { get; protected set; }

    protected Usuario() { }

    public Usuario(int id, string nome, string email, string senha)
    {
        SetNome(nome);
        SetEmail(email);
        SetSenha(senha);
        SetSituacao(AtivoInativoEnum.Ativo);
    }

    public virtual void SetNome(string nome)
    {
        if (String.IsNullOrWhiteSpace(nome))
        {
            throw new AtributoObrigatorioExcecao("O campo nome deve ser preenchido.");
        }
        if (nome.Length > 50 || nome.Length < 5)
        {
            throw new TamanhoDeAtributoInvalidoExcecao("nome inválida.");
        }
        Nome = nome;
    }

    public virtual void SetEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9]+@\S+\.com(\.\w+)?$";
        Regex regex = new Regex(pattern);
        if (!regex.IsMatch(email))
        {
            throw new AtributoInvalidoExcecao("Email");
        }
        Email = email;
    }

    public virtual void SetSenha(string senha)
    {
        if (string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
        {
            throw new AtributoObrigatorioExcecao("Senha");
        }
        if (senha.Length < 6 || senha.Length > 10)
        {
            throw new TamanhoDeAtributoInvalidoExcecao("Senha", 6, 10);
        }
        // Verifica se a senha possui pelo menos uma letra maiúscula, uma letra minúscula,
        if (!senha.Any(c => char.IsUpper(c)))
        {
            throw new AtributoInvalidoExcecao("Senha");
        }
        if (!senha.Any(c => char.IsLower(c)))
        {
            throw new AtributoInvalidoExcecao("Senha");
        }
        // um caractere especial e um número
        if (!senha.Any(c => char.IsSymbol(c) || char.IsPunctuation(c)))
        {
            throw new AtributoInvalidoExcecao("Senha");
        }
        if (!senha.Any(c => char.IsNumber(c)))
        {
            throw new AtributoInvalidoExcecao("Senha");
        }
        Senha = senha;
    }

    public virtual void SetSituacao(AtivoInativoEnum situacao)
    {
        Situacao = situacao;
    }
}
