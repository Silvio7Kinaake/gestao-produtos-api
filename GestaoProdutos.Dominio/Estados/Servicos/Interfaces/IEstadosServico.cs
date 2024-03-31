using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Estados.Servicos.Interfaces;

public interface IEstadosServico
{
    Estado Inserir(EstadoInserirComando comando);
    Estado Editar(EstadoEditarComando comando);
    Estado Validar(int codigo);
    Estado Instanciar(EstadoInserirComando comando);
}
