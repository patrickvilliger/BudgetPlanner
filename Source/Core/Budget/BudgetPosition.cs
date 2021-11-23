using System;
using System.Collections.Generic;

namespace VilligerElectronics.BudgetPlanner.Core.Budget
{
    public record BudgetPosition
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public DateOnly DueDate { get; set; }

        public DateOnly BookingDate { get; set; }

        public decimal Ammount { get; set; }

    }
}
