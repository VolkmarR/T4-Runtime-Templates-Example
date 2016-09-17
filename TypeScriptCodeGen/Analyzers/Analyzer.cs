using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TypeScriptCodeGen.Analyzers
{
    class Analyzer
    {
        string AssemblyFileName;
        Assembly Assembly;

        public string ParseError = "";
        public List<TypeScriptCodeGen.Analyzers.ServiceData> Services = new List<TypeScriptCodeGen.Analyzers.ServiceData>();
        public List<TypeScriptCodeGen.Analyzers.ClassData> Classes = new List<TypeScriptCodeGen.Analyzers.ClassData>();

        public Analyzer(string assemblyFileName)
        {
            AssemblyFileName = assemblyFileName;
        }

        public bool Execute()
        {
            ParseError = "";

            try
            {
                Assembly = TypeScriptCodeGen.Analyzers.AssemblyLoader.LoadAssembly(AssemblyFileName);
            }
            catch (Exception ex)
            {
                ParseError = ex.Message;
                return false;
            }

            return ExtractData();
        }


        private bool isController(Type type)
        {
            return type.Name.ToLower().EndsWith("controller");
        }

        private TypeScriptCodeGen.Analyzers.MethodData.HttpType GetMethodType(MethodInfo methodInfo)
        {
            if (methodInfo.DeclaringType.Name == "ApiController" || methodInfo.DeclaringType.Name == "Object")
                return TypeScriptCodeGen.Analyzers.MethodData.HttpType.none;

            if (methodInfo.Name.StartsWith("Get"))
                return TypeScriptCodeGen.Analyzers.MethodData.HttpType.get;
            if (methodInfo.Name.StartsWith("Post"))
                return TypeScriptCodeGen.Analyzers.MethodData.HttpType.post;
            if (methodInfo.Name.StartsWith("Put"))
                return TypeScriptCodeGen.Analyzers.MethodData.HttpType.put;
            if (methodInfo.Name.StartsWith("Delete"))
                return TypeScriptCodeGen.Analyzers.MethodData.HttpType.delete;

            foreach (Attribute attribute in methodInfo.GetCustomAttributes(true).Where(q => q is Attribute))
            {
                var attrName = attribute.GetType().Name;
                if (attrName.Equals("HttpGetAttribute"))
                    return TypeScriptCodeGen.Analyzers.MethodData.HttpType.get;
                if (attrName.Equals("HttpPostAttribute"))
                    return TypeScriptCodeGen.Analyzers.MethodData.HttpType.post;
                if (attrName.Equals("HttpPutAttribute"))
                    return TypeScriptCodeGen.Analyzers.MethodData.HttpType.put;
                if (attrName.Equals("HttpDeleteAttribute"))
                    return TypeScriptCodeGen.Analyzers.MethodData.HttpType.delete;
            }

            return TypeScriptCodeGen.Analyzers.MethodData.HttpType.none;
        }

        private bool isBaseType(Type classType)
        {
            return classType == null || classType.Namespace.StartsWith("System.") || classType.Namespace.Equals("System");
        }

        private void ExtractClass(Type classType)
        {
            if (isBaseType(classType))
                return;

            if (classType.IsGenericType)
                foreach (Type item in classType.GetGenericArguments())
                    ExtractClass(item);

            var baseTypeName = "";
            if (!isBaseType(classType.BaseType))
            {
                baseTypeName = classType.BaseType.Name;
                ExtractClass(classType.BaseType);
            }

            if (Classes.Any(q => q.Type == classType))
                return;

            var Class = new TypeScriptCodeGen.Analyzers.ClassData(classType, baseTypeName);
            foreach (var prop in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                ExtractClass(prop.PropertyType);
                Class.Properties.Add(new TypeScriptCodeGen.Analyzers.PropertyData(prop.Name, prop.PropertyType));
            }

            Classes.Add(Class);
        }

        private TypeScriptCodeGen.Analyzers.ParamData ExtractParam(ParameterInfo param)
        {
            ExtractClass(param.ParameterType);
            var isBody = !param.ParameterType.Namespace.StartsWith("System") || param.GetCustomAttributes(true).Any(q => ((Attribute)q).ToString().EndsWith(".FromBodyAttribute"));
            return new TypeScriptCodeGen.Analyzers.ParamData(param.Name, param.ParameterType, isBody);
        }

        private TypeScriptCodeGen.Analyzers.MethodData ExtractMethod(MethodInfo method)
        {
            var mType = GetMethodType(method);
            if (mType == TypeScriptCodeGen.Analyzers.MethodData.HttpType.none)
                return null;

            var result = new TypeScriptCodeGen.Analyzers.MethodData(method, mType);
            if (method.ReturnType != null && method.ReturnType != typeof(void))
            {
                result.Returns = new TypeScriptCodeGen.Analyzers.ReturnData(method.ReturnType);
                ExtractClass(method.ReturnType);
            }

            foreach (var param in method.GetParameters())
                result.Params.Add(ExtractParam(param));

            return result;
        }

        private TypeScriptCodeGen.Analyzers.ServiceData ExtractService(Type controller)
        {
            var result = new TypeScriptCodeGen.Analyzers.ServiceData(controller);
            foreach (var method in controller.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                var methodData = ExtractMethod(method);
                if (methodData != null)
                    result.Methods.Add(methodData);
            }
            return result;
        }

        private bool ExtractData()
        {
            Services.Clear();
            Classes.Clear();
            foreach (var controller in Assembly.GetTypes().Where(q => isController(q)))
                Services.Add(ExtractService(controller));

            return true;
        }

    }
}
