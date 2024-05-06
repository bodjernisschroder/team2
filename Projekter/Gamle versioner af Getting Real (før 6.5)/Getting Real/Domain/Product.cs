using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set { _name = value; }
        }
        public int TimeEstimate
        {
            get { return _timeEstimate; }
            set { _timeEstimate = value; }
        }
        public PriceLevel PriceLevel
        {
            get { return _priceLevel; }
            set { _priceLevel = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Product(string name, int timeEstimate)
        {
            Name = name;
            TimeEstimate = timeEstimate;
            PriceLevel = PriceLevel.High;
            Price = CalculatePrice();
        }

        public Product(string name, int timeEstimate, PriceLevel priceLevel)
        {
            Name = name;
            TimeEstimate = timeEstimate;
            PriceLevel = priceLevel;
            Price = CalculatePrice();
        }

        public int CalculatePrice()
        {
            switch (PriceLevel)
            {
                case PriceLevel.Low:
                    return 1100 * TimeEstimate;
                case PriceLevel.Medium:
                    return 1400 * TimeEstimate;
                case PriceLevel.High:
                    return 1600 * TimeEstimate;
                case PriceLevel.Custom:
                    return Price;
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
