using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Repositorios;
using GestaoProdutos.Dominio.Estados.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Estados.Repositorios;

public class EstadosRepositorio : RepositorioNHibernate<Estado>, IEstadosRepositorio
{
    public EstadosRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Estado> Filtrar(EstadoListarFiltro filtro)
    {
        IQueryable<Estado> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.Descricao))
        {
            query = query.Where(x => x.Descricao == filtro.Descricao);
        }

        if (!string.IsNullOrWhiteSpace(filtro.Sigla))
        {
            query = query.Where(x => x.Sigla == filtro.Sigla);
        }

        return query;
    }
}
