using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Fornecedores.Requests;
using GestaoProdutos.DataTransfer.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Fornecedores;

[ApiController]
[Route("api/fornecedores")]
public class FornecedoresController : ControllerBase
{
    private readonly IFornecedoresAppServico fornecedoresAppServico;

    public FornecedoresController(IFornecedoresAppServico fornecedoresAppServico)
    {
        this.fornecedoresAppServico = fornecedoresAppServico;
    }

    /// <summary>
    /// Criar fornecedor
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<FornecedorResponse> Inserir([FromBody] FornecedorInserirRequest request)
    {
        var response = fornecedoresAppServico.Inserir(request);
        return Ok(response);
    }


    /// <summary>
    /// Recupera um fornecedor por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpGet("{codigo}")]
    public ActionResult<FornecedorResponse> Recuperar(int codigo)
    {
        var response = fornecedoresAppServico.Recuperar(codigo);
        return Ok(response);
    }


    /// <summary>
    /// Edita um fornecedor por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{codigo}")]
    public ActionResult<FornecedorResponse> Editar(int codigo, [FromBody] FornecedorEditarRequest request)
    {
        var response = fornecedoresAppServico.Editar(codigo, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar Fornecedores
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<FornecedorResponse>> Listar([FromQuery] FornecedorListarRequest request)
    {
        var response = fornecedoresAppServico.Listar(request);
        return Ok(response);
    }


    /// <summary>
    ///Inativar um fornecedor por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpDelete("{codigo}")]
    public ActionResult Inativar(int codigo)
    {
        fornecedoresAppServico.Inativar(codigo);
        return Ok();
    }
}
