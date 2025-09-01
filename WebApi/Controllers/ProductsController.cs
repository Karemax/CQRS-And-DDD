using Application.UseCases.Products.Commands;
using Application.UseCases.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Inject Mediator (CQRS Core Component)
        // حقن الـ Mediator (المكون الأساسي لـ CQRS)
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/products
        // إضافة منتج جديد
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommand command)
        {
            // Send command to Mediator
            // إرسال الأمر إلى الـ Mediator
            var productId = await _mediator.Send(command);

            // Return Id of created product
            // إرجاع معرف المنتج الذي تم إنشاؤه
            return Ok(productId);
        }

        // GET: api/products
        // جلب كل المنتجات
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // Send query to Mediator
            // إرسال الاستعلام إلى الـ Mediator
            var products = await _mediator.Send(new GetProductsQuery());

            // Return list of products
            // إرجاع قائمة المنتجات
            return Ok(products);
        }
    }
}
