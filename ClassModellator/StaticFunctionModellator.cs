using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator
{
    public class functionModellator
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

        String _AccessModifier;
        public String AccessModifier
        {
            get { return _AccessModifier; }
            set { _AccessModifier = value; }
        }


        String _modifier;

        public String Modifier
        {
            get { return _modifier; }
            set { _modifier = value; }
        }


        String _type;
        public String Type
        {
            get { return _type; }
            set { _type = value; }
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

        List<Variables> _listVariables;
        /// <summary>
        /// lista varivili passate a nella funzione
        /// </summary>
        public List<Variables> ListVariables
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



        public functionModellator()
        {
            _listVariables = new List<Variables>();
            _xmlDocumentationClass = new XmlDocumentationModellator();
            AccessModifier = ListAccessModifiers.PUBLIC.Value;
            _modifier = null;
            _name = "function";
        }



         public String getXmlDocumentation()
        {
            _xmlDocumentationClass.setParamName(_listVariables);

            if (this.Description != null && this.Description.Trim().Length != 0)
            {
                _xmlDocumentationClass.Summary = this.Description.Replace("\n", Environment.NewLine + "/// ");
            }

            if (_type!=null && _type.ToLower() != "void")
            {
                _xmlDocumentationClass.Returns = " return " + _type + " parameter";
            }

            return _xmlDocumentationClass.getXmlDocumentation().Replace("///","\t\t///");
        }

         public virtual String functionModellatorString()
         {
             StringBuilder sb = new StringBuilder();
             sb.Append(this.getXmlDocumentation());
             this.XmlDocumentationClass.Summary = "Function " + this._description;
             sb.Append("\t\t" + _AccessModifier + " " + _modifier + " " + _type + " " + _name + "()");
             sb.Append(Environment.NewLine + "\t\t{");
             sb.Append(Environment.NewLine + "\t\t\t" + _body.Replace("\n", "\n\t\t\t"));
             sb.Append(Environment.NewLine + "\t\t}" + Environment.NewLine);
           
             return sb.ToString();
         }

    }
}
