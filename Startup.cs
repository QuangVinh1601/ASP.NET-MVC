using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAppMVC_1.ExtensionMethods;
using WebAppMVC_1.Services;

namespace WebAppMVC_1
{
    public class Startup
    {
        public static string ContentRootPath { get; private set; } 
        public Startup(IConfiguration configuration ,IWebHostEnvironment path)
        {
            Configuration = configuration;
            ContentRootPath = path.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                //{0} -> Action
                //{1} -> Controller
                //{2} -> Area

                // /Views/Ten Controller/Action.cshtml -> Mac dinh
                // /MyView/Ten Controller/Action.cshtml -> Customize
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });
            services.AddSingleton<ProductService>();
            services.AddSingleton<PlanetService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //MiddleWare được sử dụng khi truy cập 1 trang web có lỗi từ 400-599
            app.AddErrorCodePage();

            app.UseRouting(); //EndpointRoutingMiddleWare
            app.UseAuthentication(); //xac dinh danh tinh

            app.UseAuthorization(); //xac thuc quyen truy cap

            app.UseEndpoints(endpoints =>
            {
                // /QuangVinhDepTrai
                endpoints.MapGet("/QuangVinhDepTrai", async context =>
                {
                    await context.Response.WriteAsync($"Quang Vinh đẹp trai ác {DateTime.Now}");
                });
                endpoints.MapRazorPages();

                //endpoint.MapController
                //endpoint.MapControllerRoute
                //endpoints.MapDefaultControllerRoute
                //endpoints.MapAreaControllerRoute

                // [AcceptVerb] -> Action
                // [Route]
                // [HttpGet]
                // [HtppPut]
                // [HttpPost]

                endpoints.MapControllerRoute(
                    name: "First",
                    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct",
                    }
                );
                // Chỉ thực hiện trên Controller có Area
                endpoints.MapAreaControllerRoute(
                    name: "product",
                    pattern: "/{controller}/{action=Index}/{id?}",
                    areaName: "ProductList"
                    );

                // Chỉ thực hiện trên Controller khong co Area
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
