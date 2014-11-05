using System;
using System.Collections.Generic;
using System.Text;

using ClassModellator;
using ClassModellator.ModifierManager;

namespace ClassModellator.MysqlClassModellator.CSharpSqlManager
{
    public class getClassModellator : functionModellator
    {
        MysqlClass _rifClass;

        public MysqlClass ClasseRiferimento
        {
            get { return _rifClass; }
            set
            {
                _rifClass = value;
                if (_rifClass != null)
                {
                    base.ListVariables = _rifClass.getPrimaryKey();
                }
            }
        }

        public String Description {
            get
            {
                if (base.Description.Length == 0)
                {
                    base.Description = "Function to get the class " + _rifClass.Name; 
                }
                    return base.Description;
                
            }
            set { base.Description = value; }
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
        //String _IdName;

        ///// <summary>
        ///// Name of key value
        ///// </summary>
        //public String IdName
        //{
        //    get { return _IdName; }
        //    set { _IdName = value; }
        //}

        

        public getClassModellator()
            :base()
        {
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        public getClassModellator(MysqlClass rifClass, String nameConnection)
            : base()
        {
            this.ClasseRiferimento = rifClass;
            this.Type = _rifClass.Name;
            _nameConnection = nameConnection;
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }
        public getClassModellator(MysqlClass rifClass)
            : base()
        {
            this.ClasseRiferimento = rifClass;
            this.Type = _rifClass.Name;
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameConnection"></param>
        /// <param name="IdName"></param>
        /// <returns></returns>
        public virtual String getFunctionModelleted()
        {
            StringBuilder sb = new StringBuilder();
            base.XmlDocumentationClass.Summary = "Get the class " + _rifClass.Name;
            base.XmlDocumentationClass.Returns = "Return the " + _rifClass.Name + " class ";
            sb.Append(this.getXmlDocumentation());
            sb.Append("\t\t"+this.AccessModifier + " " + _rifClass.Name + " get_" + _rifClass.Name + "(");
            VariableModellator tmpVar;
            for (int i = 0; i < this.ListVariables.Count;i++ )
            {
                tmpVar = this.ListVariables[i];
                sb.Append(tmpVar.Type + " " + tmpVar.Name);
                if (i >= 0 && i < this.ListVariables.Count-1)
                    sb.Append(", ");
            }
            sb.Append(")");
            sb.Append(Environment.NewLine + "\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t//Insert: using System.Threading;");
            sb.Append(Environment.NewLine + "\t\t\t//Insert: using System.Globalization;");
            sb.Append(Environment.NewLine + "\t\t\tCultureInfo info = Thread.CurrentThread.CurrentCulture;");
            sb.Append(Environment.NewLine + "\t\t\tThread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"en-GB\");");
            sb.Append(Environment.NewLine + "\t\t\t" + _rifClass.Name + " tmp = null;");

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
            sb.Append(Environment.NewLine + "\t\t\t\tString query=\"SELECT * FROM " + ClasseRiferimento.TableInformation.Name + " WHERE  ");
            VariableModellator tmpVar1;
            //->inserito add command.Parameters.AddWithValue
            for (int i = 0; i < this.ListVariables.Count; i++)
            {
                tmpVar1 = this.ListVariables[i];
                sb.Append(tmpVar1.Name + "=@" + tmpVar1.Name);
                if (i >= 0 && i < this.ListVariables.Count - 1)
                    sb.Append(" AND ");
            }
            //-<

            //for (int i = 0; i < this.ListVariables.Count; i++)
            //{
            //    tmpVar1 = this.ListVariables[i];
            //    if (tmpVar1.Type == "String")
            //    {
            //        sb.Append(tmpVar1.Name + "='\" + " + tmpVar1.Name + " + \"'");
            //    }
            //    else
            //    {
            //        sb.Append(tmpVar1.Name + "=\" + " + tmpVar1.Name + " + \"");

            //    }
            //    if (i >= 0 && i < this.ListVariables.Count - 1)
            //        sb.Append(" AND ");
            //}
            sb.Append("\";"); //fineQuery

            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySqlCommand command = new MySqlCommand(query," + _nameConnection + ");");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySQLCommand command = new MySQLCommand(query," + _nameConnection + ");");
            }

            //->inserito add command.Parameters.AddWithValue
            for (int i = 0; i < this.ListVariables.Count; i++)
            {
                tmpVar1 = this.ListVariables[i];
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters.AddWithValue(\"@" + tmpVar1.Name + "\"," + tmpVar1.Name + ");");

            }
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine + "\t\t\t\tcommand.Prepare();");
            //-<

            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\treader = command.ExecuteReader();");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\t\treader = command.ExecuteReaderEx();");
            }

            //if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            //{
            //    sb.Append(Environment.NewLine + "\t\t\t\tMySqlCommand command = new MySqlCommand(query," + _nameConnection + ");");
            //    sb.Append(Environment.NewLine + "\t\t\t\treader = command.ExecuteReader();");
            //}
            //else
            //{
            //    sb.Append(Environment.NewLine + "\t\t\t\tMySQLCommand command = new MySQLCommand(query," + _nameConnection + ");");
            //    sb.Append(Environment.NewLine + "\t\t\t\treader = command.ExecuteReaderEx();");
            //}

            sb.Append(Environment.NewLine + "\t\t\t\tif (reader.Read())");
            sb.Append(Environment.NewLine + "\t\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\t\ttmp = new " + _rifClass.Name + "(reader);");
            sb.Append(Environment.NewLine + "\t\t\t\t}");//if 
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
            sb.Append(Environment.NewLine + "\t\t\treturn tmp;");
            sb.Append(Environment.NewLine + "\t\t}");//global
            //}
            //else
            //{
            //    throw new ArgumentException("Invalid argument", "Modifier");
            //}
            return sb.ToString();
        }
      
        /*
    using System.Threading;
    using System.Globalization;

         public CondizioniPagmento_tb0037  getCondizionePagamento(String idCondizionePagamento)
       {
           CultureInfo info = Thread.CurrentThread.CurrentCulture;
           Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
           CondizioniPagmento_tb0037 tmp = null;
           try
           {
           MySQLCommand command = new MySQLCommand("SELECT * FROM TB0038 where idPagamento='" + idCondizionePagamento + "';");
           command.Connection = this._connessione;
           MySQLDataReader reader = command.ExecuteReaderEx();

           if (reader.HasRows)
           {
               reader.Read();
               tmp = new CondizioniPagmento_tb0037(reader);
           }
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           {
               Thread.CurrentThread.CurrentCulture = info;
           }
           return tmp;
       }
    */
    }
}
