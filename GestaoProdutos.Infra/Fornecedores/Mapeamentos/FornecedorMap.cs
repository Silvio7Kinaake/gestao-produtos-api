using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.Infra.Fornecedores.Mapeamentos;

public class FornecedorMap : ClassMap<Fornecedor>
{
    public FornecedorMap()
    {
        Schema("gestaoproduto");
        Table("fornecedor");
        Id(x => x.Codigo, "codigo");
        Map(x => x.Descricao, "descricao");
        Map(x => x.Cnpj, "cnpj");
    }
}
