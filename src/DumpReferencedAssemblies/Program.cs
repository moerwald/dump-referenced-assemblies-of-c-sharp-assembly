using DumpReferencedAssemblies.DependencyResolver;
using DumpReferencedAssemblies.DependencyResolver.Print;
using DumpReferencedAssemblies.Trace;

namespace DumpReferencedAssemblies
{
    partial class Program
    {

        static void Main(string[] args) =>
            new DependencyResolver.DependencyResolver(new DependencyTracing(new IndenPrinter())).Resolve(args[0]);
    }
}
