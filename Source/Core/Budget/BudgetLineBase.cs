namespace VilligerElectronics.BudgetPlanner.Core.Budget
{
    public abstract class BudgetLineBase
    {
        public BudgetLineBase(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
