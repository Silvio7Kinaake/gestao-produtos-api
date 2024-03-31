using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using GestaoProdutos.DataTransfer.Cidades.Requests;
using GestaoProdutos.DataTransfer.Cidades.Responses;
using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Repositorios.Filtros;
using GestaoProdutos.Dominio.Cidades.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Cidades.Profiles;

public class CidadesProfile: Profile
{
    public CidadesProfile()
    {
        CreateMap<CidadeInserirRequest, CidadeInserirComando>();
        CreateMap<CidadeEditarRequest, CidadeEditarComando>();
        CreateMap<CidadeListarRequest, CidadeListarFiltro>();
        CreateMap<Cidade, CidadeResponse>();
        CreateMap<PaginacaoConsulta<Cidade>, PaginacaoConsulta<CidadeResponse>>();
    }
}
