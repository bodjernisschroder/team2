using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Amulet : Merchandise
    {
        private static double _lowQualityValue = 12.5;
        private static double _mediumQualityValue = 20.0;
        private static double _highQualityValue = 27.5;

        public static double LowQualityValue
        {
            get { return _lowQualityValue; }
            set { _lowQualityValue = value; }
        }

        public static double MediumQualityValue
        {
            get { return _mediumQualityValue; }
            set { _mediumQualityValue = value; }

        }

        public static double HighQualityValue
        {
            get { return _highQualityValue; }
            set { _highQualityValue = value; }
        }

        public string Design { get; set; }
        public Level Quality { get; set; }


        public Amulet(string itemId)
        {
            ItemId = itemId;
            Quality = Level.medium;
        }

        public Amulet(string itemId, Level quality) : this(itemId)
        {
            Quality = quality;
        }

        public Amulet(string itemId, Level quality, string design) : this(itemId, quality)
        {
            Design = design;
        }

        public override double GetValue()
        {
            if (Quality == Level.low) return LowQualityValue;
            else if (Quality == Level.medium) return MediumQualityValue;
            else return HighQualityValue;
        }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}";
           
        }
    }
}