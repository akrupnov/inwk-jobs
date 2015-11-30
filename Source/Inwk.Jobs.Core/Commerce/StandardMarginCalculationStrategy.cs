using System;
using System.Collections.Generic;
using System.Linq;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Commerce
{
    /// <summary>
    /// Calculating total with standard margin
    /// </summary>
    public class StandardMarginCalculationStrategy : ITotalCaclulationStrategy
    {
        /// <summary>
        /// Should be configurable
        /// </summary>
        protected const decimal DefaultMargin = 0.11m;

        public virtual decimal Calculate(List<LineItem> lineItems)
        {
            var totalCost = lineItems.Sum(x => x.Amount - x.TaxAmount);
            var totalTax = lineItems.Sum(x => x.TaxAmount);

            return Round(totalCost + totalCost * DefaultMargin + totalTax);
        }

        protected Decimal Round(decimal amount)
        {
            return (0.02m/1.00m)*decimal.Round(amount*(1.00m/0.02m));
        }

    }
}