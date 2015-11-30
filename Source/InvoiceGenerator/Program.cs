using System;
using System.IO;
using Inwk.Jobs.Core.Commerce;
using Inwk.Jobs.Core.Input;
using Inwk.Jobs.Core.Output;

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Write("Please provide exactly two parameters to: input file full path (yaml) and output file full path (pdf)");
                return;
            }
            var input = args[0];
            if (!File.Exists(input))
            {
                Console.WriteLine("Input file does not exist: " + input);
                return;
            }

            var output = args[1];
            if (File.Exists(output))
            {
                Console.WriteLine("Output file already exists: " + output);
                return;
            }

            var job = JobReader.Read(input);
            Console.WriteLine("Succesfully read job: " + job.Name);

            var invoice = Calculator.Calculate(job, "Customer name");

            Console.WriteLine("Generated invoice, total amount: " + invoice.TotalAmount);

            InvoiceWriter.Write(invoice, output);

            Console.WriteLine("Saved invoice to: " + output);


        }

        private static IInvoiceCalculator Calculator
        {
            get { return new InvoiceCalculator();}
        }

        private static IJobReader JobReader
        {
            get {  return new YamlJobReader();}
        }

        private static IInvoiceWriter InvoiceWriter
        {
            get { return new PdfInvoiceWriter();}
        }
    }
}
