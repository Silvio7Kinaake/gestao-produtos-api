using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Enderecamentos.Requests;
using GestaoProdutos.DataTransfer.Enderecamentos.Responses;

namespace GestaoProdutos.Aplicacao.Enderecamentos.Servicos.Interfaces;

public interface IEnderecamentosAppServico
{
    EnderecamentoResponse Inserir(EnderecamentoInserirRequest request);
    EnderecamentoResponse Recuperar(int id);
    PaginacaoConsulta<EnderecamentoResponse> Listar(EnderecamentoListarRequest request);
    EnderecamentoResponse Editar(int id, EnderecamentoEditarRequest request);
    void Inativar(int id);
}
