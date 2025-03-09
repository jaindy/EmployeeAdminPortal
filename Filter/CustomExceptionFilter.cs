using System.Net;
using EmployeeAdminPortal.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeAdminPortal.Filter
{
    [AttributeUsage(AttributeTargets.Method)] 
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            var errorstring = new ErrorResponseData()
            {
                StatusCode=(int)HttpStatusCode.InternalServerError,
                Message=context.Exception.Message,
                Path=context.Exception.StackTrace

            }.ToString();   
            context.Result=new JsonResult(errorstring); 

        }
    }
}
