using System;
namespace ClassModellator.Interface
{
    public interface IPropertyModellator
    {
        String Name { get; set; }
        bool CreateGET { get; set; }
        bool CreateSET { get; set; }
        bool IsNullable { get; set; }
        object Tag { get; set; }
        string Type { get; set; }

        string ToString();
        string getConstructorPropertyString();
        string getConstructorPropertyStringReader();

        String getProperty();
        String getEncapsulationFied();
        String getNoEncapsulateField();
    }
}
