using System;
using Inwk.Jobs.Core.Input;
using NUnit.Framework;

namespace Inwk.Jobs.Core.Tests
{
    [TestFixture]
    public class JobReaderTests
    {
        private String TestYaml = @"Name: Job 1
RequiresExtraMargin: true
Items:
- Name: envelopes
  Cost: 520.00
- Name: letterhead
  Cost: 1983.37
  Taxation: TaxFree
";
        [Test]
        public void ItWillParseYaml()
        {
            var r = new YamlJobReader();
            var job  = r.ReadFromContent(TestYaml);
            Assert.IsNotNull(job);
            Assert.AreEqual(2, job.Items.Count);
        }
    }
}
