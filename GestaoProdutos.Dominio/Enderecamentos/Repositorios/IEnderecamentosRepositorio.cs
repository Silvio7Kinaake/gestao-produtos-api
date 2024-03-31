using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Enderecamentos.Repositorios;

public interface IEnderecamentosRepositorio : IRepositorioNHibernate<Enderecamento>
{
    IQueryable<Enderecamento> Filtrar(EnderecamentoListarFiltro filtro);
    void Inativar(Enderecamento enderecamento);
}
