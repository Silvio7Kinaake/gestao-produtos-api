using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Filiais.Repositorios;

public interface IFiliaisRepositorio : IRepositorioNHibernate<Filial>
{
    IQueryable<Filial> Filtrar(FilialListarFiltro filtro);
    void Inativar(Filial filial);
}
