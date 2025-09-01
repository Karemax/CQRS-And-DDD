using Application.DTOs;

namespace Application.Services
{
    // Service Interface for Product operations
    // واجهة الخدمة الخاصة بعمليات المنتج
    public interface IProductService
    {
        // Add a new product
        // إضافة منتج جديد
        Task<Guid> AddProductAsync(string name, decimal price);

        // Get all products
        // جلب جميع المنتجات
        Task<List<ProductDto>> GetProductsAsync();
    }
}
