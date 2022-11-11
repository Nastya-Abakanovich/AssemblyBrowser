namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class PropertyInfo
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }

        public PropertyInfo(string propertyName, string propertyType)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
        }

        public PropertyInfo()
        {
        }
    }
}
