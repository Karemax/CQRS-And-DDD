using Infrastructure.EFCore;
using Infrastructure.Repositories;
using Domain.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using WebAPI.Configurations;
using Domain.Entities;
using Domain.ValueObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ---------------------------------------------------
        // Register DbContext
        // تسجيل الـ DbContext
        // ---------------------------------------------------
        builder.Services.AddDbContext<StoreDbContext>(options =>
                options.UseInMemoryDatabase("AppDb"));

        // ---------------------------------------------------
        // Register Controllers
        // تسجيل الكنترولرز
        // ---------------------------------------------------
        builder.Services.AddControllers();

        // ---------------------------------------------------
        // Custom configurations
        // تكوينات مخصصة
        // ---------------------------------------------------
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructure();

        // ---------------------------------------------------
        // Build the app
        // بناء التطبيق
        // ---------------------------------------------------
        var app = builder.Build();

        // Seed sample data
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product("Laptop", new Money(200,"USD")),
                    new Product("Headphones", new Money(150, "USD"))
                );
                context.SaveChanges();
            }
        }

        // ---------------------------------------------------
        // Configure the HTTP request pipeline
        // تكوين خط أنابيب طلب HTTP
        // ---------------------------------------------------
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS + DDD API v1");
                c.RoutePrefix = string.Empty; // Swagger UI at root (localhost:5000)
            });
        }

        // ---------------------------------------------------
        // Map Controllers
        // ربط الـ Endpoints الخاصة بالكنترولرز
        // ---------------------------------------------------
        app.MapControllers();

        // Run the app
        // تشغيل التطبيق
        app.Run();
    }
}