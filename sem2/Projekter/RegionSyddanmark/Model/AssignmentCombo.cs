using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Model
{
    public class AssignmentCombo
    {
        // private static int _lastId = 0;

        private int _comboId;
        public int ComboId
        {
            get { return _comboId; }
            set { _comboId = value; }
        }

        // private List<Assignment> _assignments;
        // public List<Assignment> Assignments
        // {
        //     get { return _assignments; }
        //     set { _assignments = value; }
        // }

        // public AssignmentCombo();

        // public AssignmentCombo(List<Assignment> assignments);

        // private static int GetNextId()
        // {
        //     return ++_lastId;
        // }
    }
}
