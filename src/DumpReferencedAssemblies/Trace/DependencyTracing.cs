using DumpReferencedAssemblies.DependencyResolver;
using DumpReferencedAssemblies.DependencyResolver.Print;
using System;

namespace DumpReferencedAssemblies.Trace
{
    public class DependencyTracing : IDependencyTracing
    {
        public DependencyTracing(IndenPrinter printer) =>
            Printer = printer ?? throw new ArgumentNullException(nameof(printer));

        public IndenPrinter Printer { get; }

        public void NewElemenFound(string element)
        {
            ++Printer.Indent;
            Printer.PrintPath(element);
        }

        public void SearchingForChildElements()
        {
        }

        public void SearchingForNextParent() => --Printer.Indent;
    }
}
