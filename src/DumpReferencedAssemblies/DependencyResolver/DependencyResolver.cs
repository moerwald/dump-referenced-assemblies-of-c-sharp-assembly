using DumpReferencedAssemblies.Trace;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class DependencyResolver
    {
        public DependencyResolver(DependencyTracingPrinter tracer)
        {
            Tracer = tracer ?? throw new ArgumentNullException(nameof(tracer));
        }

        List<string> assemblies = new List<string>();
        private List<string> failedAssemblies = new List<string>();

        public List<string> ResolvedAssemblies { get => new List<string>(assemblies); }
        public DependencyTracingPrinter Tracer { get; }

        public void Resolve(string path, string parent)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
                {
                    return;
                }

                if (assemblies.Contains(path))
                {
                    // Break the recursion
                    Tracer.NewElemenFound(path, parent);
                    return;
                }

                var asm = Load(path);
                if (asm != null)
                {
                    assemblies.Add(asm.FullName);
                }
                Tracer.NewElemenFound(path, parent);

                foreach (var referencedAssemblies in asm.GetReferencedAssemblies())
                {
                    Resolve(referencedAssemblies.FullName, path);
                }
            }
            catch
            {
                Tracer.NewElemenFound(path,parent);
                failedAssemblies.Add(path);
            }
            finally
            {
                Tracer.SearchingForNextParent();
            }
        }

        private static Assembly Load(string path)
        {
            System.Reflection.Assembly asm;
            if (path.Contains("/") || path.Contains("\\"))
            {
                asm = System.Reflection.Assembly.LoadFrom(path);
            }
            else
            {
                asm = System.Reflection.Assembly.Load(path);
            }

            return asm;
        }
    }
}
