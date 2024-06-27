using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Usuarios.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Usuarios.Requests;
using GestaoProdutos.DataTransfer.Usuarios.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Usuarios;

[ApiController]
[Route("api/usuarios")]

public class UsuariosController : ControllerBase
{
    private readonly IUsuariosAppServico usuariosAppServico;

    public UsuariosController(IUsuariosAppServico usuariosAppServico)
    {
        this.usuariosAppServico = usuariosAppServico;
    }
    /// <summary>
    /// Criar usuario
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<UsuarioResponse> Inserir([FromBody] UsuarioInserirRequest request)
    {
        var response = usuariosAppServico.Inserir(request);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um usuario por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<UsuarioResponse> Recuperar(int id)
    {
        var response = usuariosAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Edita um usuario por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<UsuarioResponse> Editar(int id, [FromBody] UsuarioEditarRequest request)
    {
        var response = usuariosAppServico.Editar(id, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar Usuarios
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<UsuarioResponse>> Listar([FromQuery] UsuarioListarRequest request)
    {
        var response = usuariosAppServico.Listar(request);
        return Ok(response);
    }


    /// <summary>
    ///Inativar um usuario por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Inativar(int id)
    {
        usuariosAppServico.Inativar(id);
        return Ok();
    }
}
