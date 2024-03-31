using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Cidades.Entidades;
using GestaoProdutos.Dominio.Cidades.Servicos.Interfaces;
using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Repositorios;
using GestaoProdutos.Dominio.Filiais.Servicos.Comandos;
using GestaoProdutos.Dominio.Filiais.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Filiais.Servicos;

public class FiliaisServico : IFiliaisServico
{
    private readonly IFiliaisRepositorio filiaisRepositorio;
    private readonly ICidadesServico cidadesServico;

    public FiliaisServico(IFiliaisRepositorio filiaisRepositorio, ICidadesServico cidadesServico)
    {
        this.filiaisRepositorio = filiaisRepositorio;
        this.cidadesServico = cidadesServico;
    }

    public Filial Editar(FilialEditarComando comando)
    {
        Filial filial = Validar(comando.Codigo);
        Cidade cidade = cidadesServico.Validar(comando.IdCidade);
        filial.SetDescricao(comando.Descricao);
        filial.SetSigla(comando.Sigla);
        filial.SetCidade(cidade);
        filiaisRepositorio.Editar(filial);
        return filial;
    }

    public Filial Inserir(FilialInserirComando comando)
    {
        Filial filial = Instanciar(comando);
        filiaisRepositorio.Inserir(filial);
        return filial;
    }

    public Filial Instanciar(FilialInserirComando comando)
    {
        Cidade cidade = cidadesServico.Validar(comando.IdCidade);
        return new Filial(comando.Descricao, comando.Sigla, cidade);
    }

    public Filial Validar(int codigo)
    {
        Filial filial = filiaisRepositorio.Recuperar(codigo);
        if (filial is null)
        {
            throw new RegraDeNegocioExcecao("Filial não encontrada");
        }
        return filial;
    }
}
