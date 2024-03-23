using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Lotes.Request;
using GestaoProdutos.DataTransfer.Lotes.Response;
using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Repositorios.Filtros;
using GestaoProdutos.Dominio.Lotes.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Lotes.Profiles;

public class LotesProfile : Profile
{
    public LotesProfile()
    {
        CreateMap<LoteInserirRequest, LoteInserirComando>();
        CreateMap<LoteEditarRequest, LoteEditarComando>();
        CreateMap<LoteListarRequest, LoteListarFiltro>();
        CreateMap<Lote, LoteResponse>();
        CreateMap<PaginacaoConsulta<Lote>, PaginacaoConsulta<LoteResponse>>();
    }
}
