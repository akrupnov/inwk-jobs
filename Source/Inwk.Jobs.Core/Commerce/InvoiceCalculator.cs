using System;
using System.Collections.Generic;
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

            return new Invoice() {Customer = customerName, Date = DateTime.Now, Items = new List<LineItem>()};
        }
    }
}
