﻿using System;
using System.Collections.Generic;
using System.Text;

using ClassModellator.Interface;

namespace ClassModellator.Statment
{
    /// <summary>
    /// <code>
    ///     get
    ///     {
    ///         [Dody]
    ///     }
    /// </code>
    /// </summary>
    public class getStatmentModellator : CodeModellator
    {
        private CodeModellator _statment;

        CodeModellator _body;

        public CodeModellator Body
        {
            get { return _body; }
            set { _body = value; }
        }


        public getStatmentModellator()
        {
            _statment = new CodeModellator();

            _statment.AddLine("get");
            _statment.AddLine("{");
            _statment.AddLine("[DODY]");
            _statment.AddLine("}");

            _body = new CodeModellator();

        }

        public override string ToString()
        {
            String tmpGet = _statment.ToString();

            return tmpGet.Replace("[DODY]", _body.ToString());
        }
    }
}
