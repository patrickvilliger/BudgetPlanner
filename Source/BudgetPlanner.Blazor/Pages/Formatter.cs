namespace BudgetPlanner.Blazor.Pages
{
    public static class Formatter
    {
        public static string ToCurrency(this decimal val)
        {
            return val.ToString("C");
        }

        public static string ToUpDown(this decimal val)
        {
            if(val > 0)
            {
                return $"+ {val.ToCurrency()}";
            }

            return $"- {val.ToCurrency()}";
        }
    }
}
