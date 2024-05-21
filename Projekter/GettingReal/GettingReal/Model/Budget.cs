namespace GettingReal
{
    public class Budget 
    {
        private List<Product> _products;
        private PriceLevel _priceLevel;
        private double _discountPercentage;
        private double _discountAmount;
        private double _sum;

        public List<Product> Products 
        {     
            get { return _products; }
            private set
            {
                if (value != null) _products = value;
                else throw new ArgumentNullException(nameof(Products), "Products list cannot be set to null.");
            }
        }

        public PriceLevel PriceLevel 
        { 
            get { return _priceLevel; }
            set
            {
                if (Enum.IsDefined(typeof(PriceLevel), value)) _priceLevel = value;
                else throw new ArgumentException("Invalid price level value.");
            }
        }

        public double DiscountPercentage 
        { 
            get { return _discountPercentage; }
            set
            {
                if (value >= 0.0 && value <= 35.0) _discountPercentage = value;
                else throw new ArgumentOutOfRangeException(nameof(DiscountPercentage), "Discount percentage must be between 0 and 35.");
            }
        }

        public double DiscountAmount
        {
            get { return _discountAmount; }
            private set
            {
                if (value >= 0) _discountAmount = value;
                else throw new ArgumentOutOfRangeException(nameof(DiscountPercentage), "Discount amount must be a non-negative value.");
            }
        }

        public double Sum 
        { 
            get { return _sum; }
            private set
            {
                if (value >= 0) _sum = value;
                else throw new ArgumentOutOfRangeException(nameof(Sum), "Sum must be a non-negative value.");
            }
        }

        public Budget()
        {
            Products = new List<Product>();
            PriceLevel = PriceLevel.High; 
        }

        public void CalculateDiscount (int discountPercentage)
        {
            DiscountPercentage = discountPercentage;
            DiscountAmount = Sum * (discountPercentage/100.0);
        }

        public void CalculateSum()
        {
            double sum = 0;
            foreach (Product product in Products)
            {
               sum += product.Price; 
            }
            Sum = sum - DiscountAmount;
        }
    }
}