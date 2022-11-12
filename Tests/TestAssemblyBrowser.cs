using AssemblyBrowserLibrary;
using AssemblyBrowserLibrary.AssemblyComposition;

namespace Tests
{
    public class TestAssemblyBrowser
    {
        private AssemblyInfo _assemblyInfo;
        private const string correctNamespace1 = "InanimateNature";
        private const string correctNamespace2 = "LiveNature";
        private const string correctTypeName1 = "House";
        private const string correctTypeName2 = "Animal";
        private const string correctTypeName3 = "Person";

        [OneTimeSetUp]
        public void Setup()
        {
            AssemblyBrowser assemblyBrowser = new AssemblyBrowser("../../../ExampleLibrary.dll");
            _assemblyInfo = assemblyBrowser.GetAssemblyInfo();            
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectAssemblyName()
        {
            string correctAssemblyName = "ExampleLibrary";

            Assert.AreEqual(_assemblyInfo.AssemblyName, correctAssemblyName);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNumberOfNamespacies()
        {
            int correctNumberOfNamespacies = 4;

            Assert.AreEqual(correctNumberOfNamespacies, _assemblyInfo.Namespaces.Count);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNameOfNamespacies()
        {
            var correctNamespaces = _assemblyInfo.Namespaces.
                Where(nsp => nsp.NamespaceName == correctNamespace1 || nsp.NamespaceName == correctNamespace2);

            Assert.AreEqual(2, correctNamespaces.Count());
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNumberOfTypes()
        {
            int correctNumberOfTypes1 = 1;
            int correctNumberOfTypes2 = 2;

            var namespace1 = _assemblyInfo.Namespaces.Where(nsp => nsp.NamespaceName == correctNamespace1);
            var namespace2 = _assemblyInfo.Namespaces.Where(nsp => nsp.NamespaceName == correctNamespace2);

            Assert.AreEqual(correctNumberOfTypes1, namespace1.First().Classes.Count);
            Assert.AreEqual(correctNumberOfTypes2, namespace2.First().Classes.Count);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNameOfTypes()
        {
            string currTypes1 = _assemblyInfo.Namespaces[2].Classes[0].ClassName;
            string currTypes2 = _assemblyInfo.Namespaces[3].Classes[0].ClassName;
            string currTypes3 = _assemblyInfo.Namespaces[3].Classes[1].ClassName;

            Assert.AreEqual(correctTypeName1, currTypes1);
            Assert.AreEqual(correctTypeName2, currTypes2);
            Assert.AreEqual(correctTypeName3, currTypes3);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNumberOfFields()
        {
            var currFields1 = _assemblyInfo.Namespaces[2].Classes[0].Fields;
            var currFields2 = _assemblyInfo.Namespaces[3].Classes[0].Fields;
            var currFields3 = _assemblyInfo.Namespaces[3].Classes[1].Fields;

            Assert.AreEqual(2, currFields1.Count);
            Assert.AreEqual(4, currFields2.Count);
            Assert.AreEqual(3, currFields3.Count);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNameOfFields()
        {
            var currFieldsPerson = _assemblyInfo.Namespaces[3].Classes[1].Fields;
            var countCorrectFields = currFieldsPerson.Where(f => f.FieldName == "Name" || f.FieldName == "Surname" || f.FieldName == "City");

            Assert.AreEqual(3, countCorrectFields.Count());
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectTypeOfFields()
        {
            var currFieldsPerson = _assemblyInfo.Namespaces[3].Classes[1].Fields;
            var countCorrectFields = currFieldsPerson.Where(f => f.FieldType == "String");

            Assert.AreEqual(3, countCorrectFields.Count());
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNumberOfProperties()
        {
            var currProperties1 = _assemblyInfo.Namespaces[2].Classes[0].Properties;
            var currProperties2 = _assemblyInfo.Namespaces[3].Classes[0].Properties;
            var currProperties3 = _assemblyInfo.Namespaces[3].Classes[1].Properties;

            Assert.AreEqual(3, currProperties1.Count);
            Assert.AreEqual(0, currProperties2.Count);
            Assert.AreEqual(3, currProperties3.Count);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNameOfProperties()
        {
            var currPropertiesPerson = _assemblyInfo.Namespaces[3].Classes[1].Properties;
            var countCorrectProperties = currPropertiesPerson.Where(p => p.PropertyName == "Email" || p.PropertyName == "PhoneNumber" || p.PropertyName == "Address");

            Assert.AreEqual(3, countCorrectProperties.Count());
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectTypeOfProperties()
        {
            var countCorrectProperties = _assemblyInfo.Namespaces[3].Classes[1].Properties.Where(p => p.PropertyType == "String");

            Assert.AreEqual(3, countCorrectProperties.Count());
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectNameOfMethods()
        {
            var currMethodsPerson = _assemblyInfo.Namespaces[3].Classes[1].Methods;
            var countCorrectMethods = currMethodsPerson.Where(m => m.MethodName == "SendMessageByMail" || m.MethodName == "SendMessageByEmail");

            Assert.AreEqual(2, countCorrectMethods.Count());
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectReturnValueOfMethods()
        {
            var currMethodsPerson = _assemblyInfo.Namespaces[3].Classes[1].Methods;
            var methodSendMess = currMethodsPerson.Where(m => m.MethodName == "SendMessageByMail").First();
            var currMethodsHouse = _assemblyInfo.Namespaces[2].Classes[0].Methods;
            var methodGetHouseAge = currMethodsHouse.Where(m => m.MethodName == "GetHouseAge").First();

            Assert.AreEqual("Boolean", methodSendMess.ReturnType);
            Assert.AreEqual("Int32", methodGetHouseAge.ReturnType);
        }

        [Test]
        public void GetAssemblyInfo_AssemblyInfo_ReturnCorrectParametersOfMethods()
        {
            var countCorrectParams = _assemblyInfo.Namespaces[3].Classes[1].Methods.Where(m => m.MethodName == "SendMessageByMail").First().Parameters;

            Assert.AreEqual(1, countCorrectParams.Count());
            Assert.AreEqual("message", countCorrectParams.First().FieldName);
            Assert.AreEqual("String", countCorrectParams.First().FieldType);
        }
    }
}