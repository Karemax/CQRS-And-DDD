using Application.DTOs;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    // Query to get all products
    // استعلام لإحضار جميع المنتجات
    public class GetProductsQuery : IRequest<List<ProductDto>> { }
}
