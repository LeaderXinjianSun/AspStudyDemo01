using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspStudyDemo01.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace AspStudyDemo01
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options=>options.UseMySql(_configuration.GetConnectionString("StudentDBConnection"))
                );
            services.AddMvc(option => option.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            //依赖注入
            //services.AddSingleton<IStudentRepository,MockStudentRepository>();

            services.AddScoped<IStudentRepository, SQLStudentRepository>();//AddScoped保证不同请求过来的时候，产生的实例都是新的
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();
            app.UseStaticFiles();
            //pipeline with a default route named 'default' and the following template: '{controller=Home}/{action=Index}/{id?}'.
            app.UseMvc(rutes => {
                rutes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //app.Run(async context =>
            //{

            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
