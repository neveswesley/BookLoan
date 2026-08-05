using System.ComponentModel.DataAnnotations;
using System.Net;
using BookLoan.API.ExceptionsBase;
using BookLoan.API.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookLoan.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case BookLoanException ex:
                HandleProjectException(context, ex);
                break;
            
            default:
                HandleUnknownException(context);
                break;
        }
    }

    private void HandleProjectException(ExceptionContext context, BookLoanException ex)
    {
        context.HttpContext.Response.StatusCode = ex switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            //ValidationException => StatusCodes.Status400BadRequest,
            //UnauthorizedException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(new ResponseError(ex.GetErrors()))
        {
            StatusCode = context.HttpContext.Response.StatusCode
        };

        context.ExceptionHandled = true;
    }
    
    private void HandleUnknownException(ExceptionContext context)
    {
        var exception = context.Exception;

        context.HttpContext.Response.StatusCode =
            (int)HttpStatusCode.InternalServerError;

        context.Result = new ObjectResult(new
        {
            message = exception.Message,
            exception = exception.GetType().Name,
            stackTrace = exception.StackTrace
        });

        context.ExceptionHandled = true;
    }
}