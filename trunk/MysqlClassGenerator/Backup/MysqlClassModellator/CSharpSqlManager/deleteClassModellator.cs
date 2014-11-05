using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.MysqlClassModellator.Informations;
using ClassModellator.ModifierManager;

namespace ClassModellator.MysqlClassModellator.CSharpSqlManager
{
    public class deleteClassModellator : functionModellator
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

       
        public deleteClassModellator()
            :base()
        {
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        public deleteClassModellator(MysqlClass rifClass)
            : base()
        {
            this.ClasseRiferimento = rifClass;
            this.Type = _rifClass.Name;
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        public deleteClassModellator(MysqlClass rifClass, String nameConnection)
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
            base.XmlDocumentationClass.Summary = "Delete " + _rifClass.Name + " row to database";
            base.XmlDocumentationClass.Returns = "Return the number of row deleted.";
            sb.Append(this.getXmlDocumentation());
            sb.Append("\t\t"+this.AccessModifier + " int delete_" + _rifClass.Name + "(" + _rifClass.Name + " varToDelete)");
            //Variables tmpVar;
            //for (int i = 0; i < this.ListVariables.Count;i++ )
            //{
            //    tmpVar = this.ListVariables[i];
            //    sb.Append(tmpVar.Type + " " + tmpVar.Name);
            //    if (i >= 0 && i < this.ListVariables.Count-1)
            //        sb.Append(", ");
            //}
            //sb.Append(")");
            sb.Append(Environment.NewLine+"\t\t{");
            sb.Append(Environment.NewLine + "\t\t\tint retVal = 0;");
            sb.Append(Environment.NewLine + "\t\t\tCultureInfo info = Thread.CurrentThread.CurrentCulture;");
            sb.Append(Environment.NewLine + "\t\t\tThread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"en-GB\");");
            sb.Append(Environment.NewLine + "\t\t\ttry");
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tString query = \"DELETE FROM " + ClasseRiferimento.TableInformation.Name + " \";");
            sb.Append(Environment.NewLine + "\t\t\t\t      query += \"WHERE \";");
            VariableModellator tmpVar1;
            for (int i = 0; i < this.ListVariables.Count; i++)
            {
                tmpVar1 = this.ListVariables[i];
                //if (tmpVar1.Type == "String")
                //{
                //    sb.Append(Environment.NewLine + "\t\t\t\t      query += \"" + tmpVar1.Name + "='\" + varToDelete." + tmpVar1.Name + " + \"'\";");
                //    //if (i != this.ListVariables.Count - 1)
                //    //    sb.Append(" + \"'\";");
                //}
                //else
                //{
                //    sb.Append(Environment.NewLine + "\t\t\t\t      query += \"" + tmpVar1.Name + "=\" + varToDelete." + tmpVar1.Name + ";");
                //    //if (i != this.ListVariables.Count - 1)
                //    //    sb.Append(" + \";");
                //}
                sb.Append(Environment.NewLine + "\t\t\t\t      query += \"" + tmpVar1.Name + " = @" + tmpVar1.Name + "_Param\";");
                
                if (i >= 0 && i < this.ListVariables.Count - 1)
                    sb.Append(Environment.NewLine + "\t\t\t\t      query += \" AND \";");
            }

            //if (this.ListVariables.Count > 0)
            //{
            //    sb.Append(";");
            //}

            sb.Append(Environment.NewLine);
            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySqlCommand command = new MySqlCommand(query);");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySQLCommand command = new MySQLCommand(query);");
            }
            sb.Append(Environment.NewLine + "\t\t\t\tcommand.Connection = " + _nameConnection + ";");
            
            foreach (VariableModellator tmpVar in this.ListVariables)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters.AddWithValue(\"@" + tmpVar.Name + "_Param\", varToDelete." + tmpVar.Name + ");");

            }

            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine + "\t\t\t\tcommand.Prepare();");
            sb.Append(Environment.NewLine + "\t\t\t\tretVal = command.ExecuteNonQuery();");
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
            sb.Append(Environment.NewLine + "\t\t\t\tThread.CurrentThread.CurrentCulture = info;");
            sb.Append(Environment.NewLine + "\t\t\t}");//finally
            sb.Append(Environment.NewLine + "\t\t\treturn retVal;");
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
