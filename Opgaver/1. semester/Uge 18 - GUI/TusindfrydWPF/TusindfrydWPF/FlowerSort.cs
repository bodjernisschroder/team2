using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF
{
    public class FlowerSort
    {
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int ProductionTime { get; set; }
        public int HalfLifeTime { get; set; }
        public int Size { get; set; }

        public FlowerSort(string name, string picturePath, int productionTime, int halfLifeTime, int size) 
        {
            Name = name;
            PicturePath = picturePath;
            ProductionTime = productionTime;
            HalfLifeTime = halfLifeTime;
            Size = size;
                       
        }

        public override string ToString()
        {
            return $"Blomst: {Name}, produktionstid: {ProductionTime}, halveringstid: {HalfLifeTime}, størrelse: {Size}";
        }
    }
}
