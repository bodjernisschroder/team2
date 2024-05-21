namespace GettingReal
{
    public class Product
    {
        private string _name;
        private int _timeEstimate;
        private PriceLevel _priceLevel;
        private int _price;

        public string Name
        {
            get { return _name; }
            private set
            {
                if (!string.IsNullOrEmpty(value)) _name = value;
                else throw new ArgumentException("Name cannot be null or empty.");
            }
        }
        public int TimeEstimate
        {
            get { return _timeEstimate; }
            set
            {
                if (value > 0)
                {
                    _timeEstimate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(TimeEstimate), "Time estimate must be greater than 0.");
                }
            }
        }
        public PriceLevel PriceLevel
        {
            get { return _priceLevel; }
            set
            {
                if (Enum.IsDefined(typeof(PriceLevel), value))
                {
                    _priceLevel = value;
                }
                else throw new ArgumentException("Invalid price level value.");
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else throw new ArgumentOutOfRangeException("Price cannot be negative.");
            }
        }

        public Product(string name, int timeEstimate, PriceLevel priceLevel)
        {
            Name = name;
            TimeEstimate = timeEstimate;
            PriceLevel = priceLevel;
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            switch (PriceLevel)
            {
                case PriceLevel.Low:
                    Price = 1100 * TimeEstimate;
                    break;
                case PriceLevel.Medium:
                    Price = 1400 * TimeEstimate;
                    break;
                case PriceLevel.High:
                    Price = 1600 * TimeEstimate;
                    break;
                case PriceLevel.Custom:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void MakeCustomPrice(int price)
        {
            PriceLevel = PriceLevel.Custom;
            Price = price;
        }
    }
}