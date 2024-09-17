using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Model
{
    class AssignmentCombo
    {
        private static int _lastId = 0;

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<Assignment> _assignments;
        public List<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }

        public AssignmentCombo(List<Assignment> assignments)
        {
            _id = GetNextId();
            _assignments = assignments;
        }

        private static int GetNextId()
        {
            return ++_lastId;
        }
    }
}
