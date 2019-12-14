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
            var converted = Newtonsoft.Json.JsonConvert.SerializeObject(DependencyTracingComposite.RootAsssembly);

        }

        public DependencyTracingComposite DependencyTracingComposite { get; }
        public string FilePath { get; }
    }
}
