using DumpReferencedAssemblies.DependencyResolver;
using DumpReferencedAssemblies.DependencyResolver.Print;
using DumpReferencedAssemblies.Trace;

namespace DumpReferencedAssemblies
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var dependencyTracer = new DependencyTracingComposite();
            var resolve = new DependencyResolver.DependencyResolver(dependencyTracer);
            resolve.Resolve(args[0], string.Empty);
            new Trace.Persist.PersistDependencyTracingComposite(dependencyTracer, "abc").Persit();
            System.Console.WriteLine("Finished");

        } 
    }
}
