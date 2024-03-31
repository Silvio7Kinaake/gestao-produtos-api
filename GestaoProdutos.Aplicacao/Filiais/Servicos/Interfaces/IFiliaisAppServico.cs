using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Filiais.Requests;
using GestaoProdutos.DataTransfer.Filiais.Responses;

namespace GestaoProdutos.Aplicacao.Filiais.Servicos.Interfaces;

public interface IFiliaisAppServico
{
    FilialResponse Inserir(FilialInserirRequest request);
    FilialResponse Recuperar(int codigo);
    PaginacaoConsulta<FilialResponse> Listar(FilialListarRequest request);
    FilialResponse Editar(int codigo, FilialEditarRequest request);
    void Inativar(int codigo);
}
