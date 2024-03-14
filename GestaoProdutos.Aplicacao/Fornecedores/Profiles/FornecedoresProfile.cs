using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Fornecedores.Requests;
using GestaoProdutos.DataTransfer.Responses;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Fornecedores.Profiles;

public class FornecedoresProfile : Profile
{
    public FornecedoresProfile()
    {
        CreateMap<FornecedorInserirRequest, FornecedorInserirComando>();
        CreateMap<FornecedorEditarRequest, FornecedorEditarComando>();
        CreateMap<FornecedorListarRequest, FornecedorListarFiltro>();
        CreateMap<Fornecedor, FornecedorResponse>();
        CreateMap<PaginacaoConsulta<Fornecedor>, PaginacaoConsulta<FornecedorResponse>>();
    }
}
