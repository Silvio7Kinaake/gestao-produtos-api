using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Lotes.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Lotes.Request;
using GestaoProdutos.DataTransfer.Lotes.Response;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Lotes;

[ApiController]
[Route("api/lotes")]
public class LotesController : ControllerBase
{
    private readonly ILotesAppServico lotesAppServico;

    public LotesController(ILotesAppServico lotesAppServico)
    {
        this.lotesAppServico = lotesAppServico;
    }

    /// <summary>
    /// Criar lote
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<LoteResponse> Inserir([FromBody] LoteInserirRequest request)
    {
        var response = lotesAppServico.Inserir(request);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um lote por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<LoteResponse> Recuperar(int id)
    {
        var response = lotesAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Edita um lote por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<LoteResponse> Editar(int id, [FromBody] LoteEditarRequest request)
    {
        var response = lotesAppServico.Editar(id, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar Lotes
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<LoteResponse>> Listar([FromQuery] LoteListarRequest request)
    {
        var response = lotesAppServico.Listar(request);
        return Ok(response);
    }
}
