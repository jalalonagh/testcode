using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ManaEntitiesValidation
{
    public static class ManaEntitiesValidationExtensions
    {
        public static void AddEntitiesValidationService(this IServiceCollection services, IConfiguration configuration)
        {
            // افزودن سرویس کار با پرداخت زرین پال
            services.AddMvc(setup => {}).AddFluentValidation();
        }
    }
}
