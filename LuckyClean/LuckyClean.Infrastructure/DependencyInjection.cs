using LuckyClean.Domain.Interfaces;
using LuckyClean.Infrastructure.Persistence.Repositories;
using LuckyClean.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LuckyClean.Application.Interfaces;
using LuckyClean.Infrastructure.Services;
using LuckyClean.Infrastructure.Configuration;

namespace LuckyClean.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(config.GetConnectionString("Default")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            if (config.GetValue<bool>("UseMockPayment"))
            {
                services.AddScoped<IPaymentService, MockPaymentService>();
            }
            else
            {
                services.AddHttpClient<IPaymentService, PaymentService>();
            }
            services.AddScoped<IEmailService, EmailService>();
            services.Configure<PaymentSettings>(config.GetSection("PaymentSettings"));

            return services;
        }
    }
}
