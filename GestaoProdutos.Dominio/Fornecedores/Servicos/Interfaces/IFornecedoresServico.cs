using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;

public interface IFornecedoresServico
{
    Fornecedor Inserir(FornecedorInserirComando comando);
    Fornecedor Editar(FornecedorEditarComando comando);
    Fornecedor Validar(int codigo);
    Fornecedor Instanciar(FornecedorInserirComando comando);
}
