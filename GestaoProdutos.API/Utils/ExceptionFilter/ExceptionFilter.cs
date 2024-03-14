using Autoglass.Autoplay.Dominio.Utils.Excecoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestaoProdutos.API.Utils.ExceptionFilter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception.InnerException ?? context.Exception;
            if (ex
                is RegraDeNegocioExcecao)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(new
                {
                    Message = ex.Message,
                    Tipo = ex.GetType().Name
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(new
                {
                    Message = "Ocorreu um erro interno no servidor."
                }
                );
                logger.LogError(ex, ex.Message);
            }
        }
    }
}