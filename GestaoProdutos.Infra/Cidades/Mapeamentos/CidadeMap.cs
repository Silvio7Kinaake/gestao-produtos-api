using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Cidades.Entidades;

namespace GestaoProdutos.Infra.Cidades.Mapeamentos;

public class CidadeMap : ClassMap<Cidade>
{
    public CidadeMap()
    {
        Schema("gestaoproduto");
        Table("cidade");
        Id(x => x.Id, "id");
        Map(x => x.Descricao, "descricao");
        References(x => x.Estado, "codigoEstado");
    }
}
