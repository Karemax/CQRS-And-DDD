using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using System.Reflection;

namespace WebAPI.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // ---------------------------------------------------
            // Register MediatR
            // تسجيل MediatR عشان يقدر يربط الـ Commands و Queries بالـ Handlers
            // ---------------------------------------------------
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // ---------------------------------------------------
            // Register Product Service
            // تسجيل خدمة المنتج
            // ---------------------------------------------------
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // ---------------------------------------------------
            // Register Repository
            // تسجيل الـ Repository
            // ---------------------------------------------------
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
