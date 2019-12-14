using System.Collections.Generic;

namespace DumpReferencedAssemblies.Trace
{
    public class MyAssembly
    {
        public MyAssembly(string assemblyInfo, MyAssembly parent)
        {
            AssemblyInfo = assemblyInfo ?? throw new System.ArgumentNullException(nameof(assemblyInfo));
            Parent = parent;
        }

        public MyAssembly(string assemblyInfo)
        {
            AssemblyInfo = assemblyInfo ?? throw new System.ArgumentNullException(nameof(assemblyInfo));
        }

        public List<MyAssembly> List { get; } = new List<MyAssembly>();

        public MyAssembly Parent { get; private set; }
        public string AssemblyInfo { get; }

        public MyAssembly Add(string assemblyInfo, MyAssembly parent)
        {
            var asm = new MyAssembly(assemblyInfo, parent);
            List.Add(asm);
            return asm;
        }
        public override string ToString() => AssemblyInfo;
    }
}
