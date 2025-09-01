namespace Domain.ValueObjects
{
    // Value Object representing Money
    // كائن قيمة يمثل المال
    public class Money
    {
        public decimal Amount { get; private set; }   // القيمة المالية
        public string Currency { get; private set; }  // العملة (مثلاً USD, EGP)

        // Constructor
        // الكونستركتور
        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative / لا يمكن أن تكون القيمة سالبة");

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required / العملة مطلوبة");

            Amount = amount;
            Currency = currency.ToUpper();
        }

        // Equality check (Value-based not reference)
        // مقارنة على أساس القيمة وليس المرجع
        public override bool Equals(object obj)
        {
            if (obj is not Money other)
                return false;

            return Amount == other.Amount && Currency == other.Currency;
        }

        // ToString override
        // تحويل لكلمة نصية
        public override string ToString() => $"{Amount} {Currency}";
    }
}
