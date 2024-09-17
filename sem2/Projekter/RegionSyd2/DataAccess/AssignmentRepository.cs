using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd.Model;

namespace RegionSyd.DataAccess
{
    class AssignmentRepository : IRepository<Assignment>
    {
        public List<Assignment> Assignments { get; set; }
        public AssignmentRepository() 
        {
            Assignments = new List<Assignment>();
        }
        public void Add(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void Remove(Assignment assignment)
        {
            Assignments.Remove(assignment);
        }
    }
}
