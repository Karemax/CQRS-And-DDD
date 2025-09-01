using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    // EF Core DbContext for the Store
    // DbContext الخاص بالمتجر باستخدام EF Core
    public class StoreDbContext : DbContext
    {
        // Constructor: inject DbContext options (connection string, provider, etc.)
        // الكونستركتور: بياخد خيارات DbContext (زي connection string والمزود)
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        // DbSet represents the "Products" table in the database
        // DbSet بيمثل جدول "Products" في قاعدة البيانات
        public DbSet<Product> Products { get; set; }

        // Optional: Override OnModelCreating for custom configurations
        // اختياري: إعادة تعريف OnModelCreating لإضافة إعدادات خاصة بالـ Entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configure Product entity
            // مثال: إعدادات خاصة بالمنتج
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id); // Primary Key / المفتاح الأساسي
                entity.Property(p => p.Name)
                      .IsRequired()       // Required Field / مطلوب
                      .HasMaxLength(200); // Max Length / أقصى طول
            });
        }
    }
}
