using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Usuarios.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Usuarios.Requests;
using GestaoProdutos.DataTransfer.Usuarios.Responses;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios.Filtros;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;
using GestaoProdutos.Dominio.Usuarios.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Usuarios.Servicos;

public class UsuariosAppServico : IUsuariosAppServico
{
    private readonly IUsuariosServico usuariosServico;
    private readonly IUsuariosRepositorio usuariosRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<UsuariosAppServico> logger;

    public UsuariosAppServico(IUsuariosServico usuariosServico, IUsuariosRepositorio usuariosRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<UsuariosAppServico> logger)
    {
        this.usuariosServico = usuariosServico;
        this.usuariosRepositorio = usuariosRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public UsuarioResponse Editar(int id, UsuarioEditarRequest request)
    {
        UsuarioEditarComando comando = mapper.Map<UsuarioEditarComando>(request);
        comando.Id = id;
        try
        {
            unitOfWork.BeginTransaction();

            Usuario usuario = usuariosServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<UsuarioResponse>(usuario);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "UsuariossAppServico", "Editar", "Usuario");
            throw;
        }
    }

    public void Inativar(int id)
    {
        Usuario usuario = usuariosServico.Validar(id);
        try
        {
            unitOfWork.BeginTransaction();
            usuariosRepositorio.Inativar(usuario);
            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "UsuariosAppServico", "Inativar", "Usuario");
            throw;
        }
    }

    public UsuarioResponse Inserir(UsuarioInserirRequest request)
    {
        UsuarioInserirComando comando = mapper.Map<UsuarioInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Usuario usuario = usuariosServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<UsuarioResponse>(usuario);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "UsuariosAppServico", "Inserir", "Usuario");
            throw;
        }
    }

    public PaginacaoConsulta<UsuarioResponse> Listar(UsuarioListarRequest request)
    {
        UsuarioListarFiltro filtro = mapper.Map<UsuarioListarFiltro>(request);

        IQueryable<Usuario> query = usuariosRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Usuario> Usuarios = usuariosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<UsuarioResponse>>(Usuarios);
    }

    public UsuarioResponse Recuperar(int id)
    {
        Usuario usuario = usuariosServico.Validar(id);
        return mapper.Map<UsuarioResponse>(usuario);
    }
}
