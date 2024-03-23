using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Lotes.Repositorios;

public interface ILotesRepositorio : IRepositorioNHibernate<Lote>
{
    IQueryable<Lote> Filtrar(LoteListarFiltro filtro);
}
