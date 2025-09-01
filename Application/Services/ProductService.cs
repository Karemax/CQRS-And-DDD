using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services
{
    // Implementation of Product Service
    // تنفيذ خدمة المنتج
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        // Inject Product Repository
        // حقن مخزن المنتجات (Repository)
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        // Add new product
        // إضافة منتج جديد
        public async Task<Guid> AddProductAsync(string name, decimal price)
        {
            // الآن لازم ننشئ Money object
            // Now we create a Money object
            var money = new Money(price, "USD");

            // Create entity from parameters
            // إنشاء كيان منتج من البيانات المدخلة
            var product = new Product(name, money);

            // Save to repository
            // حفظ المنتج في الـ Repository
            await _repository.AddAsync(product);

            // Return product Id
            // إرجاع معرف المنتج
            return product.Id;
        }

        // Get all products
        // جلب جميع المنتجات
        public async Task<List<ProductDto>> GetProductsAsync()
        {
            // Fetch products from repository
            // جلب المنتجات من الـ Repository
            var products = await _repository.GetAllAsync();

            // Map entities to DTOs
            // تحويل الكيانات إلى DTOs
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price.ToString()
            }).ToList();
        }
    }
}
