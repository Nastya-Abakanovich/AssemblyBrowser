namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class NamespaceInfo
    {
        public string NamespaceName { get; set; }
        public List<TypeInfo> Types { get; set; }

        public NamespaceInfo(string namespaceName, List<TypeInfo> types)
        {
            NamespaceName = namespaceName;
            Types = types;
        }

        public NamespaceInfo()
        {
        }
    }
}
