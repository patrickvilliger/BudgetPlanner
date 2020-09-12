using System;

namespace VilligerElectronics.BudgetPlanner.Core.Budget
{
    public class OneTimeBudgetLine
    {
        public OneTimeBudgetLine(decimal ammount, DateTime dueDate)
        {
            Ammount = ammount;
            DueDate = dueDate;
        }

        public decimal Ammount { get; }
        public DateTime DueDate { get; }
    }
}
