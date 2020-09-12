using System;
using VilligerElectronics.BudgetPlanner.Core.Budget;

namespace VilligerElectronics.BudgetPlanner.Core.Transactions
{
    public class PlannedTransaction : BudgetLineBase
    {
        public PlannedTransaction(string name, decimal ammount, DateTime dueDate)
            : base(name)
        {
            Ammount = ammount;
            DueDate = dueDate;
        }

        public decimal Ammount { get; }
        public DateTime DueDate { get; }
    }
}
