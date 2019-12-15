using System.Text.RegularExpressions;

namespace DumpReferencedAssemblies.Trace
{
    public class MyAssemblyDetails
    {
        private static Regex rx = new Regex(@"(?<Name>.+),\sVersion=(?<Version>.+),\sCulture=(?<Culture>.+),\sPublicKeyToken=(?<Token>.+)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public MyAssemblyDetails(string assemblyInfos)
        {
            if (string.IsNullOrEmpty(assemblyInfos))
            {
                throw new System.ArgumentNullException(nameof(assemblyInfos));
            }

            Name = assemblyInfos;

            var match = rx.Match(assemblyInfos);
            if (match != null && match.Success)
            {
                Name = match.Groups[nameof(Name)].Value;
                Version = match.Groups[nameof(Version)].Value;
                Culture = match.Groups[nameof(Culture)].Value;
                Token = match.Groups[nameof(Token)].Value;
            }
        }

        public string Name { get; set; }

        public string Version { get; set; }
        public string Culture { get; set; }

        public string Token { get; set; }

    }
}
