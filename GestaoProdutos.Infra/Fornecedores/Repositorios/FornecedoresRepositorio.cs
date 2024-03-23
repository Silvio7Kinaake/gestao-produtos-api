using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using NHibernate;

namespace GestaoProdutos.Infra.Fornecedores.Repositorios;

public class FornecedoresRepositorio : RepositorioNHibernate<Fornecedor>, IFornecedoresRepositorio
{
    public FornecedoresRepositorio(ISession session) : base(session)
    {
    }

    public IQueryable<Fornecedor> Filtrar(FornecedorListarFiltro filtro)
    {
        IQueryable<Fornecedor> query = Query().Where(x => x.Situacao == AtivoInativoEnum.Ativo); ;


        if (!string.IsNullOrWhiteSpace(filtro.Descricao))
        {
            query = query.Where(x => x.Descricao == filtro.Descricao);
        }

        if (!string.IsNullOrWhiteSpace(filtro.Cnpj))
        {
            query = query.Where(x => x.Cnpj == filtro.Cnpj);
        }

        return query;
    }

    public void Inativar(Fornecedor fornecedor)
    {
        fornecedor.SetSituacao(AtivoInativoEnum.Inativo);
        Editar(fornecedor);
    }
}
