namespace DumpReferencedAssemblies.Trace
{
    public interface IDependencyTracing
    {
        void SearchingForChildElements();
        void SearchingForNextParent();
        void NewElemenFound(string element, string parent);
    }
}
