using System.Reflection;
using DumpReferencedAssemblies.Trace;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DumpReferencedAssemblies.JsonSerialization
{
    internal class MyAssemblyContractResolver : DefaultContractResolver
    {
        public MyAssemblyContractResolver() { }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property =  base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(MyAssembly) && property.PropertyName == nameof(MyAssembly.Parent))
                    property.ShouldSerialize = instance => false;

            return property;
        }
    }
}
