using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Produtos.Servicos;

public class ProdutosAppServico : IProdutosAppServico
{
    private readonly IProdutosServico produtosServico;
    private readonly IProdutosRepositorio produtosRepositorio;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<ProdutosAppServico> logger;

    public ProdutosAppServico(IProdutosServico produtosServico, IProdutosRepositorio produtosRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProdutosAppServico> logger)
    {
        this.produtosServico = produtosServico;
        this.produtosRepositorio = produtosRepositorio;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public ProdutoResponse Editar(int codigo, ProdutoEditarRequest request)
    {
        ProdutoEditarComando comando = mapper.Map<ProdutoEditarComando>(request);
        comando.Codigo = codigo;
        try
        {
            unitOfWork.BeginTransaction();

            Produto produto = produtosServico.Editar(comando);

            unitOfWork.Commit();

            return mapper.Map<ProdutoResponse>(produto);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "ProdutosAppServico", "Editar", "Produto");
            throw;
        }
    }

    public void Inativar(int codigo)
    {
        Produto produto = produtosServico.Validar(codigo);
        try
        {
            unitOfWork.BeginTransaction();
            produtosRepositorio.Inativar(produto);
            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "ProdutosAppServico", "Inativar", "Produtos");
            throw;
        }
    }

    public ProdutoResponse Inserir(ProdutoInserirRequest request)
    {
        ProdutoInserirComando comando = mapper.Map<ProdutoInserirComando>(request);
        try
        {
            unitOfWork.BeginTransaction();

            Produto produto = produtosServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<ProdutoResponse>(produto);
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "ProdutosAppServico", "Inserir", "Produto");
            throw;
        }
    }

    public PaginacaoConsulta<ProdutoResponse> Listar(ProdutoListarRequest request)
    {
        ProdutoListarFiltro filtro = mapper.Map<ProdutoListarFiltro>(request);

        IQueryable<Produto> query = produtosRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Produto> Produtos = produtosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        return mapper.Map<PaginacaoConsulta<ProdutoResponse>>(Produtos);
    }

    public ProdutoResponse Recuperar(int codigo)
    {
        Produto produto = produtosServico.Validar(codigo);
        return mapper.Map<ProdutoResponse>(produto);
    }
}
