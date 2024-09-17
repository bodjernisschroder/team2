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

        // midlertidig til test
        private static Model.Type type1 = new Model.Type { Name = "Type 1", ServiceGoal = DateTime.Now.AddDays(10) };
        private static Model.Type type2 = new Model.Type { Name = "Type 2", ServiceGoal = DateTime.Now.AddDays(20) };
        private static Model.Type type3 = new Model.Type { Name = "Type 3", ServiceGoal = DateTime.Now.AddDays(30) };

        public AssignmentRepository() 
        {
            Assignments = new List<Assignment>();
            InitializeExample();
        }
        public void Add(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void Remove(Assignment assignment)
        {
            Assignments.Remove(assignment);
        }

        private void InitializeExample()
        {
            Assignments.Add(new Assignment(
                Region.Syddanmark,
                1001,
                type1, // Use the Type instance
                "Task 1 Description",
                DateTime.Now.AddDays(1),
                "123 Main St",
                "456 Elm St"
            ));

            Assignments.Add(new Assignment(
                Region.Midtjylland,
                1002,
                type2, // Use the Type instance
                "Task 2 Description",
                DateTime.Now.AddDays(3),
                "789 Oak St",
                "101 Pine St"
            ));

            Assignments.Add(new Assignment(
                Region.Nordjylland,
                1003,
                type3, // Use the Type instance
                "Task 3 Description",
                DateTime.Now.AddDays(5),
                "112 Maple St",
                "131 Birch St"
            ));

            Assignments.Add(new Assignment(
    Region.Syddanmark,
    1004,
    type1, // Reuse the Type instance
    "Task 4 Description",
    DateTime.Now.AddDays(7),
    "400 Forest Ave",
    "500 River Rd"
));

            Assignments.Add(new Assignment(
                Region.Hovedstaden,
                1005,
                type2, // Reuse the Type instance
                "Task 5 Description",
                DateTime.Now.AddDays(10),
                "600 Palm St",
                "700 Oak St"
            ));

            Assignments.Add(new Assignment(
                Region.Sjælland,
                1006,
                type3, // Reuse the Type instance
                "Task 6 Description",
                DateTime.Now.AddDays(12),
                "800 Cedar St",
                "900 Pine St"
            ));

            Assignments.Add(new Assignment(
                Region.Midtjylland,
                1007,
                type1, // Use Type 1 instance
                "Task 7 Description",
                DateTime.Now.AddDays(14),
                "100 Birch Rd",
                "200 Willow Rd"
            ));

            Assignments.Add(new Assignment(
                Region.Nordjylland,
                1008,
                type2, // Use Type 2 instance
                "Task 8 Description",
                DateTime.Now.AddDays(16),
                "300 Maple Rd",
                "400 Spruce St"
            ));

            Assignments.Add(new Assignment(
                Region.Syddanmark,
                1009,
                type3, // Use Type 3 instance
                "Task 9 Description",
                DateTime.Now.AddDays(18),
                "500 Elm Rd",
                "600 Redwood St"
            ));

            Assignments.Add(new Assignment(
                Region.Hovedstaden,
                1010,
                type1, // Use Type 1 instance
                "Task 10 Description",
                DateTime.Now.AddDays(20),
                "700 Pine Ave",
                "800 Oak Ave"
            ));
        }
    }
}
