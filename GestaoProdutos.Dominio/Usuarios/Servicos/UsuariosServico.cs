using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;
using GestaoProdutos.Dominio.Usuarios.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Usuarios.Servicos;

public class UsuariosServico : IUsuariosServico
{
    private readonly IUsuariosRepositorio usuariosRepositorio;

    public UsuariosServico(IUsuariosRepositorio usuariosRepositorio)
    {
        this.usuariosRepositorio = usuariosRepositorio;
    }

    public Usuario Editar(UsuarioEditarComando comando)
    {
        Usuario usuario = Validar(comando.Id);
        usuario.SetNome(comando.Nome);
        usuario.SetEmail(comando.Email);
        usuariosRepositorio.Editar(usuario);
        return usuario;
    }

    public Usuario Inserir(UsuarioInserirComando comando)
    {
        Usuario usuario = Instanciar(comando);
        usuariosRepositorio.Inserir(usuario);
        return usuario;
    }

    public Usuario Instanciar(UsuarioInserirComando comando)
    {
        return new(comando.Id, comando.Nome, comando.Email, comando.Senha);
    }

    public Usuario Validar(int id)
    {
        Usuario usuario = usuariosRepositorio.Recuperar(id);
        if (usuario is null)
        {
            throw new RegraDeNegocioExcecao("Usuario não encontrado");
        }
        return usuario;
    }
}
