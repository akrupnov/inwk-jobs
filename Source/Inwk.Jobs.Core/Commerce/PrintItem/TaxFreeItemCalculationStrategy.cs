namespace Inwk.Jobs.Core.Commerce.PrintItem
{
    /// <summary>
    /// Calculates amount, tax free
    /// </summary>
    public class TaxFreeItemCalculationStrategy : PrintItemCalculationStrategy
    {
        public override decimal CalculateTax(Domain.PrintItem item)
        {
            return 0.00m;
        }
    }
}