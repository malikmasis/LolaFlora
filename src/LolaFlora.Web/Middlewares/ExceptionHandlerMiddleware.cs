using LolaFlora.Common.Exception;
using LolaFlora.Common.Result;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LolaFlora.Web.Middlewares
{
    public static class ExceptionHandlerMiddleware
    {
        private const string FatalError = "Fatal Error";
        private const string ApplicationJson = "application/json";

        private static readonly JsonSerializerOptions JsonSerializerOptionsForExeption = new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static readonly int InternalServerError = (int)HttpStatusCode.InternalServerError;

        public static void UseJsonExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            ILogger logger = loggerFactory.CreateLogger("ExceptionHandlerMiddleware");
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = InternalServerError;
                    context.Response.ContentType = ApplicationJson;
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With, Content-Type, Accept, Origin, Authorization");
                    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, CONNECT, HEAD, PATCH");

                    var syncIOFeature = context.Features.Get<IHttpBodyControlFeature>();
                    if (syncIOFeature != null)
                    {
                        syncIOFeature.AllowSynchronousIO = true;
                    }

                    string response = FatalError;
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var resultObject = new ExceptionDetail(error.Error);
                        PathString p = context.Request.Path;
                        var path = p.HasValue ? p.Value : string.Empty;
                        var result = new DataApiResult<ExceptionDetail>(resultObject, path, resultObject.Message, false, InternalServerError);
                        response = JsonSerializer.Serialize(result, JsonSerializerOptionsForExeption);
                    }
                    logger.LogError(response);
                    using (StreamWriter writer = new StreamWriter(context.Response.Body, UTF8Encoding.UTF8))
                    {
                        char[] buffer = response.ToCharArray();
                        await writer.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}
