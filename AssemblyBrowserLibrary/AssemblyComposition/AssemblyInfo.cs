namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class AssemblyInfo
    {
        public string AssemblyName { get; set; }
        public List<NamespaceInfo> Namespaces { get; set; }

        public AssemblyInfo(string assemblyName, List<NamespaceInfo> namespaces)
        {
            AssemblyName = assemblyName;
            Namespaces = namespaces;
        }

        public AssemblyInfo()
        {
        }
    }
}