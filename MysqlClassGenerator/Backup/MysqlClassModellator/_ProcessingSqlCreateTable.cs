using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;


namespace ClassModellator.CreateTableModellator
{
    public class ProcessingSqlCreateTable
    {
        public ProcessingSqlCreateTable() { 
        
        }

        public void createClass(String XmlPath,String OutputClassName)
        {
            ClassModellatorOld classTable = new ClassModellatorOld();
            classTable.Name = OutputClassName;// this.tables.SelectedItem.ToString();

            //<BaseSchemaName>test</BaseSchemaName> nome database
            //<BaseTableName>t1</BaseTableName>     nome tabella
    
            XmlTextReader reader = new XmlTextReader(XmlPath);
            String Name = "";
            String Type = "";

            bool isColumnName = false;
            bool isDataType = false;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "ColumnName")
                        {
                            isColumnName = true;
                        }
                        else if (reader.Name == "DataType")
                        {
                            isDataType = true;
                        }
                        //DataType
                        break;

                    case XmlNodeType.Text:
                        if (isColumnName)
                        {
                            Name = reader.Value;
                            isColumnName = false;
                        }
                        else if (isDataType)
                        {
                            Type = reader.Value;
                            String[] vetStr = Type.Split(',');
                            classTable.addProperty(Name, vetStr[0]);
                            isColumnName = false;
                            isDataType = false;
                            Name = "";
                            Type = "";
                        }
                        //tmp=reader.Value;
                        break;

                    case XmlNodeType.EndElement:
                        //tmp = reader.Name;

                        break;

                }
            }
            //classTable.writeClass();
            //System.Diagnostics.Process.Start(classTable.PathToSave + classTable.FileName);

        }
	

    }
}
