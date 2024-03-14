using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comandos;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Fornecedores.Servicos;

public class FornecedoresServico : IFornecedoresServico
{
    private readonly IFornecedoresRepositorio fornecedoresRepositorio;

    public FornecedoresServico(IFornecedoresRepositorio fornecedoresRepositorio)
    {
        this.fornecedoresRepositorio = fornecedoresRepositorio;
    }

    public Fornecedor Inserir(FornecedorInserirComando comando)
    {
        Fornecedor fornecedor = Instanciar(comando);
        fornecedoresRepositorio.Inserir(fornecedor);
        return fornecedor;
    }

    public Fornecedor Instanciar(FornecedorInserirComando comando)
    {
        return new(comando.Descricao, comando.Cnpj);
    }
    
    public Fornecedor Editar(FornecedorEditarComando comando)
    {
        Fornecedor fornecedor = Validar(comando.Codigo);
        fornecedor.SetCnpj(comando.Cnpj);
        fornecedor.SetDescricao(comando.Descricao);
        fornecedoresRepositorio.Editar(fornecedor);
        return fornecedor;
    }

    public Fornecedor Validar(int codigo)
    {
        Fornecedor fornecedor = fornecedoresRepositorio.Recuperar(codigo);
        if(fornecedor is null)
        {
            throw new RegraDeNegocioExcecao("Fornecedor não encontrado");
        }
        return fornecedor;
    }
}
