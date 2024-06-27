using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Usuarios.Requests;
using GestaoProdutos.DataTransfer.Usuarios.Responses;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios.Filtros;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Usuarios.Profiles;

public class UsuariosProfile : Profile
{
    public UsuariosProfile()
    {
        CreateMap<UsuarioInserirRequest, UsuarioInserirComando>();
        CreateMap<UsuarioEditarRequest, UsuarioEditarComando>();
        CreateMap<UsuarioListarRequest, UsuarioListarFiltro>();
        CreateMap<Usuario, UsuarioResponse>();
        CreateMap<PaginacaoConsulta<Usuario>, PaginacaoConsulta<UsuarioResponse>>();
    } 
}
