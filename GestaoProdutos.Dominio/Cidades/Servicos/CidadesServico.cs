using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Repositorios;
using GestaoProdutos.Dominio.Cidades.Servicos.Comandos;
using GestaoProdutos.Dominio.Cidades.Servicos.Interfaces;
using GestaoProdutos.Dominio.Estados.Entidades;
using GestaoProdutos.Dominio.Estados.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Cidades.Servicos;

public class CidadesServico : ICidadesServico
{
    private readonly ICidadesRepositorio cidadesRepositorio;
    private readonly IEstadosServico estadosServico;

    public CidadesServico(ICidadesRepositorio cidadesRepositorio, IEstadosServico estadosServico)
    {
        this.cidadesRepositorio = cidadesRepositorio;
        this.estadosServico = estadosServico;
    }

    public Cidade Editar(CidadeEditarComando comando)
    {
        Cidade cidade = Validar(comando.Id);
        Estado estado = estadosServico.Validar(comando.CodigoEstado);
        cidade.SetNome(comando.Descricao);
        cidade.SetEstado(estado);
        cidadesRepositorio.Editar(cidade);
        return cidade;
    }

    public Cidade Inserir(CidadeInserirComando comando)
    {
        Cidade cidade = Instanciar(comando);
        cidadesRepositorio.Inserir(cidade);
        return cidade;
    }

    public Cidade Instanciar(CidadeInserirComando comando)
    {
        Estado estado = estadosServico.Validar(comando.CodigoEstado);
        return new Cidade(comando.Descricao, estado);
    }

    public Cidade Validar(int id)
    {
        Cidade cidade = cidadesRepositorio.Recuperar(id);
        if (cidade is null)
        {
            throw new RegraDeNegocioExcecao("Cidade não encontrada");
        }
        return cidade;
    }
}
