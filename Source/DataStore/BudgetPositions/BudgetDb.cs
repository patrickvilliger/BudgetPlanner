using System;
using System.Collections.Generic;

namespace VilligerElectronics.BudgetPlanner.DataStore.BudgetPositions
{
    internal class BudgetDb
    {
        public string? Id { get; set; }

        public string? Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime BookingDate { get; set; }

        public decimal Ammount { get; set; }
    }
}
