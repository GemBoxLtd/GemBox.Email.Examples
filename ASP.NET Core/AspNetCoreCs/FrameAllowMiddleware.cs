using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GemBox.SaveMessage
{
    public class FrameAllowMiddleware
    {
        private readonly RequestDelegate next;

        public FrameAllowMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers["X-Frame-Options"] = "ALLOWALL";
            await this.next(context);
        }
    }
}
