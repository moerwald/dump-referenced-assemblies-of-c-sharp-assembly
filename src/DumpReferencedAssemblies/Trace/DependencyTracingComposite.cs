using DumpReferencedAssemblies.DependencyResolver.Print;
using System;

namespace DumpReferencedAssemblies.Trace
{
    public class DependencyTracingComposite : DependencyTracingPrinter
    {
        public DependencyTracingComposite() : base (new IndenPrinter()) { }

        public MyAssembly RootAsssembly { get; private set; }
        private MyAssembly CurrentAssembly {  get;  set; }


        public override void NewElemenFound(string element, string parent)
        {
            base.NewElemenFound(element, parent);

            if (ElementIsRootOne())
                CurrentAssembly = RootAsssembly = new MyAssembly(element);
            else
                CurrentAssembly = CurrentAssembly.Add(element);

            bool ElementIsRootOne() => string.IsNullOrEmpty(parent);
        }

        public override void SearchingForChildElements() { base.SearchingForChildElements(); }

        public override void SearchingForNextParent()
        {
            base.SearchingForNextParent();
            if (CurrentAssembly.Parent != null )
                CurrentAssembly = CurrentAssembly.Parent;
            else if (CurrentAssembly != RootAsssembly)
                System.Console.WriteLine("####### Parent is null");
        }

    }
}
