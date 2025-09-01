using Domain.Entities;

namespace Domain.Interfaces
{
    // Contract for Product Repository
    // واجهة لمخزن المنتجات (تحدد التعاقد)
    public interface IProductRepository
    {
        // Add a new Product
        // إضافة منتج جديد
        Task AddAsync(Product product);

        // Get all Products
        // جلب كل المنتجات
        Task<List<Product>> GetAllAsync();
    }
}
