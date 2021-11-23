namespace BudgetPlanner.Domain.Entities
{
    public record ForecastPosition
    {
        public string Description { get; set; }

        public DateOnly Time { get; set; }

        public decimal Change { get; set; }

        public decimal Balance { get; set; }
    }
}
