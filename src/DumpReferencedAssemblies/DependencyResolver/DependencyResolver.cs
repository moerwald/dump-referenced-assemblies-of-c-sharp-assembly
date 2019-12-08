using System;
using System.Collections.Generic;
using System.Reflection;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class DependencyResolver
    {
        public DependencyResolver(Action<string> newElementDetected, Action movingBackToParentElement)
        {

            NewElementDetected = newElementDetected ?? throw new ArgumentNullException(nameof(newElementDetected));
            MovingBackToParentElement = movingBackToParentElement ?? throw new ArgumentNullException(nameof(movingBackToParentElement));
        }

        List<string> assemblies = new List<string>();
        private List<string> failedAssemblies = new List<string>();

        public List<string> ResolvedAssemblies { get => new List<string>(assemblies); }
        public Action<string> NewElementDetected { get; }
        public Action MovingBackToParentElement { get; }

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
                    NewElementDetected(path);
                    return;
                }

                var asm = Load(path);
                if (asm != null)
                {
                    assemblies.Add(asm.FullName);
                }
                NewElementDetected(path);

                foreach (var referencedAssemblies in asm.GetReferencedAssemblies())
                {
                    Resolve(referencedAssemblies.FullName);
                }
            }
            catch
            {
                NewElementDetected(path);
                failedAssemblies.Add(path);
            }
            finally
            {
                MovingBackToParentElement();
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
