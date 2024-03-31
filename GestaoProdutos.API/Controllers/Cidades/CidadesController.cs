using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Cidades.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Cidades.Requests;
using GestaoProdutos.DataTransfer.Cidades.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Cidades;


[ApiController]
[Route("api/cidades")]
public class CidadesController : ControllerBase
{
    private readonly ICidadesAppServico cidadesAppServico;

    public CidadesController(ICidadesAppServico cidadesAppServico)
    {
        this.cidadesAppServico = cidadesAppServico;
    }

    /// <summary>
    /// Criar cidade
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<CidadeResponse> Inserir([FromBody] CidadeInserirRequest request)
    {
        var response = cidadesAppServico.Inserir(request);
        return Ok(response);
    }

    /// <summary>
    /// Recupera uma cidade por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<CidadeResponse> Recuperar(int id)
    {
        var response = cidadesAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Edita uma cidade por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<CidadeResponse> Editar(int id, [FromBody] CidadeEditarRequest request)
    {
        var response = cidadesAppServico.Editar(id, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar cidades
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<CidadeResponse>> Listar([FromQuery] CidadeListarRequest request)
    {
        var response = cidadesAppServico.Listar(request);
        return Ok(response);
    }
}
