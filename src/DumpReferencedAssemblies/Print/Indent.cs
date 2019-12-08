namespace DumpReferencedAssemblies.DependencyResolver.Print
{
    public class Indent
    {
        public const int Increment = 2;
        private int indent = 0;

        public Indent(int indent) => this.indent = indent;

        public static Indent operator ++(Indent id)
        {
            id.indent += Increment;
            return id;
        }
        public static Indent operator --(Indent id)
        {
            if (id.indent - Increment >= 0)
                id.indent -= Increment;

            return id;
        }

        public static implicit operator int(Indent i) => i.indent;
        public static explicit operator Indent(int i) => new Indent(i);

    }
}
