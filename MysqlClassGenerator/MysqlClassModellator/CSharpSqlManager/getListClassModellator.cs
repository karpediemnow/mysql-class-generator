using System;
using System.Collections.Generic;
using System.Text;

using ClassModellator;
using ClassModellator.ModifierManager;

namespace ClassModellator.MysqlClassModellator.CSharpSqlManager
{
    public class getListClassModellator : functionModellator
    {
        MysqlClass _rifClass;
        public MysqlClass RifClass
        {
            get { return _rifClass; }
            set { _rifClass = value; }
        }

        
        String _nameConnection;
        /// <summary>
        /// Name of connection
        /// </summary>
        public String NameConnection
        {
            get { return _nameConnection; }
            set { _nameConnection = value; }
        }

       

        public getListClassModellator()
            : base()
        {
            base.AccessModifier = ListAccessModifiers.PUBLIC.Value;
        }

        public getListClassModellator(MysqlClass rifClass)
            : base()
        {
            _rifClass = rifClass;
            base.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
            base.Name = _rifClass.Name;
        }

        public getListClassModellator(MysqlClass rifClass, String nameConnection)
            : base()
        {
            _rifClass = rifClass;
            _nameConnection = nameConnection;
            base.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
            base.Name = _rifClass.Name;
        }

        public virtual String getFunctionModelleted()
        {
            StringBuilder sb = new StringBuilder();
            base.XmlDocumentationClass.Summary = "Get all istances of " + _rifClass.Name + " class.";
            base.XmlDocumentationClass.Returns = "List of " + _rifClass.Name + " class ";
            sb.Append(this.getXmlDocumentation());

            //if (_modifier != null && _modifier.Trim().Length != 0)
            //{
            // public List<TipiMovimento_TB0028> getListaTipiMovimento()
            sb.Append("\t\t" + base.AccessModifier + " List<" + base.Name + "> getList_" + base.Name + "()");
            sb.Append(Environment.NewLine + "\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t//Insert: using System.Threading");
            sb.Append(Environment.NewLine + "\t\t\t//Insert: using System.Globalization;");
            sb.Append(Environment.NewLine + "\t\t\tCultureInfo info = Thread.CurrentThread.CurrentCulture;");
            sb.Append(Environment.NewLine + "\t\t\tThread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"en-GB\");");
            //   List<TipiMovimento_TB0028> items = new List<TipiMovimento_TB0028>();
            sb.Append(Environment.NewLine + "\t\t\tList<" + _rifClass.Name + "> items = new List<" + _rifClass.Name + ">();");
            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\tMySqlDataReader reader = null;");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\tMySQLDataReader reader = null;");
            }
            sb.Append(Environment.NewLine + "\t\t\ttry");
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tString query=\"SELECT * FROM " + RifClass.TableInformation.Name + "\";");

            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySqlCommand command = new MySqlCommand(query, this._connection);");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySQLCommand command = new MySQLCommand(query, this._connection);");
            }
            
            sb.Append(Environment.NewLine + "\t\t\t\tcommand.Connection = " + _nameConnection + ";");

            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\treader = command.ExecuteReader();");
            }
            else
            {
             
                sb.Append(Environment.NewLine + "\t\t\t\treader = command.ExecuteReaderEx();");
            }
            sb.Append(Environment.NewLine + "\t\t\t\tif (reader.HasRows)");
            sb.Append(Environment.NewLine + "\t\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\t\twhile (reader.Read())");
            sb.Append(Environment.NewLine + "\t\t\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\t\t\titems.Add(new " + _rifClass.Name + "(reader));");
            sb.Append(Environment.NewLine + "\t\t\t\t\t}");//while
            sb.Append(Environment.NewLine + "\t\t\t\t}");//if 
            sb.Append(Environment.NewLine + "\t\t\t\t//else");
            sb.Append(Environment.NewLine + "\t\t\t\t//{");
            sb.Append(Environment.NewLine + "\t\t\t\t//\titems = null;");
            sb.Append(Environment.NewLine + "\t\t\t\t//}");
            sb.Append(Environment.NewLine + "\t\t\t}"); //try
            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\tcatch (MySqlException ex)");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\tcatch (MySQLException ex)");
            }
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tthrow (ex);");
            sb.Append(Environment.NewLine + "\t\t\t}");//catch
            sb.Append(Environment.NewLine + "\t\t\tfinally");
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\treader.Close();");
            sb.Append(Environment.NewLine + "\t\t\t\tThread.CurrentThread.CurrentCulture = info;");
            sb.Append(Environment.NewLine + "\t\t\t}");//finally
            sb.Append(Environment.NewLine + "\t\t\treturn items;");
            sb.Append(Environment.NewLine + "\t\t}");//global
            //}
            //else
            //{
            //    throw new ArgumentException("Invalid argument", "Modifier");
            //}
            return sb.ToString();
        }
    }
}
