
using Hoviedo.Api.Blog.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Swashbuckle.Swagger;

namespace Hoviedo.Api.Blog
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
            services.AddSwaggerGen();
           
            DbContext.InitialLoad();
            /*
            _ = services.AddSwaggerGen(options =>
              {
                  options.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Version = "v1",
                      Title = "ToDo API",
                      Description = "An ASP.NET Core Web API for managing ToDo items",
                      TermsOfService = new Uri("https://example.com/terms"),
                      Contact = new OpenApiContact
                      {
                          Name = "Example Contact",
                          Url = new Uri("https://example.com/contact")
                      },
                      License = new OpenApiLicense
                      {
                          Name = "Example License",
                          Url = new Uri("https://example.com/license")
                      }
                  });
                  /*
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
              });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            /*
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });
            */
            app.UseSwaggerUI();
            /*
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            */


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}