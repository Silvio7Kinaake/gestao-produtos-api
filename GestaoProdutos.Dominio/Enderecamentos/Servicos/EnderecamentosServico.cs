using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Comandos;
using GestaoProdutos.Dominio.Enderecamentos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Enderecamentos.Servicos;

public class EnderecamentosServico : IEnderecamentosServico
{
    private readonly IEnderecamentosRepositorio enderecamentosRepositorio;
    private readonly IFiliaisServico filiaisServico;

    public EnderecamentosServico(IEnderecamentosRepositorio enderecamentosRepositorio, IFiliaisServico filiaisServico)
    {
        this.enderecamentosRepositorio = enderecamentosRepositorio;
        this.filiaisServico = filiaisServico;
    }

    public Enderecamento Editar(EnderecamentoEditarComando comando)
    {
        Enderecamento enderecamento = Validar(comando.Id);
        Filial filial = filiaisServico.Validar(comando.CodigoFilial);
        enderecamento.SetRua(comando.Rua);
        enderecamento.SetPosicao(comando.Posicao);
        enderecamento.SetAltura(comando.Altura);
        enderecamento.SetProfundidade(comando.Profundidade);
        enderecamento.SetFilial(filial);
        enderecamentosRepositorio.Editar(enderecamento);
        return enderecamento;
    }

    public Enderecamento Inserir(EnderecamentoInserirComando comando)
    {
        Enderecamento enderecamento = Instanciar(comando);
        enderecamentosRepositorio.Inserir(enderecamento);
        return enderecamento;
    }

    public Enderecamento Instanciar(EnderecamentoInserirComando comando)
    {
        Filial filial = filiaisServico.Validar(comando.CodigoFilial);
        return new Enderecamento(comando.Rua, comando.Posicao, comando.Altura, comando.Profundidade, filial);
    }

    public Enderecamento Validar(int id)
    {
        Enderecamento enderecamento = enderecamentosRepositorio.Recuperar(id);
        if (enderecamento is null)
        {
            throw new RegraDeNegocioExcecao("Endereco não encontrado");
        }
        return enderecamento;
    }
}
