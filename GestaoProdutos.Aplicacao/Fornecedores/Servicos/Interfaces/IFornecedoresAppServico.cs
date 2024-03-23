using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Fornecedores.Requests;
using GestaoProdutos.DataTransfer.Responses;

namespace GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces;

public interface IFornecedoresAppServico
{
    FornecedorResponse Inserir(FornecedorInserirRequest request);
    FornecedorResponse Recuperar(int codigo);
    PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request);
    FornecedorResponse Editar(int codigo, FornecedorEditarRequest request);
    void Inativar(int codigo);
}
