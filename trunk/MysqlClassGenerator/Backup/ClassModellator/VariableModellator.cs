using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator
{
    

    public class VariableModellator
    {
        String _type;

        public  virtual String Type
        {
            get { return _type; }
            set { _type = value; }
        }
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


        public VariableModellator()
        {

        }

        public VariableModellator(String Type, String Name)
        {
            _type = Type;
            _name = Name;
        }

        public VariableModellator(String Type_Param, String Name_Param, string Description_Param)
        {
            _type = Type_Param;
            _name = Name_Param;
            _description = Description_Param;
        }
    }
}
