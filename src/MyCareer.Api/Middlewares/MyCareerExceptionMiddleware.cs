using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyCareer.Service.Exceptions;
using System;
using System.Threading.Tasks;

namespace MyCareer.Api.Middlewares
{
    public class MyCareerExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MyCareerExceptionMiddleware> logger;
        public MyCareerExceptionMiddleware(RequestDelegate next, ILogger<MyCareerExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next.Invoke(context);
            }
            catch (MyCareerException ex)
            {
                await HandleException(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                //Log
                logger.LogError(ex.ToString());

                await HandleException(context, 500, ex.Message);
            }
        }

        public async Task HandleException(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
