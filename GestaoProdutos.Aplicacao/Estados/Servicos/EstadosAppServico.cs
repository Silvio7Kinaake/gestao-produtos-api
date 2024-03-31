using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Estados.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Estados.Requests;
using GestaoProdutos.DataTransfer.Estados.Responses;
using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Repositorios;
using GestaoProdutos.Dominio.Estados.Repositorios.Filtros;
using GestaoProdutos.Dominio.Estados.Servicos.Comandos;
using GestaoProdutos.Dominio.Estados.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Estados.Servicos;

public class EstadosAppServico : IEstadosAppServico
{
    private readonly IEstadosServico estadosServico;
    private readonly IEstadosRepositorio estadosRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<EstadosAppServico> logger;

    public EstadosAppServico(IEstadosServico estadosServico, IEstadosRepositorio estadosRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<EstadosAppServico> logger)
    {
        this.estadosServico = estadosServico;
        this.estadosRepositorio = estadosRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public EstadoResponse Editar(int codigo, EstadoEditarRequest request)
    {
        EstadoEditarComando comando = mapper.Map<EstadoEditarComando>(request);
        comando.Codigo = codigo;
        try
        {
            unitOfWork.BeginTransaction();

            Estado estado = estadosServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<EstadoResponse>(estado);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "EstadosAppServico", "Editar", "Estado");
            throw;
        }
    }

    public EstadoResponse Inserir(EstadoInserirRequest request)
    {
        EstadoInserirComando comando = mapper.Map<EstadoInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Estado estado = estadosServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<EstadoResponse>(estado);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventCodigo}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "EstadosAppServico", "Inserir", "Estado");
            throw;
        }
    }

    public PaginacaoConsulta<EstadoResponse> Listar(EstadoListarRequest request)
    {
        EstadoListarFiltro filtro = mapper.Map<EstadoListarFiltro>(request);

        IQueryable<Estado> query = estadosRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Estado> estados = estadosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<EstadoResponse>>(estados);
    }

    public EstadoResponse Recuperar(int codigo)
    {
        Estado estado = estadosServico.Validar(codigo);
        return mapper.Map<EstadoResponse>(estado);
    }
}
