using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Usuarios.Servicos.Interfaces;

public interface IUsuariosServico
{
    Usuario Inserir(UsuarioInserirComando comando);
    Usuario Editar(UsuarioEditarComando comando);
    Usuario Validar(int id);
    Usuario Instanciar(UsuarioInserirComando comando);
}
