using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class BudgetItem
    {
        public double Amount { get; set; }
        public string Description { get; set; }

        public BudgetItem(double amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }
}
