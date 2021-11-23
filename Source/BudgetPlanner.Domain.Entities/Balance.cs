namespace BudgetPlanner.Domain.Entities
{
    public record Balance
    {
        public string Id { get; set; }

        public DateOnly Date { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
