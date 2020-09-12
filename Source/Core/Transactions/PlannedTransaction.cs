using System;

namespace VilligerElectronics.BudgetPlanner.Core.Transactions
{
    public class PlannedTransaction
    {
        public PlannedTransaction(decimal ammount, DateTime dueDate)
        {
            Ammount = ammount;
            DueDate = dueDate;
        }

        public decimal Ammount { get; }
        public DateTime DueDate { get; }
    }
}
