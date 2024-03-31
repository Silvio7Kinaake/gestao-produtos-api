using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Estados.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Estados.Requests;
using GestaoProdutos.DataTransfer.Estados.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Estados;

[ApiController]
[Route("api/estados")]
public class EstadosController : ControllerBase
{
    private readonly IEstadosAppServico estadosAppServico;

    public EstadosController(IEstadosAppServico estadosAppServico)
    {
        this.estadosAppServico = estadosAppServico;
    }

    /// <summary>
    /// Criar estado
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<EstadoResponse> Inserir([FromBody] EstadoInserirRequest request)
    {
        var response = estadosAppServico.Inserir(request);
        return Ok(response);
    }


    /// <summary>
    /// Recupera um estado por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpGet("{codigo}")]
    public ActionResult<EstadoResponse> Recuperar(int codigo)
    {
        var response = estadosAppServico.Recuperar(codigo);
        return Ok(response);
    }


    /// <summary>
    /// Edita um estado por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{codigo}")]
    public ActionResult<EstadoResponse> Editar(int codigo, [FromBody] EstadoEditarRequest request)
    {
        var response = estadosAppServico.Editar(codigo, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar estado
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<EstadoResponse>> Listar([FromQuery] EstadoListarRequest request)
    {
        var response = estadosAppServico.Listar(request);
        return Ok(response);
    }
}
