using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator
{
    public class CodeModellator : ClassModellator.Interface.ICodeModellator
    {
        List<String> _listLineOfCode;

        public List<String> ListLineOfCode
        {
            get { return _listLineOfCode; }
            set { _listLineOfCode = value; }
        }


        public void AddLine(String lineOfCode)
        {
            _listLineOfCode.Add(Environment.NewLine + lineOfCode);
        }
 
        public CodeModellator()
        {
            _listLineOfCode = new List<string>();
        }

        public CodeModellator(List<String> ListLineOfCode)
        {
            _listLineOfCode = ListLineOfCode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string line in _listLineOfCode)
            {
                sb.Append(Environment.NewLine + line);
            }

            return sb.ToString();
        }

        
    }
}
