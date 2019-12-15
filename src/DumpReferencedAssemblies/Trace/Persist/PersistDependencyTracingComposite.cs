using DumpReferencedAssemblies.JsonSerialization;
using Newtonsoft.Json;
using System;

namespace DumpReferencedAssemblies.Trace.Persist
{
    public class PersistDependencyTracingComposite
    {
        public PersistDependencyTracingComposite(DependencyTracingComposite dependencyTracingComposite,
                                                 string filePath)
        {
            DependencyTracingComposite = dependencyTracingComposite ?? throw new ArgumentNullException(nameof(dependencyTracingComposite));
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public void Persit()
        {
            var converted = JsonConvert.SerializeObject(
                DependencyTracingComposite.RootAsssembly,
                new JsonSerializerSettings { ContractResolver = new MyAssemblyContractResolver() });
            Console.WriteLine(converted);

        }

        public DependencyTracingComposite DependencyTracingComposite { get; }
        public string FilePath { get; }
    }
}
