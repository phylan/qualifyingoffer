using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QO.Application;
using QO.Application.Config;
using QO.Application.Interfaces;
using QO.Infrastructure.Config;
using QO.Infrastructure.Services;

namespace QO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string SpecificOriginsPolicy = "_allowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();

            var qoRules = Configuration.GetSection("QualifyingOfferRules");
            services.Configure<QualifyingOfferConfig>(qoRules);

            var scraperConfig = Configuration.GetSection("Scraper");
            services.Configure<SalaryScraperConfig>(scraperConfig);
            services.AddHttpClient<ISalaryScraper, SalaryScraper>(client => { client.BaseAddress = new Uri(scraperConfig["Url"]); });

            services.AddOpenApiDocument(config => config.UseRouteNameAsOperationId = true);

            services.AddCors(options =>
            {
                options.AddPolicy(name: SpecificOriginsPolicy, builder => { 
                    builder.WithOrigins("http://localhost:8080",
                    "https://qualifyingoffer.onrender.com"); });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(SpecificOriginsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
