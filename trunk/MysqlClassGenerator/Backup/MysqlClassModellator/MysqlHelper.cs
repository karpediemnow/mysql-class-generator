using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;

namespace ClassModellator.MysqlClassModellator
{
    public static class MysqlTypeMapping
    {
        public static string getCsharpType(String MysqlType)
        {
            //Da migliorare
            MysqlType = MysqlType.Trim();

            
            
            //MysqlType = MysqlType.Replace(" ", "");
            char[] delimiterChars = { '(', ')', ' ' };

            String[] tmp = MysqlType.Split(delimiterChars);
            double length = 0;

            if (tmp.Length > 1)
            {
                    // attenzione testire il tipo decimal   
                    // es "MysqlType = "decimal(12,2)" vuol dire 12 cifre con 2 decimali
                double.TryParse(tmp[1], out length);

            }
            
            
            
            switch (tmp[0])
            {
                case "tinyint":

                    if (length == 1)
                    {
                        tmp[0] = "BOOLEAN";
                        if (tmp.Length > 3)
                        {
                            if (tmp[3].ToLower() == "unsigned")
                            {
                                tmp[0] = "TINYINT_BYTE";
                            }
                            else
                                throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");

                        }
                        else
                        {
                            //tmp[0] = "TINYINT";
                            tmp[0] = "BOOLEAN";
                        }
                        ////if (tmp[3].ToLower() == "signed")
                        ////{
                        ////    tmp[0] = "TINYINT";
                        ////}
                        ////else if (tmp[3].ToLower() == "unsigned")
                        ////{
                        ////    tmp[0] = "TINYINT_BYTE";
                        ////}
                        ////else
                        ////    throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
                    }
                    else if (length == 2)
                    {
                        if (tmp.Length > 3)
                        {
                            if (tmp[3].ToLower() == "unsigned")
                            {
                                tmp[0] = "TINYINT_BYTE";
                            }
                            else
                                throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");

                        }
                        else
                        {
                            tmp[0] = "SMALLINT";
                        }
                        //if (tmp[3].ToLower() == "signed")
                        //{
                        //    tmp[0] = "SMALLINT";
                        //}
                        //else if (tmp[3].ToLower() == "unsigned")
                        //{
                        //    tmp[0] = "TINYINT_UINT16";
                        //}
                        //else
                        //    throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
                    }
                    else if (length == 3 || length == 4)
                    {
                        if (tmp.Length > 3)
                        {
                            if (tmp[3].ToLower() == "unsigned")
                            {
                                tmp[0] = "TINYINT_UINT32";
                            }
                            else
                                throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");

                        }
                        else
                        {
                            tmp[0] = "MEDIUMINT";
                        }
                     }
                    else if (length >4)
                    {
                         if (tmp.Length > 3)
                        {
                            if (tmp[3].ToLower() == "unsigned")
                            {
                                tmp[0] = "TINYINT_UINT64";
                            }
                            else
                                throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
                    
                        }
                        else
                        {
                            tmp[0] = "BIGINT";
                        }
                        
                        //if (tmp[3].ToLower() == "signed")
                        //{
                        //    tmp[0] = "MEDIUMINT";
                        //}
                        //else if (tmp[3].ToLower() == "unsigned")
                        //{
                        //    tmp[0] = "TINYINT_UINT32";
                        //}
                        //else
                        //    throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
                    }
                    else
                    {
                        tmp[0] = "TINYINT_UINT32";
                    }
                    break;

                case "int":
                    if (length == 10)
                    {
                        if (tmp[3].ToLower() == "unsigned")
                        {
                            tmp[0] = "TINYINT_UINT32";
                        }
                        else
                            throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
                    
                    }
                    else if (length > 10)
                    {
                        if (tmp.Length == 3)
                        {
                            tmp[0] = "BIGINT";
                        }
                        else if (tmp[3].ToLower() == "unsigned")
                        {
                        tmp[0] = "TINYINT_UINT64";
                        }
                        else
                            throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
                    
                    }
                    break;
            }
            

            if (MysqlToCsharp.Contains(tmp[0].ToUpper()))
            {
                return (string)MysqlToCsharp[tmp[0].ToUpper()];
            }
            else
            {
                throw new ArgumentException("Unknown Parameter Type (" + MysqlType + ")", "MysqlType");
            }
        }

        


        /*public static string getMysqlType(String CsharpType)
        {
            if (CsharpToMysql.Contains(CsharpType))
            {
                return (string)CsharpToMysql[CsharpType];
            }
            else
            {
                throw new ArgumentException("Unknown Parameter Type", "CsharpType");
            }
        }
        
        private static Hashtable CsharpToMysql;
        
        */
        private static Hashtable MysqlToCsharp;

