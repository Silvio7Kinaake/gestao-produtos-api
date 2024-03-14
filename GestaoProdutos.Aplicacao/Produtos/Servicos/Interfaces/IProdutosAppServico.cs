using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;

namespace GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;

public interface IProdutosAppServico
{
    ProdutoResponse Inserir(ProdutoInserirRequest request);
    ProdutoResponse Recuperar(int codigo);
    PaginacaoConsulta<ProdutoResponse> Listar(ProdutoListarRequest request);
    ProdutoResponse Editar(int codigo, ProdutoEditarRequest request);
    void Inativar(int codigo);
}
