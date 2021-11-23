namespace BudgetPlanner.Domain.Entities
{
    public record Balance
    {
        public DateOnly Date { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
