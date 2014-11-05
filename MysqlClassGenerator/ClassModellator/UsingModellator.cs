using System;
using System.Collections.Generic;
using System.Text;


namespace ClassModellator.Using
{
    public class UsingModellator 
    {
        String _name;

        public virtual String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public UsingModellator()
        {

        }

        public UsingModellator(String Name)
        {
            _name = Name;
        }

        public UsingModellator(String Name, String Description)
            : this(Name)
        {
            _description = Description;
        }

        public override string ToString()
        {
            return String.Format("using {0};", this.Name);
        }
    }
}
