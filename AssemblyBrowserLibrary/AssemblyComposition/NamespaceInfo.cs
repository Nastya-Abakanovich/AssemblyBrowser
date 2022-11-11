namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class NamespaceInfo
    {
        public string NamespaceName { get; set; }
        public List<ClassInfo> Classes { get; set; }

        public NamespaceInfo(string namespaceName, List<ClassInfo> classes)
        {
            NamespaceName = namespaceName;
            Classes = classes;
        }

        public NamespaceInfo()
        {
        }
    }
}
