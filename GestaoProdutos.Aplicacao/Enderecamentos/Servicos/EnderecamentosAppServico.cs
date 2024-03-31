using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Enderecamentos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Enderecamentos.Requests;
using GestaoProdutos.DataTransfer.Enderecamentos.Responses;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Comandos;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Enderecamentos.Servicos;

public class EnderecamentosAppServico : IEnderecamentosAppServico
{
    private readonly IEnderecamentosServico enderecamentosServico;
    private readonly IEnderecamentosRepositorio enderecamentosRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<EnderecamentosAppServico> logger;

    public EnderecamentosAppServico(IEnderecamentosServico enderecamentosServico, IEnderecamentosRepositorio enderecamentosRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<EnderecamentosAppServico> logger)
    {
        this.enderecamentosServico = enderecamentosServico;
        this.enderecamentosRepositorio = enderecamentosRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public EnderecamentoResponse Editar(int id, EnderecamentoEditarRequest request)
    {
        EnderecamentoEditarComando comando = mapper.Map<EnderecamentoEditarComando>(request);
        comando.Id = id;
        try
        {
            unitOfWork.BeginTransaction();

            Enderecamento enderecamento = enderecamentosServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<EnderecamentoResponse>(enderecamento);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "EnderecamentosAppServico", "Editar", "Enderecamento");
            throw;
        }
    }

    public EnderecamentoResponse Inserir(EnderecamentoInserirRequest request)
    {
        EnderecamentoInserirComando comando = mapper.Map<EnderecamentoInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Enderecamento enderecamento = enderecamentosServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<EnderecamentoResponse>(enderecamento);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "EnderecamentosAppServico", "Inserir", "Enderecamento");
            throw;
        }
    }

    public PaginacaoConsulta<EnderecamentoResponse> Listar(EnderecamentoListarRequest request)
    {
        EnderecamentoListarFiltro filtro = mapper.Map<EnderecamentoListarFiltro>(request);

        IQueryable<Enderecamento> query = enderecamentosRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Enderecamento> Enderecamento = enderecamentosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<EnderecamentoResponse>>(Enderecamento);
    }

    public EnderecamentoResponse Recuperar(int id)
    {
        Enderecamento enderecamento = enderecamentosServico.Validar(id);
        return mapper.Map<EnderecamentoResponse>(enderecamento);
    }

    public void Inativar(int id)
    {
        Enderecamento enderecamento = enderecamentosServico.Validar(id);
        try
        {
            unitOfWork.BeginTransaction();
            enderecamentosRepositorio.Inativar(enderecamento);
            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "EnderecamentosAppServico", "Inativar", "Enderecamento ");
            throw;
        }
    }
}
