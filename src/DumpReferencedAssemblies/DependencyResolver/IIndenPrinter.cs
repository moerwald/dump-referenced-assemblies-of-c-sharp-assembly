namespace DumpReferencedAssemblies.DependencyResolver
{
    public interface IIndenPrinter
    {
        Indent Indent { get; set; }

        void PrintPath(string path);
    }
}