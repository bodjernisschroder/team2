using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd.Model;

namespace RegionSyd.DataAccess
{
    class AssignmentComboRepository
    {
        public List<AssignmentCombo> AssignmentCombos { get; set; }

        public AssignmentComboRepository() 
        {
            AssignmentCombos = new List<AssignmentCombo>();
        }
        public void Add(AssignmentCombo combo)
        {
            AssignmentCombos.Add(combo);
        }

        public void Remove(AssignmentCombo combo)
        {
            AssignmentCombos.Remove(combo);
        }
    }
}
