using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Enderecamentos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Enderecamentos.Requests;
using GestaoProdutos.DataTransfer.Enderecamentos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Enderecamentos;

[ApiController]
[Route("api/enderecamentos")]
public class EnderecamentosController : ControllerBase
{
    private readonly IEnderecamentosAppServico enderecamentosAppServico;

    public EnderecamentosController(IEnderecamentosAppServico enderecamentosAppServico)
    {
        this.enderecamentosAppServico = enderecamentosAppServico;
    }
    
    /// <summary>
    /// Criar Enderecamento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<EnderecamentoResponse> Inserir([FromBody] EnderecamentoInserirRequest request)
    {
        var response = enderecamentosAppServico.Inserir(request);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um enderecamento por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<EnderecamentoResponse> Recuperar(int id)
    {
        var response = enderecamentosAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Edita um enderecamento por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<EnderecamentoResponse> Editar(int id, [FromBody] EnderecamentoEditarRequest request)
    {
        var response = enderecamentosAppServico.Editar(id, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar Enderecamentos
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<EnderecamentoResponse>> Listar([FromQuery] EnderecamentoListarRequest request)
    {
        var response = enderecamentosAppServico.Listar(request);
        return Ok(response);
    }


    /// <summary>
    ///Inativar um enderecamento por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Inativar(int id)
    {
        enderecamentosAppServico.Inativar(id);
        return Ok();
    }
}
