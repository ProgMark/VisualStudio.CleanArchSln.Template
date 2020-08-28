using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using $ext_specifiedsolutionname$.Presentation.Rest.Api.IOC;
using $ext_specifiedsolutionname$.Presentation.Rest.Api.Health;
using $ext_specifiedsolutionname$.Presentation.Rest.Api.Settings;
using $ext_specifiedsolutionname$.Application.Registration;
using $ext_specifiedsolutionname$.Domain.Registration;
using $ext_specifiedsolutionname$.Infrastructure.Registration;
using $ext_specifiedsolutionname$.Persistance.Registration;
using System;

namespace $ext_specifiedsolutionname$.Presentation.Rest.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.RegisterServiceHealthChecks(Configuration);
            services.RegisterApplicationLayer(Configuration);
            services.RegisterDomainLayer(Configuration);
            services.RegisterInfrastructureLayer(Configuration);
            services.RegisterPersistanceLayer(Configuration);
            services.AddControllers()
                .AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                });
            return services.RegisterAutofacAsDiContainer(new ApiModule(Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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