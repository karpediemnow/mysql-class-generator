using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.ModifierManager;

namespace ClassModellator
{
    public class CostructorModellator
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

        String _modifiers;
        public String Modifiers
        {
            get { return _modifiers; }
            set { _modifiers = value; }
        }

        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }




        private String _description;
        public String Description
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



        public CostructorModellator()
        {
            _listVariables = new List<VariableModellator>();
            _xmlDocumentationClass = new XmlDocumentationModellator();

            Modifiers =ListAccessModifiers.PUBLIC.Value;
            _name = "costructor";
        }



        public String getXmlDocumentation()
        {
            _xmlDocumentationClass.setParamName(_listVariables);

            if (this.Description != null && this.Description.Trim().Length != 0)
            {
                _xmlDocumentationClass.Summary = this.Description.Replace("\n", Environment.NewLine + "/// ");
            }

            

            return _xmlDocumentationClass.getXmlDocumentation().Replace("///", "\t\t///");
        }

        public virtual String getCostructorModelleted()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.getXmlDocumentation());
            this.XmlDocumentationClass.Summary = "Function " + this._description;
            sb.Append("\t\t"+_modifiers+" " + this._name + "(");

            VariableModellator v;
            for (int i = 0; i < _listVariables.Count - 1; i++)
            {
                v = _listVariables[i];
                sb.Append(v.Type + " " + v.Name + "_Param, ");
            }
            v = _listVariables[_listVariables.Count - 1];
            sb.Append(v.Type + " " + v.Name + "_Param");
            sb.Append(")" + Environment.NewLine);

            sb.Append(Environment.NewLine + "\t\t{");
            sb.Append(Environment.NewLine + "\t\t" + _body.Replace("\n", "\n\t\t"));
            sb.Append(Environment.NewLine + "\t\t}");

            return sb.ToString();
        }

    }

}
