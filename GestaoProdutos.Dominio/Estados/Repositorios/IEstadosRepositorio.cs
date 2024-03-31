using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Estados.Repositorios;

public interface IEstadosRepositorio : IRepositorioNHibernate<Estado>
{
    IQueryable<Estado> Filtrar(EstadoListarFiltro filtro);
}
