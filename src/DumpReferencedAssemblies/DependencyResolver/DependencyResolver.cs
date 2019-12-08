using DumpReferencedAssemblies.Trace;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class DependencyResolver
    {
        public DependencyResolver(DependencyTracing tracer)
        {
            Tracer = tracer ?? throw new ArgumentNullException(nameof(tracer));
        }

        List<string> assemblies = new List<string>();
        private List<string> failedAssemblies = new List<string>();

        public List<string> ResolvedAssemblies { get => new List<string>(assemblies); }
        public DependencyTracing Tracer { get; }

        public void Resolve(string path)
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
                    Tracer.NewElemenFound(path);
                    return;
                }

                var asm = Load(path);
                if (asm != null)
                {
                    assemblies.Add(asm.FullName);
                }
                Tracer.NewElemenFound(path);

                foreach (var referencedAssemblies in asm.GetReferencedAssemblies())
                {
                    Resolve(referencedAssemblies.FullName);
                }
            }
            catch
            {
                Tracer.NewElemenFound(path);
                failedAssemblies.Add(path);
            }
            finally
            {
                Tracer.SearchingForNextParent();
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
