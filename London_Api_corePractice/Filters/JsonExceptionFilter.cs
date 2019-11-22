using London_Api_corePractice.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment environment;

        public JsonExceptionFilter(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        public void OnException(ExceptionContext context)
        {

            var error = new ApiError();
            if(environment.IsDevelopment())
            {

                error.Message = context.Exception.Message;
                error.Details = context.Exception.StackTrace;
            }
            else
            {

                error.Message = "A server Error Occour...";
                error.Details = context.Exception.Message;
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
