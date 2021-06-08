using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ManaDataTransferObjectValidator
{
    public static class ManaDTOValidationExtensions
    {
        public static void AddDTOValidationService(this IServiceCollection services, IConfiguration configuration)
        {
            // افزودن سرویس کار با پرداخت زرین پال
            services.AddMvc(setup => {}).AddFluentValidation();
        }
    }
}
