using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Filiais.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Filiais.Requests;
using GestaoProdutos.DataTransfer.Filiais.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Filiais;

[ApiController]
[Route("api/filiais")]
public class FiliaisController : ControllerBase
{
    private readonly IFiliaisAppServico filiaisAppServico;

    public FiliaisController(IFiliaisAppServico filiaisAppServico)
    {
        this.filiaisAppServico = filiaisAppServico;
    }

    /// <summary>
    /// Criar Filial
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<FilialResponse> Inserir([FromBody] FilialInserirRequest request)
    {
        var response = filiaisAppServico.Inserir(request);
        return Ok(response);
    }

    /// <summary>
    /// Recupera uma filial por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpGet("{codigo}")]
    public ActionResult<FilialResponse> Recuperar(int codigo)
    {
        var response = filiaisAppServico.Recuperar(codigo);
        return Ok(response);
    }

    /// <summary>
    /// Edita uma filial por codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{codigo}")]
    public ActionResult<FilialResponse> Editar(int codigo, [FromBody] FilialEditarRequest request)
    {
        var response = filiaisAppServico.Editar(codigo, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar filiais
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<FilialResponse>> Listar([FromQuery] FilialListarRequest request)
    {
        var response = filiaisAppServico.Listar(request);
        return Ok(response);
    }


    /// <summary>
    ///Inativar uma filial por codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpDelete("{codigo}")]
    public ActionResult Inativar(int codigo)
    {
        filiaisAppServico.Inativar(codigo);
        return Ok();
    }
}
