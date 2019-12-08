namespace DumpReferencedAssemblies.DependencyResolver.Print
{
    public interface IIndenPrinter
    {
        Indent Indent { get; set; }

        void PrintPath(string path);
    }
}