        /// <summary>
        /// Static contructor
        /// contain all type definition
        /// </summary>
        static MysqlTypeMapping()
        {

            MysqlToCsharp = new Hashtable();

            #region load MysqlToCsharp hashtable

            //VARCHAR(length) [CHARACTER SET charset_name] [COLLATE collation_name] 
            // A variable-length string. Note: Trailing spaces are removed when the value is stored (this differs from the ANSI SQL specification) 
            // The range of Length is 1 to 255 characters. VARCHAR values are sorted and compared in case-insensitive fashion unless the BINARY keyword is given 
            MysqlToCsharp.Add("VARCHAR", "String");
            
            //TINYINT[(length)] [UNSIGNED] [ZEROFILL]
            //A very small integer 
            //The signed range is –128 to 127. The unsigned range is 0 to 255. 
            MysqlToCsharp.Add("TINYINT", "SByte");


            MysqlToCsharp.Add("TINYINT_BYTE", "Byte");

            MysqlToCsharp.Add("TINYINT_UINT16", "UInt16");

            MysqlToCsharp.Add("TINYINT_UINT32", "UInt32");

            MysqlToCsharp.Add("TINYINT_UINT64", "UInt64");
           
            //DATE 
            // A date 
            // The supported range is ‘1000-01-01’ to ‘9999-12-31’. MySQL displays DATE values in ‘YYYY-MM-DD’ format 
            MysqlToCsharp.Add("DATE", "DateTime");

            //SMALLINT[(length)] [UNSIGNED] [ZEROFILL] 
            // A small integer 
            // The signed range is –32768 to 32767. The unsigned range is 0 to 65535 
            MysqlToCsharp.Add("SMALLINT", "Int16");

            //MEDIUMINT[(length)] [UNSIGNED] [ZEROFILL] 
            // A medium-size integer 
            // The signed range is –8388608 to 8388607. The unsigned range is 0 to 16777215 
            MysqlToCsharp.Add("MEDIUMINT", "Int32");

            //INT[(length)] [UNSIGNED] [ZEROFILL]
            //or
            //INTEGER[(length)] [UNSIGNED] [ZEROFILL]
            // A normal-size integer 
            // The signed range is –2147483648 to 2147483647. The unsigned range is 0 to 4294967295 
            MysqlToCsharp.Add("INT", "Int32");
            MysqlToCsharp.Add("INTEGER", "Int32");

            //BIGINT[(length)] [UNSIGNED] [ZEROFILL] 
            // A large integer 
            // The signed range is –9223372036854775808 to 9223372036854775807. The unsigned range is 0 to 18446744073709551615 
            MysqlToCsharp.Add("BIGINT", "Int64");

            //FLOAT[(length,decimals)] [UNSIGNED] [ZEROFILL] 
            // A small (single-precision) floating-point number. Cannot be unsigned 
            // Ranges are –3.402823466E+38 to –1.175494351E-38, 0 and 1.175494351E-38 to 3.402823466E+38. If the number of Decimals is not set or <= 24 it is a single-precision floating point number 
            MysqlToCsharp.Add("FLOAT", "Single");


            //DOUBLE[(length,decimals)] [UNSIGNED] [ZEROFILL]
            //DOUBLE PRECISION, 
            //REAL[(length,decimals)] [UNSIGNED] [ZEROFILL] 
            // A normal-size (double-precision) floating-point number. Cannot be unsigned 
            // Ranges are -1.7976931348623157E+308 to -2.2250738585072014E-308, 0 and 2.2250738585072014E-308 to 1.7976931348623157E+308. If the number of Decimals is not set or 25 <= Decimals <= 53 stands for a double-precision floating point number 
            MysqlToCsharp.Add("DOUBLE", "Double");
            MysqlToCsharp.Add("REAL", "Double");

            //DECIMAL[(length[,decimals])] [UNSIGNED] [ZEROFILL] 
            //NUMERIC[(length[,decimals])] [UNSIGNED] [ZEROFILL] 
            // An unpacked floating-point number. Cannot be unsigned 
            // Behaves like a CHAR column: “unpacked” means the number is stored as a string, using one character for each digit of the value. The decimal point, and, for negative numbers, the ‘-‘ sign is not counted in Length. If Decimals is 0, values will have no decimal point or fractional part. The maximum range of DECIMAL values is the same as for DOUBLE, but the actual range for a given DECIMAL column may be constrained by the choice of Length and Decimals. If Decimals is left out it’s set to 0. If Length is left out it’s set to 10. Note that in MySQL 3.22 the Length includes the sign and the decimal point 
            MysqlToCsharp.Add("DECIMAL", "Decimal");
            MysqlToCsharp.Add("NUMERIC", "Decimal");


            //DATETIME 
            // A date and time combination 
            // The supported range is ‘1000-01-01 00:00:00’ to ‘9999-12-31 23:59:59’. MySQL displays DATETIME values in ‘YYYY-MM-DD HH:MM:SS’ format 
            MysqlToCsharp.Add("DATETIME", "DateTime");

            //TIMESTAMP 
            // A timestamp 
            // The range is ‘1970-01-01 00:00:00’ to sometime in the year 2037. MySQL displays TIMESTAMP values in YYYYMMDDHHMMSS, YYMMDDHHMMSS, YYYYMMDD or YYMMDD format, depending on whether M is 14 (or missing), 12, 8 or 6, but allows you to assign values to TIMESTAMP columns using either strings or numbers. A TIMESTAMP column is useful for recording the date and time of an INSERT or UPDATE operation because it is automatically set to the date and time of the most recent operation if you don’t give it a value yourself 
            MysqlToCsharp.Add("TIMESTAMP", "DateTime");

            //TIME 
            // A time 
            // The range is ‘-838:59:59’ to ‘838:59:59’. MySQL displays TIME values in ‘HH:MM:SS’ format, but allows you to assign values to TIME columns using either strings or numbers 
            MysqlToCsharp.Add("TIME", "TimeSpan");

            //YEAR 
            // A year in 2- or 4- digit formats (default is 4-digit) 
            // The allowable values are 1901 to 2155, and 0000 in the 4 year format and 1970-2069 if you use the 2 digit format (70-69). MySQL displays YEAR values in YYYY format, but allows you to assign values to YEAR columns using either strings or numbers. (The YEAR type is new in MySQL 3.22.) 
            MysqlToCsharp.Add("YEAR", "Int32");

            //CHAR[(length)][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A fixed-length string that is always right-padded with spaces to the specified length when stored 
            // The range of Length is 1 to 255 characters. Trailing spaces are removed when the value is retrieved. CHAR values are sorted and compared in case-insensitive fashion according to the default character set unless the BINARY keyword is given 
            MysqlToCsharp.Add("CHAR", "String");

            //TINYBLOB, 
            //TINYTEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A BLOB or TEXT column with a maximum length of 255 (2^8 - 1) characters 
            MysqlToCsharp.Add("TINYBLOB", "Byte[]");
            MysqlToCsharp.Add("TINYTEXT", "String");

            //BINARY[(length)]
            //VARBINARY(length)
            MysqlToCsharp.Add("BINARY", "Byte[]");
            MysqlToCsharp.Add("VARBINARY", "Byte[]");


            //BLOB, 
            //TEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A BLOB or TEXT column with a maximum length of 65535 (2^16 - 1) characters 
            MysqlToCsharp.Add("BLOB", "Byte[]");
            MysqlToCsharp.Add("TEXT", "String");

            //MEDIUMBLOB, 
            //MEDIUMTEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name]
            // A BLOB or TEXT column with a maximum length of 16777215 (2^24 - 1) characters 
            MysqlToCsharp.Add("MEDIUMBLOB", "Byte[]");
            MysqlToCsharp.Add("MEDIUMTEXT", "String");

            MysqlToCsharp.Add("BOOLEAN", "Boolean");

            
            //BIT[(length)]
            MysqlToCsharp.Add("BIT", "UInt64");

            //LONGBLOB, 
            //LONGTEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A BLOB or TEXT column with a maximum length of 4294967295 (2^32 - 1) characters 
            MysqlToCsharp.Add("LONGBLOB", "Byte[]");
            MysqlToCsharp.Add("LONGTEXT", "String");

            //ENUM(value1,value2,value3,...)[CHARACTER SET charset_name] [COLLATE collation_name] 
            // An enumeration 
            // A string object that can have only one value, chosen from the list of values ‘value1’, ‘value2’, ..., or NULL. An ENUM can have a maximum of 65535 distinct values. 

            //SET(value1,value2,value3,...)[CHARACTER SET charset_name] [COLLATE collation_name] 
            // A set 
            // A string object that can have zero or more values, each of which must be chosen from the list of values ‘value1’, ‘value2’, ... A SET can have a maximum of 64 members 
            #endregion

            
            /* 
             CsharpToMysql = new Hashtable();

            #region load CsharpToMysql hashtable

            //VARCHAR(length) [CHARACTER SET charset_name] [COLLATE collation_name] 
            // A variable-length string. Note: Trailing spaces are removed when the value is stored (this differs from the ANSI SQL specification) 
            // The range of Length is 1 to 255 characters. VARCHAR values are sorted and compared in case-insensitive fashion unless the BINARY keyword is given 
            CsharpToMysql.Add("String", "VARCHAR");

            //TINYINT[(length)] [UNSIGNED] [ZEROFILL]
            //A very small integer 
            //The signed range is –128 to 127. The unsigned range is 0 to 255. 
            CsharpToMysql.Add("SByte", "TINYNT");

            //DATE 
            // A date 
            // The supported range is ‘1000-01-01’ to ‘9999-12-31’. MySQL displays DATE values in ‘YYYY-MM-DD’ format 
            CsharpToMysql.Add("DateTime", "DATE");

            //SMALLINT[(length)] [UNSIGNED] [ZEROFILL] 
            // A small integer 
            // The signed range is –32768 to 32767. The unsigned range is 0 to 65535 
            CsharpToMysql.Add("Int16", "SMALLINT");

            //MEDIUMINT[(length)] [UNSIGNED] [ZEROFILL] 
            // A medium-size integer 
            // The signed range is –8388608 to 8388607. The unsigned range is 0 to 16777215 
            CsharpToMysql.Add("Int32", "MEDIUMINT");

            //INT[(length)] [UNSIGNED] [ZEROFILL]
            //or
            //INTEGER[(length)] [UNSIGNED] [ZEROFILL]
            // A normal-size integer 
            // The signed range is –2147483648 to 2147483647. The unsigned range is 0 to 4294967295 
            CsharpToMysql.Add("INT", "Int32");
            CsharpToMysql.Add("Int32", "INTEGER");

            //BIGINT[(length)] [UNSIGNED] [ZEROFILL] 
            // A large integer 
            // The signed range is –9223372036854775808 to 9223372036854775807. The unsigned range is 0 to 18446744073709551615 
            CsharpToMysql.Add("Int64", "BIGINT");

            //FLOAT[(length,decimals)] [UNSIGNED] [ZEROFILL] 
            // A small (single-precision) floating-point number. Cannot be unsigned 
            // Ranges are –3.402823466E+38 to –1.175494351E-38, 0 and 1.175494351E-38 to 3.402823466E+38. If the number of Decimals is not set or <= 24 it is a single-precision floating point number 
            CsharpToMysql.Add("Single", "FLOAT");


            //DOUBLE[(length,decimals)] [UNSIGNED] [ZEROFILL]
            //DOUBLE PRECISION, 
            //REAL[(length,decimals)] [UNSIGNED] [ZEROFILL] 
            // A normal-size (double-precision) floating-point number. Cannot be unsigned 
            // Ranges are -1.7976931348623157E+308 to -2.2250738585072014E-308, 0 and 2.2250738585072014E-308 to 1.7976931348623157E+308. If the number of Decimals is not set or 25 <= Decimals <= 53 stands for a double-precision floating point number 
            CsharpToMysql.Add("Double", "DOUBLE");
            CsharpToMysql.Add("Double", "REAL");

            //DECIMAL[(length[,decimals])] [UNSIGNED] [ZEROFILL] 
            //NUMERIC[(length[,decimals])] [UNSIGNED] [ZEROFILL] 
            // An unpacked floating-point number. Cannot be unsigned 
            // Behaves like a CHAR column: “unpacked” means the number is stored as a string, using one character for each digit of the value. The decimal point, and, for negative numbers, the ‘-‘ sign is not counted in Length. If Decimals is 0, values will have no decimal point or fractional part. The maximum range of DECIMAL values is the same as for DOUBLE, but the actual range for a given DECIMAL column may be constrained by the choice of Length and Decimals. If Decimals is left out it’s set to 0. If Length is left out it’s set to 10. Note that in MySQL 3.22 the Length includes the sign and the decimal point 
            CsharpToMysql.Add("Decimal", "DECIMAL");
            CsharpToMysql.Add("Decimal", "NUMERIC");


            //DATETIME 
            // A date and time combination 
            // The supported range is ‘1000-01-01 00:00:00’ to ‘9999-12-31 23:59:59’. MySQL displays DATETIME values in ‘YYYY-MM-DD HH:MM:SS’ format 
            CsharpToMysql.Add("DateTime", "DATETIME");

            //TIMESTAMP 
            // A timestamp 
            // The range is ‘1970-01-01 00:00:00’ to sometime in the year 2037. MySQL displays TIMESTAMP values in YYYYMMDDHHMMSS, YYMMDDHHMMSS, YYYYMMDD or YYMMDD format, depending on whether M is 14 (or missing), 12, 8 or 6, but allows you to assign values to TIMESTAMP columns using either strings or numbers. A TIMESTAMP column is useful for recording the date and time of an INSERT or UPDATE operation because it is automatically set to the date and time of the most recent operation if you don’t give it a value yourself 
            CsharpToMysql.Add("DateTime", "TIMESTAMP");

            //TIME 
            // A time 
            // The range is ‘-838:59:59’ to ‘838:59:59’. MySQL displays TIME values in ‘HH:MM:SS’ format, but allows you to assign values to TIME columns using either strings or numbers 
            CsharpToMysql.Add("TimeSpan", "TIME");

            //YEAR 
            // A year in 2- or 4- digit formats (default is 4-digit) 
            // The allowable values are 1901 to 2155, and 0000 in the 4 year format and 1970-2069 if you use the 2 digit format (70-69). MySQL displays YEAR values in YYYY format, but allows you to assign values to YEAR columns using either strings or numbers. (The YEAR type is new in MySQL 3.22.) 
            CsharpToMysql.Add("Int32", "YEAR");

            //CHAR[(length)][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A fixed-length string that is always right-padded with spaces to the specified length when stored 
            // The range of Length is 1 to 255 characters. Trailing spaces are removed when the value is retrieved. CHAR values are sorted and compared in case-insensitive fashion according to the default character set unless the BINARY keyword is given 
            CsharpToMysql.Add("String", "CHAR");

            //TINYBLOB, 
            //TINYTEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A BLOB or TEXT column with a maximum length of 255 (2^8 - 1) characters 
            CsharpToMysql.Add("Byte[]", "TINYBLOB");
            CsharpToMysql.Add("String", "TINYTEXT");

            //BINARY[(length)]
            //VARBINARY(length)
            CsharpToMysql.Add("Byte[]", "BINARY");
            CsharpToMysql.Add("Byte[]", "VARBINARY");


            //BLOB, 
            //TEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A BLOB or TEXT column with a maximum length of 65535 (2^16 - 1) characters 
            CsharpToMysql.Add("Byte[]", "BLOB");
            CsharpToMysql.Add("String", "TEXT");

            //MEDIUMBLOB, 
            //MEDIUMTEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name]
            // A BLOB or TEXT column with a maximum length of 16777215 (2^24 - 1) characters 
            CsharpToMysql.Add("Byte[]", "MEDIUMBLOB");
            CsharpToMysql.Add("String", "MEDIUMTEXT");

            CsharpToMysql.Add("SByte", "BOOLEAN");

            //BIT[(length)]
            CsharpToMysql.Add("UInt64", "BIT");

            //LONGBLOB, 
            //LONGTEXT [BINARY][CHARACTER SET charset_name] [COLLATE collation_name] 
            // A BLOB or TEXT column with a maximum length of 4294967295 (2^32 - 1) characters 
            CsharpToMysql.Add("Byte[]", "LONGBLOB");
            CsharpToMysql.Add("String", "LONGTEXT");

            //ENUM(value1,value2,value3,...)[CHARACTER SET charset_name] [COLLATE collation_name] 
            // An enumeration 
            // A string object that can have only one value, chosen from the list of values ‘value1’, ‘value2’, ..., or NULL. An ENUM can have a maximum of 65535 distinct values. 

            //SET(value1,value2,value3,...)[CHARACTER SET charset_name] [COLLATE collation_name] 
            // A set 
            // A string object that can have zero or more values, each of which must be chosen from the list of values ‘value1’, ‘value2’, ... A SET can have a maximum of 64 members 
            #endregion
            */
        }
    }

    /// <summary>
    /// Type of dricer used to connect at MySQL Database. 
    /// Ufficial MySql connector MySql.Data.dll see http://dev.mysql.com/downloads/connector
    /// 
    /// or compatible MySQLDriverCS.dll see http://sourceforge.net/projects/mysqldrivercs/
    /// </summary>
    public enum TypeOfDriver
    {

        /// <summary>
        /// Compatible MySQLDriverCS.dll see http://sourceforge.net/projects/mysqldrivercs/
        /// </summary>
        MySQLDriverCS,

        /// <summary>
        /// Ufficial MySql connector MySql.Data.dll see http://dev.mysql.com/downloads/connector
        /// </summary>
        MySqlDriver
    }
    }
