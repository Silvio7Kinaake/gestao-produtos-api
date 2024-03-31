using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Filiais.Entidades;

namespace GestaoProdutos.Infra.Filiais.Mapeamentos;

public class FilialMap : ClassMap<Filial>
{
    public FilialMap()
    {
        Schema("gestaoproduto");
        Table("filial");
        Id(x => x.Codigo, "codigo");
        Map(x => x.Descricao, "descricao");
        Map(x => x.Sigla, "sigla");
        Map(x => x.Situacao, "situacao").CustomType<AtivoInativoEnum>();
        References(x => x.Cidade, "idCidade");
    }
}
