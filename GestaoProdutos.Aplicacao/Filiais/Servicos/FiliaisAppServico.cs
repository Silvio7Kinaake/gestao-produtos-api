using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Filiais.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Filiais.Requests;
using GestaoProdutos.DataTransfer.Filiais.Responses;
using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Repositorios;
using GestaoProdutos.Dominio.Filiais.Repositorios.Filtros;
using GestaoProdutos.Dominio.Filiais.Servicos.Comandos;
using GestaoProdutos.Dominio.Filiais.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Filiais.Servicos;

public class FiliaisAppServico : IFiliaisAppServico
{
    private readonly IFiliaisServico filiaisServico;
    private readonly IFiliaisRepositorio filiaisRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<FiliaisAppServico> logger;

    public FiliaisAppServico(IFiliaisServico filiaisServico, IFiliaisRepositorio filiaisRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<FiliaisAppServico> logger)
    {
        this.filiaisServico = filiaisServico;
        this.filiaisRepositorio = filiaisRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public FilialResponse Editar(int codigo, FilialEditarRequest request)
    {
        FilialEditarComando comando = mapper.Map<FilialEditarComando>(request);
        comando.Codigo = codigo;
        try
        {
            unitOfWork.BeginTransaction();

            Filial filial = filiaisServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<FilialResponse>(filial);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FiliaisAppServico", "Editar", "Filiais");
            throw;
        }
    }

    public FilialResponse Inserir(FilialInserirRequest request)
    {
        FilialInserirComando comando = mapper.Map<FilialInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Filial filial = filiaisServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<FilialResponse>(filial);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FiliaisAppServico", "Inserir", "Filial");
            throw;
        }
    }

    public PaginacaoConsulta<FilialResponse> Listar(FilialListarRequest request)
    {
        FilialListarFiltro filtro = mapper.Map<FilialListarFiltro>(request);

        IQueryable<Filial> query = filiaisRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Filial> Filiais = filiaisRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<FilialResponse>>(Filiais);
    }

    public FilialResponse Recuperar(int codigo)
    {
        Filial filial = filiaisServico.Validar(codigo);
        return mapper.Map<FilialResponse>(filial);
    }

    public void Inativar(int codigo)
    {
        Filial filial = filiaisServico.Validar(codigo);
        try
        {
            unitOfWork.BeginTransaction();
            filiaisRepositorio.Inativar(filial);
            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FiliaisAppServico", "Inativar", "Filiais");
            throw;
        }
    }
}
