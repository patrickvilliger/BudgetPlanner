using System;

namespace VilligerElectronics.BudgetPlanner.Core.Budget
{
    public class OneTimeBudgetLine : BudgetLineBase
    {
        public OneTimeBudgetLine(string name, decimal ammount, DateTime dueDate)
            : base(name)
        {
            Ammount = ammount;
            DueDate = dueDate;
        }

        public decimal Ammount { get; }
        public DateTime DueDate { get; }
    }
}
