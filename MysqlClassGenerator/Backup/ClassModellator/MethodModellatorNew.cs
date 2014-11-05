using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.ModifierManager;

namespace ClassModellator
{
    public class MethodModellatorNew
    {
        XmlDocumentationModellator _xmlDocumentationClass;

        public XmlDocumentationModellator XmlDocumentationClass
        {
            get { return _xmlDocumentationClass; }
            set { _xmlDocumentationClass = value; }
        }

        //private  String _body;
        //public String Body
        //{
        //    get { return _body; }
        //    set { _body = value; }
        //}

        Modifier _AccessModifier;
        public Modifier AccessModifier
        {
            get { return _AccessModifier; }
            set { _AccessModifier = value; }
        }


        Modifier _modifier;

        public Modifier Modifier
        {
            get { return _modifier; }
            set { _modifier = value; }
        }

        private  String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

       


        private  String _description;
        public  String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        List<VariableModellator> _listVariables;
        /// <summary>
        /// lista varivili passate a nella funzione
        /// </summary>
        public List<VariableModellator> ListVariables
        {
            get { return _listVariables; }
            set
            {
                _listVariables = value;
            }
        }


        private String _body;

        public String Body
        {
            get { return _body; }
            set { _body = value; }
        }

        String _returnType;

        public String ReturnType
        {
            get { return _returnType; }
            set { _returnType = value; }
        }



        public MethodModellatorNew()
        {
            _listVariables = new List<VariableModellator>();
            _xmlDocumentationClass = new XmlDocumentationModellator();
            AccessModifier = ListAccessModifiers.PUBLIC;
            _modifier = new Modifier();
            _name = "metthod";
            _body = String.Empty;
        }


        public MethodModellatorNew(String Name, String ReturnType)
            :this()
        {
            _name = Name;
            _returnType = ReturnType;
        }



         public String getXmlDocumentation()
        {
            _xmlDocumentationClass.setParamName(_listVariables);

            if (this.Description != null && this.Description.Trim().Length != 0)
            {
                _xmlDocumentationClass.Summary = this.Description.Replace("\n", Environment.NewLine + "/// ");
            }

            if (_returnType != null && _returnType.ToLower() != "void")
            {
                _xmlDocumentationClass.Returns = " return " + _returnType + " parameter";
            }

            return _xmlDocumentationClass.getXmlDocumentation().Replace("///","\t\t///");
        }

         protected  String MethodModellated()
         {
             StringBuilder sb = new StringBuilder();
             //sb.Append(this.getXmlDocumentation());
             //this.XmlDocumentationClass.Summary = "Function " + this._description;
             sb.Append(Environment.NewLine + _AccessModifier.Value + " " + _modifier.Value + " " + _returnType + " " + _name + "(");
             
             for(int i=0;i< _listVariables.Count;i++)
             {
                 VariableModellator var = _listVariables[i];
                 sb.Append(String.Format("{0} {1}", var.Type, var.Name));
                 if (i < _listVariables.Count - 1)
                 {
                     sb.Append(", ");
                 }
             }
             sb.Append(")");
             sb.Append(Environment.NewLine + "{");
             sb.Append(Environment.NewLine + "\t" + _body.Replace("\n", "\n\t\t"));
             sb.Append(Environment.NewLine + "}" + Environment.NewLine);
           
             return sb.ToString();
         }

         public override string ToString()
         {
             return this.MethodModellated();
         }
    }
}
