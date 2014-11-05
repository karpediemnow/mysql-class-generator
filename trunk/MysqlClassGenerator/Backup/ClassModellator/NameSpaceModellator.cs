using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.Static;


namespace ClassModellator
{
    public class NameSpaceModellator
    {
        String _nameSpaceName;

        public String NameSpaceName
        {
            get { return _nameSpaceName; }
            set { _nameSpaceName = value; }
        }

        List<ClassModellatorNew> _listClasses;

        public List<ClassModellatorNew> ListClasses
        {
            get { return _listClasses; }
            set { _listClasses = value; }
        }

        List<StaticClassModellator> _listStaticClasses;

        public List<StaticClassModellator> ListStaticClasses
        {
            get { return _listStaticClasses; }
            set { _listStaticClasses = value; }
        }

       


        public NameSpaceModellator()
        {
            _listClasses = new List<ClassModellatorNew>();
            _listStaticClasses = new List<StaticClassModellator>();

        }

        public NameSpaceModellator(String NameSpaceName)
            : this()
        {
            _nameSpaceName = NameSpaceName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_nameSpaceName.Length > 0)
            {
                sb.Append(String.Format("namespace {0}", _nameSpaceName));
                sb.Append(Environment.NewLine);
                sb.Append("{");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t#region Classes");
                foreach (ClassModellatorNew cm in _listClasses)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(cm.ToString().Replace(Environment.NewLine, Environment.NewLine + "\t") + Environment.NewLine);
                
                }
                sb.Append(Environment.NewLine + "\t#endregion");
                
                sb.Append(Environment.NewLine);

                sb.Append(Environment.NewLine + "\t#region Static Classes");
                sb.Append(Environment.NewLine);
                
                foreach (StaticClassModellator scm in _listStaticClasses)
                {
                    //da implementare
                    sb.Append(Environment.NewLine);
                    sb.Append(scm.ToString().Replace(Environment.NewLine, Environment.NewLine + "\t") + Environment.NewLine);
                }
                sb.Append(Environment.NewLine + "\t#endregion");

                sb.Append(Environment.NewLine + "}");
            }
            else
            {
                throw new ArgumentException("The name of namespace is empty");
            }
            return sb.ToString();
        }
    }
}
