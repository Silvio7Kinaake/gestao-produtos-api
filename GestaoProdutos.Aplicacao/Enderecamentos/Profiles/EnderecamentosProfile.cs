using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Enderecamentos.Requests;
using GestaoProdutos.DataTransfer.Enderecamentos.Responses;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Enderecamentos.Profiles;

public class EnderecamentosProfile : Profile
{
    public EnderecamentosProfile()
    {
        CreateMap<EnderecamentoInserirRequest, EnderecamentoInserirComando>();
        CreateMap<EnderecamentoEditarRequest, EnderecamentoEditarComando>();
        CreateMap<EnderecamentoListarRequest, EnderecamentoListarFiltro>();
        CreateMap<Enderecamento, EnderecamentoResponse>();
        CreateMap<PaginacaoConsulta<Enderecamento>, PaginacaoConsulta<EnderecamentoResponse>>();
    }
}
