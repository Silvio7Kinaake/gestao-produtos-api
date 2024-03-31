using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios;
using GestaoProdutos.Dominio.Enderecamentos.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Enderecamentos.Repositorios;

public class EnderecamentosRepositorio : RepositorioNHibernate<Enderecamento>, IEnderecamentosRepositorio
{
    public EnderecamentosRepositorio(ISession session) : base(session) { }

    public IQueryable<Enderecamento> Filtrar(EnderecamentoListarFiltro filtro)
    {
        IQueryable<Enderecamento> query = Query().Where(x => x.Situacao == AtivoInativoEnum.Ativo);


        if (filtro.Id > 0)
        {
            query = query.Where(x => x.Id == filtro.Id);
        }

        if (!string.IsNullOrWhiteSpace(filtro.Rua))
        {
            query = query.Where(x => x.Rua == filtro.Rua);
        }

        if (filtro.CodigoFilial != 0)
        {
            query = query.Where(x => x.Filial.Codigo == filtro.CodigoFilial);
        }

        return query;
    }

    public void Inativar(Enderecamento enderecamento)
    {
        enderecamento.SetSituacao(AtivoInativoEnum.Inativo);
        Editar(enderecamento);
    }
}
