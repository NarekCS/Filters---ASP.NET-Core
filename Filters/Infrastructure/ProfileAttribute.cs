﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class ProfileAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    timer = Stopwatch.StartNew();
        //}
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    timer.Stop();
        //    string result = "<div>Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
        //    byte[] bytes = Encoding.ASCII.GetBytes(result);
        //    context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        //}

        //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    Stopwatch timer = Stopwatch.StartNew();
        //    await next();
        //    timer.Stop();
        //    string result = "<div>Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
        //    byte[] bytes = Encoding.ASCII.GetBytes(result);
        //    await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        //}
        private double actionTime;
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            actionTime = timer.Elapsed.TotalMilliseconds;
        }
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            string result = "<div>Action time: " + $"{actionTime} ms</div><div>Total time: " + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);           
        }
    }
}
