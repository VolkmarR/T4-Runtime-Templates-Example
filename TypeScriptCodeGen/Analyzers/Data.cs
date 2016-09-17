using System;
using System.Collections.Generic;
using System.Reflection;

namespace TypeScriptCodeGen.Analyzers
{
    class ServiceData
    {
        public Type Controller { get; private set; }
        public String Name
        {
            get
            {
                if (Controller.Name.EndsWith("Controller", true, null))
                    return Controller.Name.Substring(0, Controller.Name.Length - 10);
                return Controller.Name;
            }
        }
        public List<MethodData> Methods;

        public override string ToString()
        {
            return Name;
        }

        public ServiceData(Type controllerType)
        {
            Controller = controllerType;
            Methods = new List<MethodData>();
        }
    }

    class MethodData
    {
        public enum HttpType { none, get, put, post, delete }
        public MethodInfo Method { get; private set; }
        public HttpType Type { get; private set; }
        public string Name { get { return Method.Name; } }
        public bool isGet { get { return Type == HttpType.get; } }
        public bool isPut { get { return Type == HttpType.put; } }
        public bool isPost { get { return Type == HttpType.post; } }
        public bool isDelete { get { return Type == HttpType.delete; } }

        public List<ParamData> Params;
        public ReturnData Returns = null;

        public MethodData(MethodInfo methodInfo, HttpType type)
        {
            Method = methodInfo;
            Type = type;
            Params = new List<ParamData>();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Enum.GetName(typeof(HttpType), Type));
        }
    }

    class ReturnData
    {
        public Type Type { get; private set; }
        public bool isSimple { get { return Type.Namespace.StartsWith("System"); } }
        public ReturnData(Type returnType)
        {
            Type = returnType;
        }

        public override string ToString()
        {
            return Type.Name;
        }
    }

    class ParamData : ReturnData
    {
        public String Name { get; private set; }
        public bool IsBody { get; private set; }
        public ParamData(string name, Type paramType, bool isBody)
            : base(paramType)
        {
            Name = name;
            IsBody = isBody;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Type.Name);
        }
    }

    class ClassData
    {
        public String BaseTypeName { get; private set; }
        public Type Type { get; private set; }
        public List<PropertyData> Properties { get; private set; }

        public ClassData(Type type, String baseTypeName)
        {
            Type = type;
            BaseTypeName = baseTypeName;
            Properties = new List<PropertyData>();
        }

        public string Name { get { return Type.Name; } }

        public override string ToString()
        {
            return Type.Name;
        }
    }

    class PropertyData
    {
        public Type Type { get; private set; }
        public string Name { get; private set; }

        public PropertyData(string name, Type type)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
