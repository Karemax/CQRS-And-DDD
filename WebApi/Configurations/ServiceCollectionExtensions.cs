using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.OpenApi.Models;
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
            cfg.RegisterServicesFromAssembly(typeof(Application.UseCases.Products.Commands.AddProductCommand).Assembly)
            .RegisterServicesFromAssembly(typeof(Application.UseCases.Products.Queries.GetProductsQuery).Assembly)
            );

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

            // ---------------------------------------------------
            // Add Swagger service
            // تسجيل الـ Swagger
            // ---------------------------------------------------
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CQRS + DDD Sample API",
                    Version = "v1",
                    Description = "Demo project showcasing CQRS, MediatR, and DDD in .NET 8",
                    Contact = new OpenApiContact
                    {
                        Name = "Karem Elkilany",
                        Url = new Uri("https://linkedin.com/in/karemax3")
                    }
                });
            });

            return services;
        }
    }
}
