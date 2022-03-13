using System;
using System.Reflection;
using System.Runtime.Loader;
using System.IO;

namespace SecurityDevelopment.Assemblies
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true) { }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }

        public static void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("Библиотека SecurityDevelopmentAddUser выгружена \n");
        }
    }

}
