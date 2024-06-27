namespace GestaoProdutos.DataTransfer.Usuarios.Requests;

public record UsuarioInserirRequest (int Id, string Nome, string Email, string Senha);
