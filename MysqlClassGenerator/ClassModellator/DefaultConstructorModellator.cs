using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.ModifierManager;

namespace ClassModellator
{
    class DefaultConstructorModellator : CostructorModellator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        public DefaultConstructorModellator(String className)
            : base()
        {
            base.XmlDocumentationClass.Summary = "Default Constructor for class " + className;
            base.Modifiers = ListAccessModifiers.PUBLIC.Value;
            base.Name = className;
        }


        public override string ToString()
        {
            return this.getCodeModelleted();
        }

        public override string getCodeModelleted()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.getXmlDocumentation().Replace("\t\t", "\t"));
            sb.Append("\t" + base.Modifiers + " " + base.Name + "(");

            //VariableModellator v;
            //for (int i = 0; i < _listVariables.Count - 1; i++)
            //{
            //    v = _listVariables[i];
            //    sb.Append(v.Type + " " + v.Name + "_Param, ");
            //}
            //v = _listVariables[_listVariables.Count - 1];
            //sb.Append(v.Type + " " + v.Name + "_Param");
            sb.Append(")");

            sb.Append(Environment.NewLine + "\t{");

            sb.Append(Environment.NewLine + "\t\t");

            foreach (string loc in base.ListLineOfCode)
            {
                sb.Append(Environment.NewLine + "\t" + loc.Replace("\n", "\n\t"));
            }
            sb.Append(Environment.NewLine + "\t}");

            return sb.ToString();
        }
    }
}
