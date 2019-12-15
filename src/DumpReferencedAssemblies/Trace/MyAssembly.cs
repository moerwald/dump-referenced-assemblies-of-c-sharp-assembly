using System;
using System.Collections.Generic;

namespace DumpReferencedAssemblies.Trace
{
    public class MyAssembly 
    {
        public MyAssembly(string assemblyInfo, MyAssembly parent)
        {
            Parent = parent;
            if (parent != null && this == parent)
            {
                throw new System.ArgumentException($"Self references are not allowed. {parent.ToString()}");
            }

            Details = new MyAssemblyDetails(assemblyInfo);
            AssemblyInfo = Details.Name;
        }

        public MyAssembly(string assemblyInfo)
        {
            Details = new MyAssemblyDetails(assemblyInfo);
            AssemblyInfo = Details.Name;
        }

        public List<MyAssembly> Dependencies { get; } = new List<MyAssembly>();

        public MyAssembly Parent { get; private set; }
        public string AssemblyInfo { get; }
        public MyAssemblyDetails Details { get; }

        public MyAssembly Add(string assemblyInfo)
        {
            var asm = new MyAssembly(assemblyInfo, this);
            Dependencies.Add(asm);
            return asm;
        }
        public override string ToString() => AssemblyInfo;
    }
}
