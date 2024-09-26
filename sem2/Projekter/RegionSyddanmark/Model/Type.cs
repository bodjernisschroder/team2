using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Model
{
    public class Type
    {
        // private static int _lastId = 0;
        // private int _id;
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string ServiceGoal { get; set; }

        // public Type(string name, string serviceGoal)
        // {
        //     _id = GetNextId();
        // }
        // private static int GetNextId()
        // {
        //     return ++_lastId;
        // }
    }
}
