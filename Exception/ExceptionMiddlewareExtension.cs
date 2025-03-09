using System.Net;
using EmployeeAdminPortal.Response;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace EmployeeAdminPortal.Exception
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureBuildinExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(apperror =>
            {
                apperror.Run(async context =>

                {
                   var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                   var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    context.Response.ContentType = "application/json";

                    var errorstring = new ErrorResponseData()
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        Message = contextFeatures.Error.Message,
                        Path = contextRequest.Path

                    }.ToString();
                    await context.Response.WriteAsync(errorstring);
                });
            });
        }
    }
}
