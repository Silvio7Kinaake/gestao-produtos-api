using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Fornecedores.Repositorios;

public interface IFornecedoresRepositorio : IRepositorioNHibernate<Fornecedor>
{
    IQueryable<Fornecedor> Filtrar(FornecedorListarFiltro filtro);
    void Inativar(Fornecedor fornecedor);
}
