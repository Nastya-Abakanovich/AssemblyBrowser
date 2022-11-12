using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyBrowserLibrary.AssemblyComposition;
using AssemblyBrowserLibrary;

namespace AssemblyBrowserApplication.Model
{
    public static class Core
    {
        public static AssemblyInfo GetTree(string filename)
        {
            AssemblyBrowser assemblyBrowser = new AssemblyBrowser(filename);
            return assemblyBrowser.GetAssemblyInfo();
        }
    }
}
