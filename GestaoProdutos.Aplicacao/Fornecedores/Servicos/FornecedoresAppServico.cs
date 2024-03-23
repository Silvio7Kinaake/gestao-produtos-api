using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Fornecedores.Requests;
using GestaoProdutos.DataTransfer.Responses;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comandos;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Fornecedores.Servicos;

public class FornecedoresAppServico : IFornecedoresAppServico
{
    private readonly IFornecedoresServico fornecedoresServico;
    private readonly IFornecedoresRepositorio fornecedoresRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<FornecedoresAppServico> logger;

    public FornecedoresAppServico(IFornecedoresServico fornecedoresServico, IFornecedoresRepositorio fornecedoresRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<FornecedoresAppServico> logger)
    {
        this.fornecedoresServico = fornecedoresServico;
        this.fornecedoresRepositorio = fornecedoresRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public FornecedorResponse Inserir(FornecedorInserirRequest request)
    {
        FornecedorInserirComando comando = mapper.Map<FornecedorInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Fornecedor fornecedor = fornecedoresServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<FornecedorResponse>(fornecedor);
        }
        catch(Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FornecedoresAppServico", "Inserir", "Fornecedor");
            throw;
        }
    }

    public PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request)
    {
        FornecedorListarFiltro filtro = mapper.Map<FornecedorListarFiltro>(request);

        IQueryable<Fornecedor> query = fornecedoresRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Fornecedor> fornecedores = fornecedoresRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<FornecedorResponse>>(fornecedores);
    }

    public FornecedorResponse Recuperar(int codigo)
    {
        Fornecedor fornecedor = fornecedoresServico.Validar(codigo);
        return mapper.Map<FornecedorResponse>(fornecedor);
    }

    public FornecedorResponse Editar(int codigo, FornecedorEditarRequest request)
    {
        FornecedorEditarComando comando = mapper.Map<FornecedorEditarComando>(request);
        comando.Codigo = codigo;
        try
        {
            unitOfWork.BeginTransaction();

            Fornecedor fornecedor = fornecedoresServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<FornecedorResponse>(fornecedor);
        }
        catch(Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FornecedoresAppServico", "Editar", "Fornecedor");
            throw;
        }
    }

    public void Inativar(int codigo)
    {
        Fornecedor fornecedor = fornecedoresServico.Validar(codigo);
        try
        {
            unitOfWork.BeginTransaction();
            fornecedoresRepositorio.Inativar(fornecedor);
            unitOfWork.Commit();
        }
        catch(Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FornecedoresAppServico", "Inativar", "Fornecedor");
            throw;
        }
    }
}
