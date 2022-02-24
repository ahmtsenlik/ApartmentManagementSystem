using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace ApartmentManagement.Infrastructure.Middlewares
{
    public class CustumExceptionHandle
    {
        public RequestDelegate requestDelegate;
        public CustumExceptionHandle(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request]  HTTP " + context.Request.Method + " - " + context.Request.Path;
                Console.WriteLine(message);

                await requestDelegate(context);

                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded:" + context.Response.StatusCode + " in:" + watch.Elapsed.TotalMilliseconds + " ms";
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex,watch);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]    HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message +" in:" + watch.Elapsed.TotalMilliseconds + " ms";
            Console.WriteLine(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
}

