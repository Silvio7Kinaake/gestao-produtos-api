using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Estados.Entidades;

namespace GestaoProdutos.Infra.Estados.Mapeamentos;

public class EstadoMap : ClassMap<Estado>
{
    public EstadoMap()
    {
        Schema("gestaoproduto");
        Table("estado");
        Id(x => x.Codigo, "codigo");
        Map(x => x.Descricao, "descricao");
        Map(x => x.Sigla, "sigla");
    }
}
