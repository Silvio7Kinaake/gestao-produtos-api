using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Usuarios.Requests;

public class UsuarioListarRequest : PaginacaoFiltro
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public UsuarioListarRequest() : base(cpOrd: "Id", TipoOrdenacaoEnum.Asc) { }
}
