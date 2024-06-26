using Autoglass.Autoplay.Dominio.Utils.Consultas;
using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Produtos;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutosAppServico produtosAppServico;

    public ProdutosController(IProdutosAppServico produtosAppServico)
    {
        this.produtosAppServico = produtosAppServico;
    }
    /// <summary>
    /// Criar produto
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<ProdutoResponse> Inserir([FromBody] ProdutoInserirRequest request)
    {
        var response = produtosAppServico.Inserir(request);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um produto por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpGet("{codigo}")]
    public ActionResult<ProdutoResponse> Recuperar(int codigo)
    {
        var response = produtosAppServico.Recuperar(codigo);
        return Ok(response);
    }

    /// <summary>
    /// Edita um produto por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{codigo}")]
    public ActionResult<ProdutoResponse> Editar(int codigo, [FromBody] ProdutoEditarRequest request)
    {
        var response = produtosAppServico.Editar(codigo, request);
        return Ok(response);
    }


    /// <summary>
    /// Listar Produtos
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<ProdutoResponse>> Listar([FromQuery] ProdutoListarRequest request)
    {
        var response = produtosAppServico.Listar(request);
        return Ok(response);
    }


    /// <summary>
    ///Inativar um produto por Codigo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpDelete("{codigo}")]
    public ActionResult Inativar(int codigo)
    {
        produtosAppServico.Inativar(codigo);
        return Ok();
    }
}
