using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Filiais.Requests;
using GestaoProdutos.DataTransfer.Filiais.Responses;
using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Repositorios.Filtros;
using GestaoProdutos.Dominio.Filiais.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Filiais.Profiles;

public class FiliaisProfile : Profile
{
    public FiliaisProfile()
    {
        CreateMap<FilialInserirRequest, FilialInserirComando>();
        CreateMap<FilialEditarRequest, FilialEditarComando>();
        CreateMap<FilialListarRequest, FilialListarFiltro>();
        CreateMap<Filial, FilialResponse>();
        CreateMap<PaginacaoConsulta<Filial>, PaginacaoConsulta<FilialResponse>>();
    }
}
