using GestaoProdutos.Dominio.Lotes.Entidades;
using GestaoProdutos.Dominio.Lotes.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Lotes.Servicos.Interfaces;

public interface ILotesServico
{
    Lote Inserir(LoteInserirComando comando);
    Lote Editar(LoteEditarComando comando);
    Lote Validar(int id);
    Lote Instanciar(LoteInserirComando comando);
}
