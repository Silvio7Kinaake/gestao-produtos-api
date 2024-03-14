using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;

public interface IProdutosServico
{
    Produto Inserir(ProdutoInserirComando comando);
    Produto Editar(ProdutoEditarComando comando);
    Produto Validar(int codigo);
    Produto Instanciar(ProdutoInserirComando comando);
}
