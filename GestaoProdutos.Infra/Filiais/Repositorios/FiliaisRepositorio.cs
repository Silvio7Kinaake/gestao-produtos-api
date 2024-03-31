using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Filiais.Entidades;
using GestaoProdutos.Dominio.Filiais.Repositorios;
using GestaoProdutos.Dominio.Filiais.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Filiais.Repositorios;

public class FiliaisRepositorio : RepositorioNHibernate<Filial>, IFiliaisRepositorio
{
    public FiliaisRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Filial> Filtrar(FilialListarFiltro filtro)
    {
        IQueryable<Filial> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.Descricao))
        {
            query = query.Where(x => x.Descricao == filtro.Descricao);
        }

        if (!string.IsNullOrWhiteSpace(filtro.Sigla))
        {
            query = query.Where(x => x.Sigla == filtro.Sigla);
        }

        if (filtro.IdCidade != 0)
        {
            query = query.Where(x => x.Cidade.Id == filtro.IdCidade);
        }

        return query;
    }

    public void Inativar(Filial filial)
    {
        filial.SetSituacao(AtivoInativoEnum.Inativo);
        Editar(filial);
    }
}
