using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Produtos.Profiles;

public class ProdutosProfile: Profile
{
    public ProdutosProfile()
    {
        CreateMap<ProdutoInserirRequest, ProdutoInserirComando>();
        CreateMap<ProdutoEditarRequest, ProdutoEditarComando>();
        CreateMap<ProdutoListarRequest, ProdutoListarFiltro>();
        CreateMap<Produto, ProdutoResponse>();
        CreateMap<PaginacaoConsulta<Produto>, PaginacaoConsulta<ProdutoResponse>>();
}   }
