using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Cidades.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Cidades.Requests;
using GestaoProdutos.DataTransfer.Cidades.Responses;
using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Repositorios;
using GestaoProdutos.Dominio.Cidades.Repositorios.Filtros;
using GestaoProdutos.Dominio.Cidades.Servicos.Comandos;
using GestaoProdutos.Dominio.Cidades.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Cidades.Servicos;

public class CidadesAppServico : ICidadesAppServico
{
    private readonly ICidadesServico cidadesServico;
    private readonly ICidadesRepositorio cidadesRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<CidadesAppServico> logger;

    public CidadesAppServico(ICidadesServico cidadesServico, ICidadesRepositorio cidadesRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CidadesAppServico> logger)
    {
        this.cidadesServico = cidadesServico;
        this.cidadesRepositorio = cidadesRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public CidadeResponse Editar(int id, CidadeEditarRequest request)
    {
        CidadeEditarComando comando = mapper.Map<CidadeEditarComando>(request);
        comando.Id = id;
        try
        {
            unitOfWork.BeginTransaction();

            Cidade cidade = cidadesServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<CidadeResponse>(cidade);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "CidadesAppServico", "Editar", "Cidade");
            throw;
        }
    }

    public CidadeResponse Inserir(CidadeInserirRequest request)
    {
        CidadeInserirComando comando = mapper.Map<CidadeInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Cidade cidade = cidadesServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<CidadeResponse>(cidade);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "CidadesAppServico", "Inserir", "Cidade");
            throw;
        }
    }

    public PaginacaoConsulta<CidadeResponse> Listar(CidadeListarRequest request)
    {
        CidadeListarFiltro filtro = mapper.Map<CidadeListarFiltro>(request);

        IQueryable<Cidade> query = cidadesRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Cidade> cidades = cidadesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<CidadeResponse>>(cidades);
    }

    public CidadeResponse Recuperar(int id)
    {
        Cidade cidade = cidadesServico.Validar(id);
        return mapper.Map<CidadeResponse>(cidade);
    }
}
