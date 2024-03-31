using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Repositorios;
using GestaoProdutos.Dominio.Cidades.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Cidades.Repositorios;

public class CidadesRepositorio : RepositorioNHibernate<Cidade>, ICidadesRepositorio
{
    public CidadesRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Cidade> Filtrar(CidadeListarFiltro filtro)
    {
        IQueryable<Cidade> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.Descricao))
        {
            query = query.Where(d => d.Descricao.Contains(filtro.Descricao));
        }

        return query;

    }
}
