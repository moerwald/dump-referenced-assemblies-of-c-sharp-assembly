using System.Collections.Generic;
using System.Reflection;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class DependencyResolver
    {
        public DependencyResolver(IIndenPrinter printer) => this.printer = printer;

        List<string> assemblies = new List<string>();
        private List<string> failedAssemblies = new List<string>();

        public List<string> ResolvedAssemblies { get => new List<string>(assemblies); }

        private IIndenPrinter printer;

        public void Resolve(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
                {
                    return;
                }

                using (new AutoIndent(printer.Indent))
                {
                    if (assemblies.Contains(path))
                    {
                        // Break the recursion
                        printer.PrintPath(path);
                        return;
                    }

                    var asm = Load(path);
                    if (asm != null)
                    {
                        assemblies.Add(asm.FullName);
                    }
                    printer.PrintPath(path);

                    foreach (var referencedAssemblies in asm.GetReferencedAssemblies())
                    {
                        Resolve(referencedAssemblies.FullName);
                    }
                }
            }
            catch
            {
                printer.PrintPath(path);
                failedAssemblies.Add(path);
            }

        }

        private static Assembly Load(string path)
        {
            Assembly asm;
            if (path.Contains("/") || path.Contains("\\"))
            {
                asm = Assembly.LoadFrom(path);
            }
            else
            {
                asm = Assembly.Load(path);
            }

            return asm;
        }
    }
}
