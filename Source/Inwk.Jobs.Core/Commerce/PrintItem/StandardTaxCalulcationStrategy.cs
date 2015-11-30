namespace Inwk.Jobs.Core.Commerce.PrintItem
{
    /// <summary>
    /// Calculates item amount with standard sales tax
    /// </summary>
    public class StandardTaxCalulcationStrategy : PrintItemCalculationStrategy
    {
        /// <summary>
        /// Amount of tax, ultimately should be externalized
        /// </summary>
        private const decimal TaxAmount = 0.07m;

        public override decimal CalculateTotal(Domain.PrintItem item)
        {
            return Round(item.Cost + item.Cost*TaxAmount);
        }

        public override decimal CalculateTax(Domain.PrintItem item)
        {
            return Round(item.Cost*TaxAmount);
        }
    }
}