using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Enderecamentos.Entidades;

namespace GestaoProdutos.Infra.Enderecamentos.Mapeamentos;

public class EnderecamentoMap : ClassMap<Enderecamento>
{
    public EnderecamentoMap()
    {
        Schema("gestaoproduto");
        Table("enderecamento");
        Id(x => x.Id, "id");
        Map(x => x.Rua, "rua");
        Map(x => x.Posicao, "posicao");
        Map(x => x.Altura, "altura");
        Map(x => x.Profundidade, "profundidade");
        Map(x => x.Situacao, "situacao").CustomType<AtivoInativoEnum>();
        References(x => x.Filial, "codigoFilial");
    }
}
