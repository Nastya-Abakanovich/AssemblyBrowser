using AssemblyBrowserLibrary.AssemblyComposition;

namespace AssemblyBrowserLibrary
{
    public class AssemblyBrowser
    {
        private readonly System.Reflection.Assembly? _assembly;


        public AssemblyBrowser(string filename)
        {
            try
            {
                _assembly = System.Reflection.Assembly.LoadFrom(filename);
            }
            catch
            {
                _assembly = null;
            }

        }

        public AssemblyInfo? GetAssemblyInfo()
        {
            if (_assembly != null)
            {
                return new AssemblyInfo(_assembly.GetName().Name, GetNamespaceInfo());
            }
            else
            {
                return null;
            }
        }

        private List<NamespaceInfo> GetNamespaceInfo()
        {
            IEnumerable<string?> namespaces = _assembly.GetTypes().Select(type => type.Namespace).Distinct();
            List<NamespaceInfo> namespaceInfos = new List<NamespaceInfo>();

            foreach (string namespaceName in namespaces)
            {
                NamespaceInfo namespaceInfo = new NamespaceInfo();
                namespaceInfo.NamespaceName = namespaceName;
                namespaceInfo.Classes = GetClassInfo(namespaceName);
                namespaceInfos.Add(namespaceInfo);
            }

            return namespaceInfos;
        }

        private List<ClassInfo> GetClassInfo(string namespaceName)
        {
            IEnumerable<Type> types = _assembly.GetTypes().Where(type => type.Namespace == namespaceName);
            List<ClassInfo> classInfos = new List<ClassInfo>();

            foreach (Type classType in types)
            {
                ClassInfo classInfo = new ClassInfo();
                classInfo.ClassName = classType.Name;
                classInfo.Fields = GetFieldInfo(classType);
                classInfo.Properties = GetPropertyInfo(classType);
                classInfo.Methods = GetMethodInfo(classType);
                classInfos.Add(classInfo);
            }

            return classInfos;
        }

        private List<FieldInfo> GetFieldInfo(Type classType)
        {
            var fields = classType.GetFields();
            List<FieldInfo> fieldInfos = new List<FieldInfo>();

            foreach (var field in fields)
            {
                FieldInfo fieldInfo = new FieldInfo();
                fieldInfo.FieldName = field.Name;
                fieldInfo.FieldType = field.FieldType.Name;
                fieldInfos.Add(fieldInfo);
            }

            return fieldInfos;
        }

        private List<PropertyInfo> GetPropertyInfo(Type classType)
        {
            var properties = classType.GetProperties();
            List<PropertyInfo> propertyInfos = new List<PropertyInfo>();

            foreach (var property in properties)
            {
                PropertyInfo propertyInfo = new PropertyInfo();
                propertyInfo.PropertyName = property.Name;
                propertyInfo.PropertyType = property.PropertyType.Name;
                propertyInfos.Add(propertyInfo);
            }

            return propertyInfos;
        }

        private List<MethodInfo> GetMethodInfo(Type classType)
        {
            var methods = classType.GetMethods();
            List<MethodInfo> methodInfos = new List<MethodInfo>();

            foreach (var method in methods)
            {
                MethodInfo methodInfo = new MethodInfo();
                methodInfo.MethodName = method.Name;
                methodInfo.ReturnType = method.ReturnType.Name;
                methodInfo.Parameters = GetParametersInfo(method);
                methodInfos.Add(methodInfo);
            }

            return methodInfos;
        }

        private List<FieldInfo> GetParametersInfo(System.Reflection.MethodInfo method)
        {
            List<FieldInfo> parameterInfos = new List<FieldInfo>();
            var parametrs = method.GetParameters();

            foreach (var param in parametrs)
            {
                FieldInfo parametrInfo = new FieldInfo();
                parametrInfo.FieldName = param.Name;
                parametrInfo.FieldType = param.ParameterType.Name;
                parameterInfos.Add(parametrInfo);
            }

            return parameterInfos;
        }
    }
}
