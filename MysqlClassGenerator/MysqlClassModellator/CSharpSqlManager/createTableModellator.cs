using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.ModifierManager;
using ClassModellator.MysqlClassModellator.Informations;

namespace ClassModellator.MysqlClassModellator.CSharpSqlManager
{
    public class createTableModellator : functionModellator
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

       

        public createTableModellator()
            :base()
        {
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        public createTableModellator(MysqlClass rifClass)
            : base()
        {
            this.ClasseRiferimento = rifClass;
            this.Type = _rifClass.Name;
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        public createTableModellator(MysqlClass rifClass, String nameConnection)
            : base()
        {
            this.ClasseRiferimento = rifClass;
            this.Type = _rifClass.Name;
            _nameConnection = nameConnection;
            this.AccessModifier =  ListAccessModifiers.PUBLIC.Value; //public
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
            base.Description = "Create Table: " + _rifClass.Name + ".";
            //base.XmlDocumentationClass.Summary = "Create Table: " + _rifClass.Name + ".";
            base.XmlDocumentationClass.Returns = "Return false if the query go to in exception.";
            sb.Append(base.getXmlDocumentationNoParams());
            sb.Append("\t\t" + this.AccessModifier + " Boolean createTable_" + _rifClass.Name + "()");
            sb.Append(Environment.NewLine + "\t\t{");
            sb.Append(Environment.NewLine + "\t\t\tint retVal = true;");
            sb.Append(Environment.NewLine + "\t\t\tCultureInfo info = Thread.CurrentThread.CurrentCulture;");
            sb.Append(Environment.NewLine + "\t\t\tThread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"en-GB\");");
            sb.Append(Environment.NewLine + "\t\t\ttry");
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tString query = \"" + ClasseRiferimento.TableInformation.CreateTableStatement + "\";");
            sb.Append(Environment.NewLine);
            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySqlCommand command = new MySqlCommand(query," + _nameConnection + ");");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t\t\t\tretVal = command.ExecuteNonQuery();");
                sb.Append(Environment.NewLine + "\t\t\t}"); //try
                sb.Append(Environment.NewLine + "\t\t\tcatch (MySqlException ex)");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySQLCommand command = new MySQLCommand(query)," + _nameConnection + ");");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t\t\t\tcommand.ExecuteNonQuery();");
                sb.Append(Environment.NewLine + "\t\t\t}"); //try
                sb.Append(Environment.NewLine + "\t\t\tcatch (MySQLException ex)");
            }
           
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tretVal = false;");
            sb.Append(Environment.NewLine + "\t\t\t\tthrow (ex);");
            sb.Append(Environment.NewLine + "\t\t\t}");//catch
            sb.Append(Environment.NewLine + "\t\t\tfinally");
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tThread.CurrentThread.CurrentCulture = info;");
            sb.Append(Environment.NewLine + "\t\t\t}");//finally
            sb.Append(Environment.NewLine + "\t\t\treturn retVal;");
            sb.Append(Environment.NewLine + "\t\t}");//global
            return sb.ToString();
        }        
    
    }
}
