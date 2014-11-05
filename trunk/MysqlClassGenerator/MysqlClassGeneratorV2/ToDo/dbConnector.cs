using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using Trapanarella.Properties;

using MySql.Data.MySqlClient;

namespace Trapanarella
{
    class dbConnector
    {

        private static MySqlConnection _conn;

        /// <summary>
        /// Set or Get la connessione al database nel get se la connessione non è aperta viene aperta
        /// </summary>
        public static MySqlConnection Connessione
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new MySqlConnection(getConnectionString());
                }

                _conn.Open();

                return _conn;
            }
            set
            {
                _conn = value;
            }
        }


        public static string getConnectionString()
        {
            return String.Format("server={0};user id={1}; password={2}; database=mysql; pooling=false", Settings.Default.server, Settings.Default.userid, Settings.Default.password);
               
            //string server = "";
            //string db = "";
            //string usernameServer = "";
            //string passwordServer = "";
            //try
            //{
            //     using (System.IO.StreamReader sr = System.IO.File.OpenText("config.txt"))
            //    {
            //        string line = sr.ReadLine();
            //        while(line!=null)
            //        {
            //            if (line.Substring(0, 1) == "#")
            //            {
            //                line = sr.ReadLine();
            //                continue;
            //            }
            //            else
            //            {
            //                server = line;
            //                db = sr.ReadLine();
            //                usernameServer = sr.ReadLine();
            //                passwordServer = sr.ReadLine();
            //                break;
            //            }
            //        }
            //        MySqlConnection strCon = new MySqlConnection(server, db, usernameServer, passwordServer);
            //        return strCon.ToString();
            //    }
            //}
            //catch (System.IO.FileNotFoundException)
            //{
            //    throw new System.IO.FileNotFoundException();
            //}
        }
    
    }
}
