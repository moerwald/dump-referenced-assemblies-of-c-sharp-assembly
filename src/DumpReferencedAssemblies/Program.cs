using DumpReferencedAssemblies.DependencyResolver;

namespace DumpReferencedAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new IndenPrinter();
            var resolver = new DependencyResolver.DependencyResolver(path =>
            {
                ++printer.Indent;
                printer.PrintPath(path);

            },
            () => --printer.Indent);

            resolver.Resolve(args[0]);
        }
    }
}
