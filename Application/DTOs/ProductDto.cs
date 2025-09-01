namespace Application.DTOs
{
    // Data Transfer Object for Product
    // كائن لنقل البيانات الخاصة بالمنتج
    public class ProductDto
    {
        // Unique Identifier
        // المعرف الفريد
        public Guid Id { get; set; }

        // Product Name
        // اسم المنتج
        public string Name { get; set; }

        // Product Price
        // سعر المنتج
        public string Price { get; set; }
    }
}
