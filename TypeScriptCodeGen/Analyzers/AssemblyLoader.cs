using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TypeScriptCodeGen.Analyzers
{
    static class AssemblyLoader
    {
        static Dictionary<string, Assembly> Dependencies = new Dictionary<string, Assembly>();
        static Dictionary<string, string> DependenciesDllNames = new Dictionary<string, string>();

        static AssemblyLoader()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                var domain = (AppDomain)sender;

                foreach (var assembly in domain.GetAssemblies())
                {
                    if (assembly.FullName == args.Name)
                        return assembly;
                }

                if (Dependencies.ContainsKey(args.Name))
                    return Dependencies[args.Name];

                if (DependenciesDllNames.ContainsKey(args.Name))
                {
                    var assembly = Assembly.LoadFile(DependenciesDllNames[args.Name]);
                    Dependencies[args.Name] = assembly;
                    return assembly;
                }

                return null;
            };
        }

        public static Assembly LoadAssembly(string assemblyFileName)
        {

            foreach (var dll in Directory.GetFiles(Path.GetDirectoryName(assemblyFileName), "*.dll"))
                if (string.Compare(dll, assemblyFileName, false) != 0)
                {
                    var an = AssemblyName.GetAssemblyName(dll);
                    if (!DependenciesDllNames.ContainsKey(an.FullName))
                        DependenciesDllNames[an.FullName] = dll;

                }

            return Assembly.LoadFile(assemblyFileName);
        }
    }
}
