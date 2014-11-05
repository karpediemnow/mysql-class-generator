using System;
using System.Collections.Generic;
namespace ClassModellator.Interface
{
    interface ICodeModellator
    {
        List<String> ListLineOfCode { get; set; }
        string ToString();
    }
}
