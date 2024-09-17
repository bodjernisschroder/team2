using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Model
{
    public class Type
    {
        private static int _lastId = 0;
        private int _id;
        public int ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Name { get; set; }
        public DateTime ServiceGoal { get; set; }

        public Type()
        {
            _id = GetNextId();
            Name = "Type";
            ServiceGoal = DateTime.Now;
        }
        private static int GetNextId()
        {
            return ++_lastId;
        }
    }
}
