using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Cidades.Repositorios;

public interface ICidadesRepositorio : IRepositorioNHibernate<Cidade>
{
    IQueryable<Cidade> Filtrar(CidadeListarFiltro filtro);
}
