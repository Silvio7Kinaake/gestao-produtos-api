using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Usuarios.Entidades;

namespace GestaoProdutos.Infra.Usuarios.Mapeamentos;

public class UsuariosMap : ClassMap<Usuario>
{
    [Obsolete]
    public UsuariosMap()
    {
        Schema("gestaoproduto");
        Table("usuario");
        Id(x => x.Id, "id");
        Map(x => x.Nome, "nome");
        Map(x => x.Email, "email");
        Map(x => x.Senha, "senha");
        Map(x => x.Situacao, "situacao").CustomType<NHibernate.Type.EnumStringType<AtivoInativoEnum>>();
    }
}
