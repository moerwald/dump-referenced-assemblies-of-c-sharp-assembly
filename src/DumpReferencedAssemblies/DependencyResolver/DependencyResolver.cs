using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class DependencyResolver
    {
        List<string> assemblies = new List<string>();

        public List<string> ResolvedAssemblies { get => new List<string>(assemblies); }

        public void Resolve(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            if (assemblies.Contains(path))
            {
                // Break the recursion
                return;
            }

            try
            {
                var asm = Load(path);
                if (asm != null)
                {
                    assemblies.Add(asm.FullName);
                }

                foreach (var referencedAssemblies in asm.GetReferencedAssemblies())
                {
                    Resolve(referencedAssemblies.FullName);
                }
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e);
            }

        }

        private static Assembly Load(string path)
        {
            Assembly asm;
            if (path.Contains("/"))
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
