using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Repositorios;
using GestaoProdutos.Dominio.Lotes.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Lotes.Repositorios;

public class LotesRepositorio : RepositorioNHibernate<Lote>, ILotesRepositorio
{
    public LotesRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Lote> Filtrar(LoteListarFiltro filtro)
    {
        IQueryable<Lote> query = Query();

        if (filtro.Id > 0)
        {
            query = query.Where(x => x.Id == filtro.Id);
        }

        if (filtro.Quantidade > 0)
        {
            query = query.Where(x => x.Quantidade == filtro.Quantidade);
        }

        if (filtro.CodigoProduto != 0)
        {
            query = query.Where(x => x.Produto.Codigo == filtro.CodigoProduto);
        }

        if (filtro.DataFabricacao != null)
        {
            query = query.Where(x => x.DataFabricacao == filtro.DataFabricacao);
        }

        if (filtro.DataValidade != null)
        {
            query = query.Where(x => x.DataValidade == filtro.DataValidade);
        }

        return query;
    }
}
