using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Usuarios.Repositorios;

public class UsuariosRepositorio : RepositorioNHibernate<Usuario>, IUsuariosRepositorio
{
    public UsuariosRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Usuario> Filtrar(UsuarioListarFiltro filtro)
    {
        IQueryable<Usuario> query = Query().Where(x => x.Situacao == AtivoInativoEnum.Ativo); ;


        if (!string.IsNullOrWhiteSpace(filtro.Nome))
        {
            query = query.Where(x => x.Nome == filtro.Nome);
        }

        if (!string.IsNullOrWhiteSpace(filtro.Email))
        {
            query = query.Where(x => x.Email == filtro.Email);
        }

        return query;
    }

    public void Inativar(Usuario usuario)
    {
        usuario.SetSituacao(AtivoInativoEnum.Inativo);
        Editar(usuario);
    }
}
