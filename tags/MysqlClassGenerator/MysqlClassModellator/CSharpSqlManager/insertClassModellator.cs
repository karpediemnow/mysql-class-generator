using System;
using System.Collections.Generic;
using System.Text;

using ClassModellator;
using ClassModellator.MysqlClassModellator.Informations;
using ClassModellator.ModifierManager;

namespace ClassModellator.MysqlClassModellator.CSharpSqlManager
{
    public class insertClassModellator : functionModellator
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

       

        public insertClassModellator()
            :base()
        {
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }
        public insertClassModellator(MysqlClass rifClass)
            : base()
        {
            this.ClasseRiferimento = rifClass;
            this.Type = _rifClass.Name;
            this.AccessModifier = ListAccessModifiers.PUBLIC.Value; //public
        }

        public insertClassModellator(MysqlClass rifClass, String nameConnection)
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
            base.XmlDocumentationClass.Summary = "Insert " + _rifClass.Name + " value into database";
            base.XmlDocumentationClass.Returns = "Return the number of row inserted.";
            sb.Append(this.getXmlDocumentation());
            sb.Append("\t\t"+this.AccessModifier + " int insert_" + _rifClass.Name + "(" + _rifClass.Name + " varToInsert)");
            //Variables tmpVar;
            //for (int i = 0; i < this.ListVariables.Count;i++ )
            //{
            //    tmpVar = this.ListVariables[i];
            //    sb.Append(tmpVar.Type + " " + tmpVar.Name);
            //    if (i >= 0 && i < this.ListVariables.Count-1)
            //        sb.Append(", ");
            //}
            //sb.Append(")");
            sb.Append(Environment.NewLine + "\t\t{");
            sb.Append(Environment.NewLine + "\t\t\tint retVal = 0;");
            sb.Append(Environment.NewLine + "\t\t\tCultureInfo info = Thread.CurrentThread.CurrentCulture;");
            sb.Append(Environment.NewLine + "\t\t\tThread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"en-GB\");");
            sb.Append(Environment.NewLine + "\t\t\ttry");
            sb.Append(Environment.NewLine + "\t\t\t{");
            sb.Append(Environment.NewLine + "\t\t\t\tString query = \"INSERT INTO " + ClasseRiferimento.TableInformation.Name + " (\";");
             CoulomnInformations tmpVar1;
            for (int i = 0; i < this.ClasseRiferimento.ListCouloumbInformations.Count; i++)
            {
                tmpVar1 = this.ClasseRiferimento.ListCouloumbInformations[i];
                if (i == 0)
                {
                    sb.Append(Environment.NewLine + "\t\t\t\t      query += \" " + tmpVar1.Field + " \";");
                }
                else
                {
                    sb.Append(Environment.NewLine + "\t\t\t\t      query += \" ," + tmpVar1.Field + " \";");
                }
            }
            sb.Append(Environment.NewLine + "\t\t\t\t      query += \") VALUES (\";");
            for (int i = 0; i < this.ClasseRiferimento.ListCouloumbInformations.Count; i++)
            {
                tmpVar1 = this.ClasseRiferimento.ListCouloumbInformations[i];
                if (i == 0)
                {
                    sb.Append(Environment.NewLine + "\t\t\t\t      query += \" @" + tmpVar1.Field + "\";");
                }
                else
                {
                    sb.Append(Environment.NewLine + "\t\t\t\t      query += \",@" + tmpVar1.Field + "\";");
                }
            }
            sb.Append(Environment.NewLine + "\t\t\t\t      query += \");\";");
            sb.Append(Environment.NewLine);
            if (this._rifClass.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySqlCommand command = new MySqlCommand(query," + _nameConnection + ");");
                for (int i = 0; i < this.ClasseRiferimento.ListCouloumbInformations.Count; i++)
                {
                    tmpVar1 = this.ClasseRiferimento.ListCouloumbInformations[i];
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters.AddWithValue(\"@" + tmpVar1.Field + "\",varToInsert." + tmpVar1.Field + ");");

                    ////deprecated
                    //sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters.Add(\"@" + tmpVar1.Field + "\",DbType." + MysqlTypeMapping.getCsharpType(tmpVar1.Type) + ");");
                    ////deprecated
                    //sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters[\"@" + tmpVar1.Field + "\"].Value = varToInsert." + tmpVar1.Field + ";");
                }
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t\t\t\tcommand.Prepare();");
                sb.Append(Environment.NewLine + "\t\t\t\tretVal = command.ExecuteNonQuery();");
                sb.Append(Environment.NewLine + "\t\t\t}"); //try
                sb.Append(Environment.NewLine + "\t\t\tcatch (MySqlException ex)");
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\t\tMySQLCommand command = new MySQLCommand(query)," + _nameConnection + ");");
                //command.Parameters.Add("?idAzienda?", DbType.String);
                // command.Parameters["?idAzienda?"].Value = Variabile.idAzienda;
                for (int i = 0; i < this.ClasseRiferimento.ListCouloumbInformations.Count; i++)
                {
                    tmpVar1 = this.ClasseRiferimento.ListCouloumbInformations[i];
                    //sb.Append(Environment.NewLine);
                    //sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters.AddWithValue(\"@" + tmpVar1.Field + "\",varToInsert." + tmpVar1.Field + ");");

                    //deprecated
                    sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters.Add(\"@" + tmpVar1.Field + "\",DbType." + MysqlTypeMapping.getCsharpType(tmpVar1.Type) + ");");
                    //deprecated
                    sb.Append(Environment.NewLine + "\t\t\t\tcommand.Parameters[\"@" + tmpVar1.Field + "\"].Value = varToInsert." + tmpVar1.Field + ";");
                }
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + "\t\t\t\tcommand.Prepare();");
                sb.Append(Environment.NewLine + "\t\t\t\tretVal = command.ExecuteNonQuery();");
                sb.Append(Environment.NewLine + "\t\t\t}"); //try
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
