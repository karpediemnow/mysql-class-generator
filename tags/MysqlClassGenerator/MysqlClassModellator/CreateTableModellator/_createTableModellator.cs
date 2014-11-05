using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator.MysqlClassModellator.CreateTableModellator
{
    /*
     't1', 'CREATE TABLE `t1` (
  `_VARCHAR` varchar(3) character set latin1 collate latin1_bin NOT NULL COMMENT 'stringa gaviabile',
  `_TINYNT` tinyint(4) unsigned zerofill default NULL COMMENT 'Intero corso',
  `_TEXT` text COMMENT 'testo',
  `_DATE` date default NULL COMMENT 'data',
  `_SMALLINT` smallint(6) unsigned zerofill default NULL COMMENT 'Intero',
  `_MEDIUMINT` mediumint(9) default NULL,
  `_INT` int(11) default NULL,
  `_BIGINT` bigint(20) default NULL,
  `_FLOAT` float default NULL,
  `_DOUBLE` double default NULL,
  `_DECIMAL` decimal(10,0) default NULL,
  `_DATETIME` datetime default NULL,
  `_TIMESTAMP` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `_TIME` time default NULL,
  `_YEAR` year(4) default NULL,
  `_CHAR` char(3) default NULL,
  `_TINYBLOB` tinyblob,
  `_TINYTEXT` tinytext,
  `_BLOB` blob,
  `_MEDIUMBLOB` mediumblob,
  `_MEDIUMTEXT` mediumtext,
  `_BOOLEAN` tinyint(1) default NULL,
  `_bit` bit(1) default NULL,
  `_LONGBLOB` longblob NOT NULL,
  `_longTest` longtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1'
     */
    class _createTableModellator
    {
        private string _name;

        /// <summary>
        /// Name of Class table Modellator
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //private String _createTableStatment;

        ///// <summary>
        ///// Get Or Set Create statment table
        ///// </summary>
        //public String CreateTableStatment
        //{
        //    get { return _createTableStatment; }
        //    set { _createTableStatment = value; }
        //}


        private String _summary;

        /// <summary>
        /// Optinal Property write the Summary class
        /// </summary>
        public String Summary
        {
            get
            {
                if (this._summary == null)
                {
                    string returnStr = "Modellation of a DataTableSchema ";
                    if (this._name != null)
                    {
                        returnStr += this._name;
                    }
                    return returnStr;
                }
                else
                    return _summary;

            }
            set { _summary = value; }
        }

        List<_createTableField> _listaField;

        internal List<_createTableField> ListaField
        {
            get { return _listaField; }
            set { _listaField = value; }
        }

        public _createTableModellator()
        {
            _listaField = new List<_createTableField>();
        }
    }
}
