using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Produtos.Repositorios;

public interface IProdutosRepositorio: IRepositorioNHibernate<Produto>
{
     IQueryable<Produto> Filtrar(ProdutoListarFiltro filtro);
     void Inativar(Produto produto);
}
