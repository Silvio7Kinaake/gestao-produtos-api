using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Lotes.Request;
using GestaoProdutos.DataTransfer.Lotes.Response;

namespace GestaoProdutos.Aplicacao.Lotes.Servicos.Interfaces;

public interface ILotesAppServico
{
    LoteResponse Inserir(LoteInserirRequest request);
    LoteResponse Recuperar(int id);
    PaginacaoConsulta<LoteResponse> Listar(LoteListarRequest request);
    LoteResponse Editar(int id, LoteEditarRequest request);
}
