using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

using ClassModellator.MysqlClassModellator.Informations;
using System.Collections;


namespace ClassModellator.MysqlClassModellator
{
    public  class MysqlClass : ClassModellatorOld
    {
    	//
        
        List<CoulomnInformations> _listCouloumbInformations;

        public List<CoulomnInformations> ListCouloumbInformations
        {
            get { return _listCouloumbInformations; }
            set { _listCouloumbInformations = value; }
        }

        TableInformations _tableInformation;
        public TableInformations TableInformation
        {
            get { return _tableInformation; }
            set { _tableInformation = value; }
        }

        TypeOfDriver _driverUsed;
        /// <summary>
        /// Type of driver used (default MySqlDriver)
        /// </summary>
        public TypeOfDriver DriverUsed
        {

            get { return _driverUsed; }
            set
            {
                _driverUsed = value;
                this.setdefaultsUsing();
                base.ListUsing.Add(String.Empty);
                if (this._driverUsed == TypeOfDriver.MySqlDriver)
                {
                    base.ListUsing.Add("MySql.Data.MySqlClient");
                }
                else
                {
                    base.ListUsing.Add("MySQLDriverCS");

                }
            }
        }


        public MysqlClass()
            : base()
        {
            this.NameSpace = "Table.Mapping";            
            this.DriverUsed = TypeOfDriver.MySqlDriver;
            this.AccessModifier =  "public partial";
        }

        public MysqlClass(String OutputNameClass)
            :base(OutputNameClass) 
        {
            this.NameSpace = "Table.Mapping";
            this.DriverUsed = TypeOfDriver.MySqlDriver;
            this.AccessModifier = "public partial";
        }

        //protected override string getUsing()
        //{
        //    StringBuilder sb = new StringBuilder();
            
        //    sb.Append(base.getUsing());
            
        //    if (this._driverUsed == TypeOfDriver.MySqlDriver)
        //    {
        //        sb.Append("using MySql.Data.MySqlClient;"+Environment.NewLine+Environment.NewLine);
        //    }
        //    else
        //    {
        //        sb.Append("using MySQLDriverCS;"+Environment.NewLine+Environment.NewLine);

        //    }
        //    return sb.ToString();
        //}


        protected string getCostructorReader()
        {
            /*public NAME()
             * {
             * 
             * }
             */
            StringBuilder sb = new StringBuilder();
            if (this._driverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append("\t\tpublic " + this.Name + "(MySqlDataReader reader)"+Environment.NewLine);
            }
            else
            {
                sb.Append("\t\tpublic " + this.Name + "(MySQLDataReader reader)"+Environment.NewLine);

            }
            sb.Append("\t\t{"+Environment.NewLine);
            foreach (PropertyModellator pm in this.ListProperties)
            {
                sb.Append(pm.getConstructorPropertyStringReader());
            }
            sb.Append("\t\t}"+Environment.NewLine+Environment.NewLine);

            return sb.ToString();

        }

        public List<VariableModellator> getPrimaryKey()
        {
            List<VariableModellator> items = new List<VariableModellator>();
            foreach (CoulomnInformations tmp in _listCouloumbInformations)
            {
                if (tmp.Key == "PRI")
                {
                    items.Add(new VariableModellator(MysqlTypeMapping.getCsharpType(tmp.Type), tmp.Field,tmp.Comment)); 
                    
                }
            }
            return items;
        
        }

        /// <summary>
        /// return the string that connetin class 
        /// </summary>
        /// <returns></returns>
        public override String getClassModellated()
        {
            StringBuilder outputString = new StringBuilder();
            if (this.Name != null)
            {
                try
                {
                    outputString.Append(this.getHeader(null, true));

                    outputString.Append("\t\t#region Property encapsulation" + Environment.NewLine + Environment.NewLine);
                    foreach (PropertyModellator pm in ListProperties)
                    {
                        outputString.Append(pm.getEncapsulationsProperty());
                    }
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);


                    outputString.Append("\t\t#region Constructor" + Environment.NewLine + Environment.NewLine);
                    outputString.Append(base.getDefaultCostructor());
                    outputString.Append(base.getCostructorWithAllProperty());
                    outputString.Append(this.getCostructorReader());
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);

                    outputString.Append("\t\t#region Public Function" + Environment.NewLine + Environment.NewLine);
                    outputString.Append(base.getResetFunction());
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);

                    outputString.Append("\t\t#region Private Function" + Environment.NewLine);
                    outputString.Append("\t\t// " + Environment.NewLine);
                    outputString.Append("\t\t// Please NOT Modify this file use Personal Code Class." + Environment.NewLine);
                    outputString.Append("\t\t// " + Environment.NewLine);
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);

                    outputString.Append(base.getFoter());
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                throw new Exception("The property Name is not set");
            }
            return outputString.ToString();
        }


        public String getPersonalCodeClassModelleted()
        {
            StringBuilder outputString = new StringBuilder();
            if (this.Name != null)
            {
                try
                {
                    outputString.Append(this.getHeader("Personal Code",false));

                    outputString.Append("\t\t#region Personal Code" + Environment.NewLine + Environment.NewLine);
                    outputString.Append("\t\t// " + Environment.NewLine);
                    outputString.Append("\t\t// Insert here your personal Code" + Environment.NewLine);
                    outputString.Append("\t\t// " + Environment.NewLine + Environment.NewLine);
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);

                    outputString.Append(base.getFoter());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new Exception("The property Name is not set");
            }
            return outputString.ToString(); ;
        }

        /*
        public override void writeClass()
        {
            if (this.Name != null)
            {

                StreamWriter sw = File.CreateText(this.PathToSave + "\\" + this.FileName);

                try
                {
                    sw.Write(this.getHeader());

                    sw.Write("\t\t#region Property incapsultation"+Environment.NewLine+Environment.NewLine);
                    foreach (PropertyModellator pm in this.ListProperty)
                    {
                        sw.Write(pm.getEncapsulationsProperty());
                    }
                    sw.Write("\t\t#endregion"+Environment.NewLine+Environment.NewLine);


                    sw.Write("\t\t#region Costructor"+Environment.NewLine+Environment.NewLine);
                    sw.Write(base.getCostructor());
                    sw.Write(base.getCostructorLine());
                    sw.Write(this.getCostructorReader());
                    sw.Write("\t\t#endregion"+Environment.NewLine+Environment.NewLine);


                    sw.Write(base.getFoter());
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    sw.Close();
                }
            }
            else
            {
                throw new Exception("The property Name is not set");
            }

        }
        */
    }
}
