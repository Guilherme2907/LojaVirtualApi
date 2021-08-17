using Guilherme.LojaVirtualApi.Middlewares;
using Guilherme.LojaVirtualApi.Models.Exceptions;
using Guilherme.LojaVirtualApi.Repository;
using Guilherme.LojaVirtualApi.Repository.Implementations;
using Guilherme.LojaVirtualApi.Repository.Interfaces;
using Guilherme.LojaVirtualApi.Services.ExceptionHandlingStrategies;
using Guilherme.LojaVirtualApi.Services.Implementations;
using Guilherme.LojaVirtualApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi
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
            services.AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ContractResolver =
                                                  new DefaultContractResolver();
                 });

            services.AddRepositoryServices(Configuration);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddSingleton(provider =>
            {
                var logger = provider.GetService<ILogger>();
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(NotFoundException), new NotFoundExceptionHandlingStrategy(logger) }
                };
            });

            services.AddSingleton<ILogger>(new LoggerConfiguration()
               .ReadFrom.Configuration(Configuration)
               .Enrich.WithMachineName()
               .CreateLogger());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

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
