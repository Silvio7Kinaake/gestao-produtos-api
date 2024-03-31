using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Cidades.Servicos.Interfaces;

public interface ICidadesServico
{
    Cidade Inserir(CidadeInserirComando comando);
    Cidade Editar(CidadeEditarComando comando);
    Cidade Validar(int id);
    Cidade Instanciar(CidadeInserirComando comando);
}
