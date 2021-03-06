﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace TypeScriptCodeGen.Generators
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class TypeScriptProxy : TypeScriptProxyBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("declare var $;\r\n\r\nmodule ClientProxy {\r\n\r\n");
            
            #line 11 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 if (Classes.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t// Classes\r\n");
            
            #line 13 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
   foreach(var Class in Classes) { 
            
            #line default
            #line hidden
            this.Write("\texport class ");
            
            #line 14 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Class.Name));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 14 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 if (!String.IsNullOrEmpty(Class.BaseTypeName)) { 
            
            #line default
            #line hidden
            this.Write(" extends ");
            
            #line 14 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Class.BaseTypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 14 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 15 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
   foreach(var prop in Class.Properties) { 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 16 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop.Name));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 16 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(prop.Type)));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 17 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t}\r\n\r\n");
            
            #line 20 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } } 
            
            #line default
            #line hidden
            
            #line 21 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 if (Services.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t// Controllers\r\n");
            
            #line 23 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 foreach(var service in Services) 
	if (service.Methods.Count > 0)
	{ 
            
            #line default
            #line hidden
            this.Write("\texport class ");
            
            #line 26 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(service.Name));
            
            #line default
            #line hidden
            this.Write("Proxy {\r\n\t\tbaseUrl: String;\r\n\r\n\t\tconstructor(serviceBaseUrl: string) {\r\n\t\t\tthis.b" +
                    "aseUrl = serviceBaseUrl;\r\n\t\t}\r\n\r\n");
            
            #line 33 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 var getMethods = service.Methods.Where(q => q.isGet).ToList();
   if (getMethods.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\t// Get Controller Methods\r\n");
            
            #line 36 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 foreach(var method in getMethods) { 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 37 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetUniqueMethodName(service, method)));
            
            #line default
            #line hidden
            
            #line 37 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ParamsString(method)));
            
            #line default
            #line hidden
            this.Write(" {\r\n\t\t\tvar methodUrl = this.baseUrl + ");
            
            #line 38 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MethodUrl(method)));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t$.getJSON(methodUrl, res => { callback(");
            
            #line 39 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 if (method.Returns != null) { 
            
            #line default
            #line hidden
            this.Write("res");
            
            #line 39 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            this.Write("); } );\r\n\t\t}\r\n");
            
            #line 41 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
} 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 43 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            
            #line 44 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 var methods = new List<Tuple<string, List<TypeScriptCodeGen.Analyzers.MethodData>>> {
						new Tuple<string, List<TypeScriptCodeGen.Analyzers.MethodData>>("POST", service.Methods.Where(q => q.isPost).ToList()), 
						new Tuple<string, List<TypeScriptCodeGen.Analyzers.MethodData>>("PUT", service.Methods.Where(q => q.isPut).ToList()), 
						new Tuple<string, List<TypeScriptCodeGen.Analyzers.MethodData>>("DELETE", service.Methods.Where(q => q.isDelete).ToList()) 
					};
   foreach(var data in methods) 
   {
	   if (data.Item2.Count == 0) 
		   continue;

            
            #line default
            #line hidden
            this.Write("\t\t// ");
            
            #line 54 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(data.Item1));
            
            #line default
            #line hidden
            this.Write(" Controller Methods\r\n");
            
            #line 55 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 foreach(var method in data.Item2) { 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 56 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetUniqueMethodName(service, method)));
            
            #line default
            #line hidden
            
            #line 56 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ParamsString(method)));
            
            #line default
            #line hidden
            this.Write(" {\r\n\t\t\tvar methodUrl = this.baseUrl + ");
            
            #line 57 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MethodUrl(method)));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t$.ajax({type: \"");
            
            #line 58 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(data.Item1));
            
            #line default
            #line hidden
            this.Write("\", \r\n\t\t\t        url: methodUrl,\r\n");
            
            #line 60 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 if (!string.IsNullOrEmpty(BodyParam(method))) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t        contentType: \"application/json; charset=utf-8\", \r\n\t\t\t        dataType:" +
                    " \"json\",\r\n\t\t\t        data: JSON.stringify(");
            
            #line 63 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BodyParam(method)));
            
            #line default
            #line hidden
            this.Write("), \r\n");
            
            #line 64 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t        success: res => { callback(");
            
            #line 65 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 if (method.Returns != null) { 
            
            #line default
            #line hidden
            this.Write(" res ");
            
            #line 65 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            this.Write("); }\r\n\t\t\t       });\r\n\t\t}\r\n");
            
            #line 68 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
} 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 70 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t}\r\n\r\n");
            
            #line 74 "D:\TeamW\CSharp2\Windows\Projekte\T4Examples\TSCodeGen\Generators\TypeScriptProxy.tt"
 } } 
            
            #line default
            #line hidden
            this.Write("}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class TypeScriptProxyBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
