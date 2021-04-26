using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculate.Api.BusinessLogic;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Calculate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ServiceRegistry services)
        {
            //services
            //    .AddJson()
            //    .AddXml()
            //    .AddHttpClient()
            //    .AddStatusEndpoint()
            //    .AddMemoryCache()
            //    .AddMySwaggerGen();

            ServiceExtentions.AddMyServices(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            #region Swagger

            //if (env.IsDevelopment() || env.IsStaging() || env.EnvironmentName.ToLower() == "sofia")
            //{
            //    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
            //    app.UseSwaggerUI(c =>
            //    {
            //        c.SwaggerEndpoint("/swagger/Deskline.Scheduler.API/swagger.json", "Calculate.API");
            //        //c.OAuthClientId("Deskline.Scheduler.API.Swagger");
            //        //c.OAuthClientSecret("DesklineSchedulerApiSecret");
            //    }); // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //}

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
