using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.Dominio.Produtos.Entidades
{
    public class Produto
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual Fornecedor Fornecedor { get; protected set; }
        public virtual AtivoInativoEnum Situacao { get; protected set; }

        protected Produto() { }

        public Produto(string descricao, Fornecedor fornecedor)
        {
            SetDescricao(descricao);
            SetFornecedor(fornecedor);
            SetSituacao(AtivoInativoEnum.Ativo);
        }

        public virtual void SetDescricao(string descricao)
        {
            if (String.IsNullOrWhiteSpace(descricao))
            {
                throw new AtributoObrigatorioExcecao("O campo Descricao deve ser preenchido.");
            }
            if (descricao.Length > 255 || descricao.Length < 3)
            {
                throw new TamanhoDeAtributoInvalidoExcecao("Descricão inválida.");
            }
            Descricao = descricao;
        }

        public virtual void SetFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor is null)
            {
                throw new AtributoObrigatorioExcecao("Fornecedor");
            }

            Fornecedor = fornecedor;
        }

        public virtual void SetSituacao(AtivoInativoEnum situacao)
        {
            Situacao = situacao;
        }
    }
}