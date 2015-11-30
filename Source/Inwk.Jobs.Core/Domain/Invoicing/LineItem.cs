using System;

namespace Inwk.Jobs.Core.Domain.Invoicing
{
    /// <summary>
    /// Invoice line item
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Line item name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Total amount to be charged for customer
        /// </summary>
        public Decimal Amount { get; set; }

        /// <summary>
        /// Amount of tax
        /// </summary>
        public Decimal TaxAmount { get; set; }
    }
}