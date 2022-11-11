namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class FieldInfo
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public FieldInfo(string fieldName, string fieldType)
        {
            FieldName = fieldName;
            FieldType = fieldType;
        }

        public FieldInfo()
        {
        }
    }
}
