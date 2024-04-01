using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Lotes.Entidades;

namespace GestaoProdutos.Infra.Lotes.Mapeamentos;

public class LoteMap : ClassMap<Lote>
{
    public LoteMap()
    {
        Schema("gestaoproduto");
        Table("lote");
        Id(x => x.Id, "id");
        Map(x => x.Quantidade, "quantidade");
        Map(x => x.DataFabricacao, "datafabricacao");
        Map(x => x.DataValidade, "datavalidade");
        References(x => x.Produto, "codigoProduto");
        References(x => x.Enderecamento, "idEnderecamento");
    }
}
