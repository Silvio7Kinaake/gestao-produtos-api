using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Usuarios.Requests;
using GestaoProdutos.DataTransfer.Usuarios.Responses;

namespace GestaoProdutos.Aplicacao.Usuarios.Servicos.Interfaces;

public interface IUsuariosAppServico
{
    UsuarioResponse Inserir(UsuarioInserirRequest request);
    UsuarioResponse Recuperar(int id);
    PaginacaoConsulta<UsuarioResponse> Listar(UsuarioListarRequest request);
    UsuarioResponse Editar(int id, UsuarioEditarRequest request);
    void Inativar(int id);
}
