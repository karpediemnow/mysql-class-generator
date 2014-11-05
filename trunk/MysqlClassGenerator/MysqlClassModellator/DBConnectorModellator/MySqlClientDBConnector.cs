using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.MysqlClassModellator.Interface;
using ClassModellator.ModifierManager;

namespace ClassModellator.MysqlClassModellator.DBConnectorModellator
{
    public class MySqlClientDBConnector : ClassModellatorOld, IDBConnector
    {

        public MySqlClientDBConnector()
        {
            this.Description = "This class is used to retrive the connection or connection string.\n";
            this.Description += "Insert into your setting project:\n ";
            this.Description += "Settings.Default.server\n";
            this.Description += "Settings.Default.userid\n";
            this.Description += "Settings.Default.password\n";
            this.Name = "MySqlClientDBConnector";
            this.NameSpace = "DataLayer";
            this.ListMethods.Add(getConnectionStringFunction());
            this.ListProperties.Add(PropConnessione());
        }


        public PropertyModellator PropConnessione()
        {
            PropertyModellator p = new PropertyModellator();
            p.CreateGET = true;
            p.CreateSET = true;
            p.Description = "Set or Get the connection";// la connessione al database nel get se la connessione non è aperta viene aperta";
            p.Modifier = ListModifiers.STATIC.Value;
            p.Type = "MySqlConnection";
            p.Name = "connection";
            return p;
        }

        public functionModellator getConnectionStringFunction()
        {
            functionModellator func = new functionModellator();
            func.Modifier = ListModifiers.STATIC.Value;
            func.Description = "Retrive the connection String.";
            func.Name = "getConnectionString";
            func.Type = "string";
            func.Body = "return String.Format(\"server={0};user id={1}; password={2}; database=mysql; pooling=false\", Settings.Default.server, Settings.Default.userid, Settings.Default.password);";
            return func;
        }

    }
}
