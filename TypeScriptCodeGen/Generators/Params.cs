using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeScriptCodeGen.Generators
{
    partial class TypeScriptProxy
    {
        static Dictionary<string, string> TypeMappings = new Dictionary<string, string> 
            { 
                { "System.Int32", "number"}, 
                { "System.Int16", "number"}, 
                { "System.Decimal", "number"}, 
                { "System.String", "string"}, 
            };

        internal List<TypeScriptCodeGen.Analyzers.ClassData> Classes;
        internal List<TypeScriptCodeGen.Analyzers.ServiceData> Services;

        internal string GetTypeName(Type type)
        {
            if (TypeMappings.ContainsKey(type.FullName))
                return TypeMappings[type.FullName];

            if (type.GetInterface("ICollection") != null && type.IsGenericType)
                return GetTypeName(type.GetGenericArguments()[0]) + "[]";
            return type.Name;
        }

        internal string ParamsString(TypeScriptCodeGen.Analyzers.MethodData method)
        {
            var Params = new List<String>();
            if (method.Params != null)
                foreach (var param in method.Params)
                    Params.Add(String.Format("{0}: {1}", param.Name, GetTypeName(param.Type)));

            if (method.Returns != null)
                Params.Add(String.Format("callback: {{ (result: {0}): void; }}", GetTypeName(method.Returns.Type)));
            else
                Params.Add("callback: { (): void; }");

            return String.Format("({0})", string.Join(", ", Params));
        }

        internal string BodyParam(TypeScriptCodeGen.Analyzers.MethodData method)
        {
            TypeScriptCodeGen.Analyzers.ParamData Data = null;
            if (method.Params != null)
                Data = method.Params.FirstOrDefault(q => q.IsBody);
            if (Data == null)
                return "";

            if (Data.isSimple)
                return Data.Name;

            return Data.Name;
        }

        internal string MethodUrl(TypeScriptCodeGen.Analyzers.MethodData method)
        {
            var sbParams = new StringBuilder();
            var Separator = "?";
            foreach (var param in method.Params.Where(q => !q.IsBody))
            {
                sbParams.AppendFormat(" + '{0}{1}=' + {2}", Separator, param.Name, param.Name);
                Separator = "&";
            }
            return string.Format("'{0}'{1}", method.Name, sbParams);
        }


        internal string GetUniqueMethodName(TypeScriptCodeGen.Analyzers.ServiceData service, TypeScriptCodeGen.Analyzers.MethodData method)
        {
            if (!service.Methods.Any(q => q != method && q.Name == method.Name) || method.Params.Count == 0)
                return method.Name;

            var Result = new StringBuilder().Append(method.Name);
            foreach (var param in method.Params)
                Result.Append('_').Append(param.Name);

            return Result.ToString();
        }

        internal TypeScriptProxy(TypeScriptCodeGen.Analyzers.Analyzer analyzer)
        {
            Services = analyzer.Services;
            Classes = analyzer.Classes;
        }

    }
}
