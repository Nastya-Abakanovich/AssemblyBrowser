using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.AssemblyComposition
{
    public class NamespaceInfo
    {
        public string NamespaceName { get; set; }
        public List<ClassInfo> Classes { get; set; }
    }
}
