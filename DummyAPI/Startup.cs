using DummyAPI.Filters;
using DummyAPI.Infrastructure;
using DummyAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyAPI
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
            // Use in-memory database
            services.AddDbContext<DummyDbContext>(
                options => options.UseInMemoryDatabase("dummydb"));

            services.AddScoped<IRoomService, RoomService>();

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<JsonExceptionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerDocument(configure =>
            {
                configure.PostProcess = document =>
                {
                    document.Info.Title = "Dummy API";
                };
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddAutoMapper(options =>
            {
                options.AddProfile<MappingProfile>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowWebAppFrontend",
                    policy => policy.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseCors("AllowWebAppFrontend");

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
