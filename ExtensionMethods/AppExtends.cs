using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace WebAppMVC_1.ExtensionMethods
{
    public static class AppExtends
    {
        public static void AddErrorCodePage (this IApplicationBuilder app)
        {
            app.UseStatusCodePages(applicationBuilder =>
            {
                applicationBuilder.Run(async context =>
                {
                    var code = context.Response.StatusCode;
                    var content = $@"<html>
                    <head>
                        <meta charset='UTF-8' />
                        <title>Lỗi {code}</title>
                    </head>
                    <body>
                        <p style ='color: red; font-size: 70px'>Phát hiện lỗi {code} - {(HttpStatusCode)code}</p>
                    </body>
                    </html>";

                   await  context.Response.WriteAsync(content);
                });
            });
        }
    }
}
