using Inwk.Jobs.Core.Domain;

namespace Inwk.Jobs.Core.Commerce
{
    /// <summary>
    /// Calculates amount, tax free
    /// </summary>
    public class TaxFreeItemCalculationStrategy : PrintItemCalculationStrategy
    {
        public override decimal CalculateTax(PrintItem item)
        {
            return 0.00m;
        }
    }
}