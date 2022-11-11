using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class MethodInfo
    {
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public List<FieldInfo> Parameters { get; set; }
    }
}
