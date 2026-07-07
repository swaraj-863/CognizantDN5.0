using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment3_WebApiFilters.Filters;


public class CustomExceptionFilter

    : IExceptionFilter

{

    public void OnException(

        ExceptionContext context)

    {

        var message =

            context.Exception.Message;


        File.AppendAllText(

            "log.txt",

            message +

            Environment.NewLine);


        context.Result =

            new ObjectResult(

                "Internal Server Error")

            {

                StatusCode = 500

            };


        context.ExceptionHandled

            = true;

    }

}