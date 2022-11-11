namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class ClassInfo
    {
        public string ClassName { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<PropertyInfo> Properties { get; set; }
        public List<MethodInfo> Methods { get; set; }

        public ClassInfo(string className, List<FieldInfo> fields, List<PropertyInfo> properties, List<MethodInfo> methods)
        {
            ClassName = className;
            Fields = fields;
            Properties = properties;
            Methods = methods;
        }

        public ClassInfo()
        {
        }
    }
}
