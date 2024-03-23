using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Infra.Produtos.Mapeamentos;

public class ProdutoMap : ClassMap<Produto>
{
    public ProdutoMap()
    {
        
    Schema("gestaoproduto");
    Table("produto");
    Id(x => x.Codigo, "codigo");
    Map(x => x.Descricao, "descricao");
    Map(x => x.Situacao, "ativo").CustomType<AtivoInativoEnum>();
    References(x => x.Fornecedor, "codigoFornecedor");     
    }
}
