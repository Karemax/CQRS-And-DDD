using Application.DTOs;
using Application.Services;
using Application.UseCases.Products.Queries;
using MediatR;

namespace Application.UseCases.Products.Handlers
{
    // Handler for GetProductsQuery
    // معالج استعلام جلب المنتجات
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductService _service;

        // Inject Product Service
        // حقن خدمة المنتج
        public GetProductsHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            // Use service to fetch products
            // استخدام الخدمة لجلب المنتجات
            return await _service.GetProductsAsync();
        }
    }
}
