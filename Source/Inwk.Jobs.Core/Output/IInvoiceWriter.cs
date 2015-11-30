using System;
using Inwk.Jobs.Core.Domain.Invoicing;

namespace Inwk.Jobs.Core.Output
{
    public interface IInvoiceWriter
    {
        /// <summary>
        /// Writes invoice to a given file path
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="filePath"></param>
        void Write(Invoice invoice, String filePath);
    }
}
