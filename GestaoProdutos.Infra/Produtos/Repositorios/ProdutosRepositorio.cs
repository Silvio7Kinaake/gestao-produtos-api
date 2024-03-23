using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Produtos.Repositorios;

public class ProdutosRepositorio : RepositorioNHibernate<Produto>, IProdutosRepositorio
{
    public ProdutosRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Produto> Filtrar(ProdutoListarFiltro filtro)
    {
        IQueryable<Produto> query = Query().Where(x => x.Situacao == AtivoInativoEnum.Ativo);

        if (filtro.Codigo > 0)
        {
            query = query.Where(x => x.Codigo == filtro.Codigo);
        }

        if (!string.IsNullOrWhiteSpace(filtro.Descricao))
        {
            query = query.Where(x => x.Descricao == filtro.Descricao);
        }

        if(filtro.CodigoFornecedor != 0)
        {
            query = query.Where(x => x.Fornecedor.Codigo == filtro.CodigoFornecedor);
        }

        return query;
    }

    public void Inativar(Produto produto)
    {
        produto.SetSituacao(AtivoInativoEnum.Inativo);
        Editar(produto);
    }
}
