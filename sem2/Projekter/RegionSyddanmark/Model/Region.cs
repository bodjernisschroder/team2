using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Model
{
    public enum RegionEnum
    {
        Syddanmark = 1,
        Midtjylland,
        Nordjylland,
        Sjælland,
        Hovedstaden
    }

    public class Region
    {
        public RegionEnum RegionEnum { get; set; }
    }
}