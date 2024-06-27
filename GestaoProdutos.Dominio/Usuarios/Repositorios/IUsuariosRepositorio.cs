using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using GestaoProdutos.Dominio.Usuarios.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Usuarios.Entidades;

public interface IUsuariosRepositorio : IRepositorioNHibernate<Usuario>
{
    IQueryable<Usuario> Filtrar(UsuarioListarFiltro filtro);
    void Inativar(Usuario usuario);
}
