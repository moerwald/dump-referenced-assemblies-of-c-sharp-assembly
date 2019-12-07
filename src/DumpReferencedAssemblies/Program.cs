using DumpReferencedAssemblies.DependencyResolver;

namespace DumpReferencedAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new DependencyResolver.DependencyResolver(new IndenPrinter());
            resolver.Resolve(args[0]);
            //foreach(var ass in resolver.ResolvedAssemblies)
            //{
            //    Console.WriteLine(ass);
            //}
        }
    }
}
