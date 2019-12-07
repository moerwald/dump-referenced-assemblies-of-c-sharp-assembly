using System;
using System.Linq;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class IndenPrinter : IIndenPrinter
    {
        private Indent indent = new Indent(0);

        public Indent Indent { get => indent; set => indent = value; }

        public void PrintPath(string path)
        {
            var indents = Indent / Indent.Increment;
            foreach (var i in Enumerable.Range(0, indents))
            {
                WriteIndent();
                if (SkipFirstTreeColumn(i))
                {
                    WriteNodeCharacter();
                }
            }

            WriteDashesBefore(path);
        }

        private static bool SkipFirstTreeColumn(int i)
        {
            const int FirstTreeColumn = 0;
            return i > FirstTreeColumn;
        }

        // Todo: Move to stream writer
        private void WriteIndent() => Console.Write($"{new string(' ', Indent.Increment)}");
        private void WriteDashesBefore(string path) => Console.WriteLine($"-- {path}");
        private void WriteNodeCharacter() => Console.Write("|");

    }
}
