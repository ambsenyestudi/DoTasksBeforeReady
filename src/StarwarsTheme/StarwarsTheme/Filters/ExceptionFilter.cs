﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StarwarsTheme.Domain.Quizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StarwarsTheme.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var message = "Server error occurred.";

            var exceptionType = context.Exception.GetType();
            if (exceptionType.Name == nameof(QuizNotFoundException)) //Checking for my custom exception type
            {
                status = HttpStatusCode.BadRequest;
                message = context.Exception.Message;
            }

            //You can enable logging error

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new { Message = message });
        }
    }
}
