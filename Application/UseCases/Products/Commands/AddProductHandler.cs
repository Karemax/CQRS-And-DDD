using Application.Services;
using Application.UseCases.Products.Commands;
using MediatR;

namespace Application.UseCases.Products.Handlers
{
    // Handler for AddProductCommand
    // المعالج الخاص بأمر إضافة المنتج
    public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductService _service;

        // Inject Product Service
        // حقن خدمة المنتج
        public AddProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // Use service to add product
            // استخدام الخدمة لإضافة المنتج
            return await _service.AddProductAsync(request.Name, request.Price);
        }
    }
}
