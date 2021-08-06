using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Demo
{
    public class CustomerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMyType myType;

        public CustomerMiddleware(RequestDelegate next, IMyType myType)
        {
            this.next = next;
            this.myType = myType;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync($"Inside the new custom middleware");
            await next(httpContext);
            myType.Print();

        }
    }
}
