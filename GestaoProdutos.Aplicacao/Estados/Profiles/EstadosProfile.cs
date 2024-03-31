using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Estados.Requests;
using GestaoProdutos.DataTransfer.Estados.Responses;
using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Repositorios.Filtros;
using GestaoProdutos.Dominio.Estados.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Estados.Profiles;

public class EstadosProfile : Profile
{
    public EstadosProfile()
    {
        CreateMap<EstadoInserirRequest, EstadoInserirComando>();
        CreateMap<EstadoEditarRequest, EstadoEditarComando>();
        CreateMap<EstadoListarRequest, EstadoListarFiltro>();
        CreateMap<Estado, EstadoResponse>();
        CreateMap<PaginacaoConsulta<Estado>, PaginacaoConsulta<EstadoResponse>>();
    }
}
