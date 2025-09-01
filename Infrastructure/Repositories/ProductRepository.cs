using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    // Repository Implementation for Product Entity
    // تنفيذ الـ Repository الخاص بالمنتج
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        // Inject DbContext in Constructor
        // حقن DbContext في الكونستركتور
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        // Add a new Product to Database
        // إضافة منتج جديد إلى قاعدة البيانات
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product); // Add to DbSet
            await _context.SaveChangesAsync();         // Save changes to DB
        }

        // Get all Products from Database
        // جلب جميع المنتجات من قاعدة البيانات
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
            // Translate to SQL and fetch data
            // يقوم بتحويل الاستعلام إلى SQL ويجلب البيانات
        }
    }
}
