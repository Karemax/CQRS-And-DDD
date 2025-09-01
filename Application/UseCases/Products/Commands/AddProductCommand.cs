using MediatR;

namespace Application.UseCases.Products.Commands
{
    // Command to Add a new Product
    // أمر لإضافة منتج جديد
    public class AddProductCommand : IRequest<Guid>
    {
        // Product Name / اسم المنتج
        public string Name { get; set; }

        // Product Price / سعر المنتج
        public decimal Price { get; set; }
    }
}
