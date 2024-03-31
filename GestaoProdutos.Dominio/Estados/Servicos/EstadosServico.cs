using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Repositorios;
using GestaoProdutos.Dominio.Estados.Servicos.Comandos;
using GestaoProdutos.Dominio.Estados.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Estados.Servicos;

public class EstadosServico : IEstadosServico
{
    private readonly IEstadosRepositorio estadosRepositorio;

    public EstadosServico(IEstadosRepositorio estadosRepositorio)
    {
        this.estadosRepositorio = estadosRepositorio;
    }

    public Estado Editar(EstadoEditarComando comando)
    {
        Estado estado = Validar(comando.Codigo);
        estado.SetDescricao(comando.Descricao);
        estado.SetSigla(comando.Sigla);
        estadosRepositorio.Editar(estado);
        return estado;
    }

    public Estado Inserir(EstadoInserirComando comando)
    {
        Estado estado = Instanciar(comando);
        estadosRepositorio.Inserir(estado);
        return estado;
    }

    public Estado Instanciar(EstadoInserirComando comando)
    {
        return new(comando.Descricao, comando.Sigla);
    }

    public Estado Validar(int codigo)
    {
        Estado estado = estadosRepositorio.Recuperar(codigo);
        if (estado is null)
        {
            throw new RegraDeNegocioExcecao("Estado não encontrado");
        }
        return estado;
    }
}
