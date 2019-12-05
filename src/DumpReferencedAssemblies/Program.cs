using System;

namespace DumpReferencedAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new DependencyResolver.DependencyResolver();
            resolver.Resolve(args[1]);
            foreach(var ass in resolver.ResolvedAssemblies)
            {
                Console.WriteLine(ass);
            }
        }
    }
}
