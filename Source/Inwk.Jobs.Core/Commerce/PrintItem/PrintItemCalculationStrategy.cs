using System;

namespace Inwk.Jobs.Core.Commerce.PrintItem
{
    /// <summary>
    /// Base print item strategy
    /// </summary>
    public abstract class PrintItemCalculationStrategy : IPrintItemCalculationStrategy
    {
        public virtual decimal CalculateTotal(Domain.PrintItem item)
        {
            return Round(item.Cost);
        }

        public abstract decimal CalculateTax(Domain.PrintItem item);

        protected Decimal Round(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}