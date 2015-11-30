using Inwk.Jobs.Core.Domain;

namespace Inwk.Jobs.Core.Commerce
{
    /// <summary>
    /// Defines the way amount of print item is calculated
    /// </summary>
    interface IPrintItemCalculationStrategy
    {
        /// <summary>
        /// Calculates total for an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        decimal CalculateTotal(PrintItem item);

        /// <summary>
        /// Calculates the tax
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        decimal CalculateTax(PrintItem item);
    }
}
