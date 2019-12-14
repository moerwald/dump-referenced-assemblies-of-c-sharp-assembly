using DumpReferencedAssemblies.DependencyResolver;
using DumpReferencedAssemblies.DependencyResolver.Print;
using System;

namespace DumpReferencedAssemblies.Trace
{


    public abstract class DependencyTracingPrinter : IDependencyTracing
    {
        public DependencyTracingPrinter(IndenPrinter printer)
        {
            Printer = printer ?? throw new ArgumentNullException(nameof(printer));
        }

        public IndenPrinter Printer { get; }

        public virtual void NewElemenFound(string element, string parent)
        {
            ++Printer.Indent;
            Printer.PrintPath(element);

        }

        public virtual void SearchingForChildElements() { }

        public virtual void SearchingForNextParent()
        {
            --Printer.Indent;
        }
    }


}
