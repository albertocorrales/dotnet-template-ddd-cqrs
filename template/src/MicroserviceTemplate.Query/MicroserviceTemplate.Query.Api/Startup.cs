using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MicroserviceTemplate.Query.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string _documentationFile = "MicroserviceTemplate.Query.Api.xml";
        private const string _apiTitle = "Fenergo Nebula Template Query";
        private const string _applicationPathName = "templatequery";

        private readonly string _webServiceVersion;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _webServiceVersion = GetServiceVersion();
        }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_webServiceVersion, new Microsoft.OpenApi.Models.OpenApiInfo { Title = _apiTitle, Version = _webServiceVersion });

                var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _documentationFile);
                c.IncludeXmlComments(filePath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerEndpoint = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME")) ?
                $"/swagger/{_webServiceVersion}/swagger.json"
                : $"/{_applicationPathName}/swagger/{_webServiceVersion}/swagger.json";

                c.SwaggerEndpoint(swaggerEndpoint, $"Template Query Web API {_webServiceVersion}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static string GetServiceVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
