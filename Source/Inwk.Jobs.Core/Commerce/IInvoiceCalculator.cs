using System;
using Inwk.Jobs.Core.Domain;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Commerce
{
    /// <summary>
    /// Calculates invoice for a job
    /// </summary>
    public interface IInvoiceCalculator
    {
        /// <summary>
        /// Calculates invoice for given job and customer
        /// </summary>
        /// <param name="job"></param>
        /// <param name="customerName"></param>
        /// <returns></returns>
        Invoice Calculate(Job job, String customerName);
    }
}