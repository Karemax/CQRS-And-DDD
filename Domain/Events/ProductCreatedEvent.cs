namespace Domain.Events
{

/*
    ===============================================================
     📝 Event Sourcing (soon)
    ===============================================================

    Event Sourcing is a way to store the state of an application 
    by saving all the events (changes) that happened, 
    instead of just saving the final state.

    - Normally: You save the current state 
      (e.g., Product = "Laptop", Price = 1000).
    - With Event Sourcing: You save every event 
      (Created, PriceChanged, NameUpdated, etc.), 
      and you can rebuild the state anytime by replaying these events.

    ✅ Benefits:
      - Full history (audit log).
      - Easy to debug and time-travel (go back to any point in time).
      - Works great with CQRS and external integrations.


    هو طريقة لتخزين حالة السيستم 
    عن طريق حفظ الأحداث اللي حصلت، مش بس الحالة النهائية.

    - الطبيعي: بتخزن الحالة النهائية 
      (مثلاً المنتج = "لاب توب"، السعر = 1000).
    - مع Event Sourcing: بتسجل كل الأحداث 
      (اتعمل Create، اتغير السعر، اتغير الاسم...)
      وتقدر تعيد بناء الحالة في أي وقت 
      عن طريق إعادة تشغيل الأحداث.

    ✅ المميزات:
      - سجل كامل للتغييرات (Audit Log).
      - سهل في الـ Debug والـ Time-travel (ترجع لأي لحظة).
      - مناسب جدًا مع CQRS والـ Integrations الخارجية.
*/

    // Event raised when a new product is created
    // الحدث الذي يحدث عند إنشاء منتج جديد
    public class ProductCreatedEvent
    {
        public Guid ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }

        public ProductCreatedEvent(Guid productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }
}
