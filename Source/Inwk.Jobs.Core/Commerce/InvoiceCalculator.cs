using System;
using System.Collections.Generic;
using System.Linq;
using Inwk.Jobs.Core.Commerce.PrintItem;
using Inwk.Jobs.Core.Domain;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Commerce
{
    public class InvoiceCalculator : IInvoiceCalculator
    {
        public Invoice Calculate(Job job, String customerName)
        {
            if (job == null)
            {
                throw new ArgumentNullException("job");
            }

            var invoice = new Invoice
            {
                Customer = customerName,
                Date = DateTime.Now,
                Items = job.Items.Select(GetLineItem).ToList()
            };
            invoice.TotalAmount = GetTotalCaclulationStrategy(job).Calculate(invoice.Items.ToList());
            

            return invoice;
        }

        private LineItem GetLineItem(Domain.PrintItem printItem)
        {
            var strategy = GetItemStrategy(printItem);

            return new LineItem()
            {
                Name = printItem.Name,
                Amount = strategy.CalculateTotal(printItem),
                TaxAmount = strategy.CalculateTax(printItem)
            };
        }

        private ITotalCaclulationStrategy GetTotalCaclulationStrategy(Job job)
        {
            if (job.RequiresExtraMargin)
            {
                return new ExtraMarginCalculationStrategy();
            }

            return new StandardMarginCalculationStrategy();
        }

        /// <summary>
        /// Decides best calculation strategy for a line item
        /// </summary>
        /// <param name="printItem"></param>
        /// <returns></returns>
        private IPrintItemCalculationStrategy GetItemStrategy(Domain.PrintItem printItem)
        {
            if (printItem.Taxation == TaxationType.Standard)
            {
                return new StandardTaxCalulcationStrategy();
            }
            if (printItem.Taxation == TaxationType.TaxFree)
            {
                return new TaxFreeItemCalculationStrategy();
            }

            throw new Exception("Unknown taxation: " + printItem.Taxation);
        }
    }
}
