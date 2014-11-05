using System;
namespace ClassModellator.Interface
{
    public interface IPropertyModellator
    {
        bool CreateGET { get; set; }
        bool CreateSET { get; set; }
        bool IsNullable { get; set; }
        object Tag { get; set; }
        string Type { get; set; }

        string getProperty();
        string ToString();
        string getConstructorPropertyString();
        string getConstructorPropertyStringReader();
    }
}
