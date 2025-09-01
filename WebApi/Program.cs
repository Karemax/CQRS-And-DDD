using Infrastructure.EFCore;
using Infrastructure.Repositories;
using Domain.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using WebAPI.Configurations;

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
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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