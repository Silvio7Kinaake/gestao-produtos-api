using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Lotes.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Lotes.Request;
using GestaoProdutos.DataTransfer.Lotes.Response;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Repositorios;
using GestaoProdutos.Dominio.Lotes.Repositorios.Filtros;
using GestaoProdutos.Dominio.Lotes.Servicos.Comandos;
using GestaoProdutos.Dominio.Lotes.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Lotes.Servicos;

public class LotesAppServico : ILotesAppServico
{
    private readonly ILotesServico lotesServico;
    private readonly ILotesRepositorio lotesRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<LotesAppServico> logger;

    public LotesAppServico(ILotesServico lotesServico, ILotesRepositorio lotesRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<LotesAppServico> logger)
    {
        this.lotesServico = lotesServico;
        this.lotesRepositorio = lotesRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public LoteResponse Editar(int id, LoteEditarRequest request)
    {
        LoteEditarComando comando = mapper.Map<LoteEditarComando>(request);
        comando.Id = id;
        try
        {
            unitOfWork.BeginTransaction();

            Lote lote = lotesServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<LoteResponse>(lote);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "LotesAppServico", "Editar", "Lote");
            throw;
        }
    }

    public LoteResponse Inserir(LoteInserirRequest request)
    {
         LoteInserirComando comando = mapper.Map<LoteInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Lote lote = lotesServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<LoteResponse>(lote);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "LotesAppServico", "Inserir", "Lote");
            throw;
        }
    }

    public PaginacaoConsulta<LoteResponse> Listar(LoteListarRequest request)
    {
        LoteListarFiltro filtro = mapper.Map<LoteListarFiltro>(request);

        IQueryable<Lote> query = lotesRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Lote> Lotes = lotesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<LoteResponse>>(Lotes);
    }

    public LoteResponse Recuperar(int id)
    {
        Lote lote = lotesServico.Validar(id);
        return mapper.Map<LoteResponse>(lote);
    }
}
