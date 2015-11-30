using System;
using System.Collections.Generic;
using System.IO;
using Inwk.Jobs.Core.Domain;
using YamlDotNet.Serialization;

namespace Inwk.Jobs.Core.Input
{
    public class YamlJobReader : IJobReader
    {
        public Job Read(string filePath)
        {
            return ReadFromContent(File.ReadAllText(filePath));
        }

        protected internal Job ReadFromContent(String yamlConent)
        {
            var deserializer = new Deserializer();
            return deserializer.Deserialize<Job>(new StringReader(yamlConent));
        }
    }
}