using System.Collections.Generic;
using System.Linq;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Commerce
{
    /// <summary>
    /// Calculates total with extra margin
    /// </summary>
    public class ExtraMarginCalculationStrategy : StandardMarginCalculationStrategy
    {
        /// <summary>
        /// Should be configurable
        /// </summary>
        protected const decimal ExtraMargin = 0.05m;

        public override decimal Calculate(List<LineItem> lineItems)
        {
            var totalCost = lineItems.Sum(x => x.Amount - x.TaxAmount);
            var totalTax = lineItems.Sum(x => x.TaxAmount);

            return Round(totalCost + totalCost * (DefaultMargin + ExtraMargin) + totalTax);
        }

    }
}