using System;
using Inwk.Jobs.Core.Domain;

namespace Inwk.Jobs.Core.Commerce
{
    /// <summary>
    /// Base print item strategy
    /// </summary>
    public abstract class PrintItemCalculationStrategy : IPrintItemCalculationStrategy
    {
        public virtual decimal CalculateTotal(PrintItem item)
        {
            return Round(item.Cost);
        }

        public abstract decimal CalculateTax(PrintItem item);

        protected Decimal Round(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}