using System;

namespace DumpReferencedAssemblies.DependencyResolver
{
    public class AutoIndent : IDisposable
    {
        public AutoIndent(Indent indent)
        {
            Indent = indent ?? throw new ArgumentNullException(nameof(indent));
            ++Indent;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public Indent Indent { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    --Indent;
                }

                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose() => Dispose(true);
        #endregion

    }
}
