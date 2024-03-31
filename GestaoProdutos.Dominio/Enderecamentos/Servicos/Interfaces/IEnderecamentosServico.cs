using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Enderecamentos.Servicos.Interfaces;

public interface IEnderecamentosServico
{
    
    Enderecamento Inserir(EnderecamentoInserirComando comando);
    Enderecamento Editar(EnderecamentoEditarComando comando);
    Enderecamento Validar(int id);
    Enderecamento Instanciar(EnderecamentoInserirComando comando);
}
