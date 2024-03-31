using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Estados.Requests;
using GestaoProdutos.DataTransfer.Estados.Responses;

namespace GestaoProdutos.Aplicacao.Estados.Servicos.Interfaces;

public interface IEstadosAppServico
{
    EstadoResponse Inserir(EstadoInserirRequest request);
    EstadoResponse Recuperar(int codigo);
    PaginacaoConsulta<EstadoResponse> Listar(EstadoListarRequest request);
    EstadoResponse Editar(int codigo, EstadoEditarRequest request);
}
