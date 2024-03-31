using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Cidades.Requests;
using GestaoProdutos.DataTransfer.Cidades.Responses;

namespace GestaoProdutos.Aplicacao.Cidades.Servicos.Interfaces;

public interface ICidadesAppServico
{
    CidadeResponse Inserir(CidadeInserirRequest request);
    CidadeResponse Recuperar(int id);
    PaginacaoConsulta<CidadeResponse> Listar(CidadeListarRequest request);
    CidadeResponse Editar(int id, CidadeEditarRequest request);
}
