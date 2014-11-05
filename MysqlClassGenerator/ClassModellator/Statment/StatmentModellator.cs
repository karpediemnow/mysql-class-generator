using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.Interface;

namespace ClassModellator.Statment
{
    public class StatmentModellator : CodeModellator
    {
        String _name;

        public StatmentModellator()
        {
            _name = String.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine+ _name);
            sb.Append(Environment.NewLine + "{");
            foreach (String tmpSTR in base.ListLineOfCode)
            {
                sb.Append(tmpSTR);
            }

            sb.Append(Environment.NewLine + "}");

            return base.ToString();
        }
    }


}
