using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.Using;

namespace ClassModellator
{
    public class ClassFileModellator
    {
        string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }


        List<UsingModellator> _listUsings;

        public List<UsingModellator> ListUsings
        {
            get { return _listUsings; }
            set { _listUsings = value; }
        }

        List<NameSpaceModellator> _listNamespaces;

        public List<NameSpaceModellator> ListNamespaces
        {
            get { return _listNamespaces; }
            set { _listNamespaces = value; }
        }

        public ClassFileModellator()
        {
            _listNamespaces = new List<NameSpaceModellator>();
            _listUsings = new List<UsingModellator>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (UsingModellator us in _listUsings)
            {
                sb.Append(us.ToString()+Environment.NewLine);
            }

            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);

            foreach (NameSpaceModellator ns in _listNamespaces)
            {
                sb.Append(ns.ToString() + Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
