using System.Collections.Generic;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Commerce
{
    public interface ITotalCaclulationStrategy
    {
        /// <summary>
        /// Caclulates total for given line items
        /// </summary>
        /// <param name="lineItems"></param>
        /// <returns></returns>
        decimal Calculate(List<LineItem> lineItems);
    }
}
