using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator.MysqlClassModellator.CreateTableModellator
{
    class _createTableField
    {
        //`imgValuta` mediumblob COMMENT 'Immagine della valuta',

        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //poterbbe essere ance un enum 
        //oppure anchor meglio un valoere di una classe
        //statica in modo che posso fare immediatamente la
        //conversione da mysqlType A C# type!!
        private String _MysqlType;

        public String MysqlType
        {
            get { return _MysqlType; }
            set { _MysqlType = value; }
        }

        private Boolean _isNotNull;

        public Boolean IsNotNull
        {
            get { return _isNotNull; }
            set { _isNotNull = value; }
        }

        private Boolean _isAutoIncrement;

        public Boolean IsAutoIncrement
        {
            get { return _isAutoIncrement; }
            set { _isAutoIncrement = value; }
        }

        private String _defaultValue;

        public String DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        //può essere anche un enum!
        private String[] _listaFlag;

        public String[] ListaFlag
        {
            get { return _listaFlag; }
            set { _listaFlag = value; }
        }


        private String _comment;

        public String Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

    }
}
