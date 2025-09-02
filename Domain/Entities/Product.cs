using Domain.ValueObjects;

namespace Domain.Entities
{
    // Product Entity (Represents a product in the store)
    // الكيان الخاص بالمنتج (يمثل المنتج داخل المتجر)
    public class Product
    {
        // Unique Identifier for Product
        // معرف فريد للمنتج
        public Guid Id { get; private set; }

        // Product Name
        // اسم المنتج
        public string Name { get; private set; }

        // Product Price (using Value Object for better money handling)
        // سعر المنتج ( باستخدام كائن قيمة للتعامل الأفضل مع المال )
        public Money Price { get; private set; }


        // EF Core needs this
        private Product() { }

        // Constructor to ensure product always created with values
        // الكونستركتور لضمان أن المنتج دائمًا يتم إنشاؤه ببيانات صحيحة
        public Product(string name, Money price)
        {
            Id = Guid.NewGuid();  // Generate new unique Id / إنشاء معرف فريد جديد
            Name = name;
            Price = price;
        }
    }
}
