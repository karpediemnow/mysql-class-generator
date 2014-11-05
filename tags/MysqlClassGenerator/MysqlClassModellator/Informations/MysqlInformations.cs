using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Globalization;

using MySql.Data.MySqlClient;

namespace ClassModellator.MysqlClassModellator.Informations
{
    /// <summary>
    /// Classe che dovrebbe inglogare le funzioni che 
    /// restituiscono le informazioni del database
    /// </summary>
    public class MysqlInformations
    {
        private MySqlConnection _connessione;
        private String _connectionString;
        private MySqlCommand _command;
        private MySqlDataReader _reader;


        public MySqlConnection Connessione
        {
            get
            {
                //if (_connessione.State == ConnectionState.Closed)
                //    _connessione.Open();
                return _command.Connection; //_connessione;
            }
            set
            {
                _connessione = value;
                _command.Connection = _connessione;
            }
        }

        public String ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                _connessione.ConnectionString = _connectionString;
            }
        }

        public MysqlInformations()
        {
            _connessione = new MySqlConnection();
            _command = new MySqlCommand();
            _command.Connection = _connessione;
        }

        public MysqlInformations(String ConnectionString)
            : base()
        {
            _connectionString = ConnectionString;
            _connessione.ConnectionString = _connectionString;// = new MySqlConnection(_connectionString);
        }

        public MysqlInformations(MySqlConnection Connessione)
            : base()
        {
            _connessione = Connessione;
        }

        /// <summary>
        /// get the crete table String
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string getCreateTableString(String tableName)
        {
            string CT = "";

            //MySqlDataReader reader = null;

            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText = "SHOW CREATE TABLE " + tableName;
                _reader = _command.ExecuteReader();

                //String q = "SHOW CREATE TABLE " + tableName;
                //MySqlCommand cmd = new MySqlCommand(q, this.Connessione);
                //reader = cmd.ExecuteReader();

                if (_reader.Read())
                {
                    CT = _reader.GetString(1);
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return CT;
        }


        public List<String> getPrimaryKeyConstraints(String SCHEMA_NAME, String TABLE_NAME)
        {
            List<String> items = new List<string>();
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText =
                    "SELECT" +
                    " information_schema.KEY_COLUMN_USAGE.COLUMN_NAME," +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_NAME"+
                    " FROM"+
                    " information_schema.KEY_COLUMN_USAGE,"+
                    " information_schema.TABLE_CONSTRAINTS"+
                    " WHERE"+
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_NAME = information_schema.KEY_COLUMN_USAGE.CONSTRAINT_NAME"+
                    " AND"+
                    " information_schema.KEY_COLUMN_USAGE.CONSTRAINT_SCHEMA='"+SCHEMA_NAME+"'"+
                    " AND"+
                    " information_schema.KEY_COLUMN_USAGE.TABLE_NAME='" + TABLE_NAME + "'" +
                    " AND"+
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_TYPE='PRIMARY KEY'" +
                    " GROUP BY"+
                    " COLUMN_NAME"+
                    ";";
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    items.Add(_reader.GetString(_reader.GetOrdinal("COLUMN_NAME")));
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;
        }

        public List<String> getForeignConstraints(String SCHEMA_NAME, String TABLE_NAME)
        {
            List<String> items = new List<string>();
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText =
                    "SELECT" +
                    " information_schema.KEY_COLUMN_USAGE.COLUMN_NAME," +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_NAME" +
                    " FROM" +
                    " information_schema.KEY_COLUMN_USAGE," +
                    " information_schema.TABLE_CONSTRAINTS" +
                    " WHERE" +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_NAME = information_schema.KEY_COLUMN_USAGE.CONSTRAINT_NAME" +
                    " AND" +
                    " information_schema.KEY_COLUMN_USAGE.CONSTRAINT_SCHEMA='" + SCHEMA_NAME + "'" +
                    " AND" +
                    " information_schema.KEY_COLUMN_USAGE.TABLE_NAME='" + TABLE_NAME + "'" +
                    " AND" +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_TYPE='FOREIGN KEY'" +
                    " GROUP BY" +
                    " COLUMN_NAME" +
                    ";";
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    items.Add(_reader.GetString(_reader.GetOrdinal("COLUMN_NAME")));
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;
        }

        public List<String> getUniqueConstraints(String SCHEMA_NAME, String TABLE_NAME)
        {
            List<String> items = new List<string>();
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText =
                    "SELECT" +
                    " information_schema.KEY_COLUMN_USAGE.COLUMN_NAME," +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_NAME" +
                    " FROM" +
                    " information_schema.KEY_COLUMN_USAGE," +
                    " information_schema.TABLE_CONSTRAINTS" +
                    " WHERE" +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_NAME = information_schema.KEY_COLUMN_USAGE.CONSTRAINT_NAME" +
                    " AND" +
                    " information_schema.KEY_COLUMN_USAGE.CONSTRAINT_SCHEMA='" + SCHEMA_NAME + "'" +
                    " AND" +
                    " information_schema.KEY_COLUMN_USAGE.TABLE_NAME='" + TABLE_NAME + "'" +
                    " AND" +
                    " information_schema.TABLE_CONSTRAINTS.CONSTRAINT_TYPE='UNIQUE'" +
                    " GROUP BY" +
                    " COLUMN_NAME" +
                    ";";
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    items.Add(_reader.GetString(_reader.GetOrdinal("COLUMN_NAME")));
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;
        }

        /// <summary>
        /// Informazioni delle singole colonne del database
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<CoulomnInformations> getFullColumnsList(String tableName)
        {
            List<CoulomnInformations> items = new List<CoulomnInformations>();
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText = "SHOW FULL COLUMNS FROM " + tableName;
                _reader = _command.ExecuteReader();

                //MySqlCommand cmd = new MySqlCommand("SHOW FULL COLUMNS FROM " + tableName, this.Connessione);
                ////SHOW FULL COLUMNS FROM t1
                //MySqlDataReader reader = cmd.ExecuteReader();
                while (_reader.Read())
                {
                    items.Add(new CoulomnInformations(_reader));
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;

        }

        /// <summary>
        /// Lista delle tabelle
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public List<String> getListTable(String dataBaseName)
        {
            List<String> items = new List<string>();
            _connessione.ChangeDatabase(dataBaseName);
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText = "SHOW TABLES";
                _reader = _command.ExecuteReader();
                //MySqlCommand cmd = new MySqlCommand("SHOW TABLES", this.Connessione);
                //MySqlDataReader reader = cmd.ExecuteReader();

                while (_reader.Read())
                {
                    items.Add(_reader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;
        }

        /// <summary>
        /// Lista database
        /// </summary>
        /// <returns></returns>
        public List<String> getListDatabases()
        {
            List<String> items = new List<string>();
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            try
            {
                _command.CommandText = "SHOW DATABASES";
                _reader = _command.ExecuteReader();

                //MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", this.Connessione);
                //MySqlDataReader reader = cmd.ExecuteReader();
                while (_reader.Read())
                {
                    items.Add(_reader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }

            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return items;
        }

        /// <summary>
        /// Informazioni della tabelle tableName
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>list of table informations </returns>
        public TableInformations getTableInformations(String tableName)
        {
            TableInformations item = null;

            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");

            _command.CommandText = "SHOW TABLE status WHERE Name= '" + tableName + "'";
            _reader = _command.ExecuteReader();

            //MySqlCommand cmd = new MySqlCommand("SHOW TABLE status like '" + tableName + "'", this.Connessione);
            //MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (_reader.Read())
                {
                    item = new TableInformations(_reader);
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                _reader.Close();
                Thread.CurrentThread.CurrentCulture = info;
            }
            return item;
        }
    }
}