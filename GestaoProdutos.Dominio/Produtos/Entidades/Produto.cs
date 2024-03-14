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
        public virtual DateTime DataFabricacao { get; protected set; }
        public virtual DateTime DataValidade { get; protected set; }

        protected Produto() { }

        public Produto(string descricao, Fornecedor fornecedor, DateTime dataFabricacao, DateTime dataValidade)
        {
            SetDescricao(descricao);
            SetFornecedor(fornecedor);
            SetSituacao(AtivoInativoEnum.Ativo);
            SetDataFabricacao(dataFabricacao);
            SetDataValidade(dataValidade);
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

        public virtual void SetDataFabricacao(DateTime dataFabricacao)
        {
            DataFabricacao = dataFabricacao;
        }

        public virtual void SetDataValidade(DateTime dataValidade)
        {
            if (DataFabricacao >= dataValidade)
            {
                throw new RegraDeNegocioExcecao("A data de fabricação não pode ser maior ou igual a data de validade");
            }
            if (dataValidade <= DataFabricacao)
            {
                throw new RegraDeNegocioExcecao("A data de validade não pode ser menor ou igual a data de fabricação.");
            }

            DataValidade = dataValidade;
        }

        public static object CreateNew()
        {
            throw new NotImplementedException();
        }
    }
}