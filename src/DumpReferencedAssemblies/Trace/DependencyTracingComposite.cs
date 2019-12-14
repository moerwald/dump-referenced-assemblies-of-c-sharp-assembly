using DumpReferencedAssemblies.DependencyResolver.Print;

namespace DumpReferencedAssemblies.Trace
{
    public class DependencyTracingComposite : DependencyTracingPrinter
    {
        public DependencyTracingComposite()
            : base (new IndenPrinter())
        {

        }

        public MyAssembly RootAsssembly { get; private set; }
        private MyAssembly CurrentAssembly {  get;  set; }

        public override void NewElemenFound(string element, string parent)
        {
            base.NewElemenFound(element, parent);

            if (string.IsNullOrEmpty(parent))
            {
                RootAsssembly = new MyAssembly(element);
                CurrentAssembly = RootAsssembly;
            }
            else
            {
                CurrentAssembly = CurrentAssembly.Add(element, CurrentAssembly);
            }
        }

        public override void SearchingForChildElements() { base.SearchingForChildElements(); }

        public override void SearchingForNextParent()
        {
            base.SearchingForNextParent();
            CurrentAssembly = CurrentAssembly.Parent ?? CurrentAssembly;
        }

    }


}
