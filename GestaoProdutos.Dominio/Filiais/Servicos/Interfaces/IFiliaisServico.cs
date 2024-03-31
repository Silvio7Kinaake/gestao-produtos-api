using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Filiais.Servicos.Interfaces;

public interface IFiliaisServico
{
    Filial Inserir(FilialInserirComando comando);
    Filial Editar(FilialEditarComando comando);
    Filial Validar(int codigo);
    Filial Instanciar(FilialInserirComando comando);
}
