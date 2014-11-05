using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MySql.Data.MySqlClient;

namespace Trapanarella
{
    class SqlManager
    {
        public MySqlConnection Connessione
        {

            get { return dbConnector.Connessione; }
        }


        public SqlManager()
        {

        }

        public int addsensors() { 
        
            return 0;

        }



        public int createJob(String JobNumber)
        {

            return 0;
        }


    }
}
