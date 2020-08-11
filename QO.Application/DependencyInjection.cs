using Microsoft.Extensions.DependencyInjection;
using QO.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QO.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<QualifyingOfferService>();

            return services;
        }
    }
}
