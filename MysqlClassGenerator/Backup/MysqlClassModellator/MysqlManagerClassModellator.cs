using System;
using System.Collections.Generic;
using System.Text;

using ClassModellator.MysqlClassModellator.CSharpSqlManager;
using ClassModellator.ModifierManager;


namespace ClassModellator.MysqlClassModellator.MysqlClassModellator
{
    public class MysqlManagerClassModellator : ClassModellatorOld
    { 
    	//

        #region Encapsulation properties

        MysqlClass _mysqlClassRiferimento;

        public MysqlClass MysqlClassRiferimento
        {
            get { return _mysqlClassRiferimento; }
            set { _mysqlClassRiferimento = value; }
        }


        getClassModellator _getClassModellator;

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



        public getClassModellator GetClassModellator
        {
            get { return _getClassModellator; }
            set { _getClassModellator = value; }
        }


        getListClassModellator _getListClassModellator;

        public getListClassModellator GetListClassModellator
        {
            get { return _getListClassModellator; }
            set { _getListClassModellator = value; }
        }

        insertClassModellator _insertClassModellator;

        public insertClassModellator InsertClassModellator
        {
            get { return _insertClassModellator; }
            set { _insertClassModellator = value; }
        }


        deleteClassModellator _deleteClassModellator;

        public deleteClassModellator DeleteClassModellator
        {
            get { return _deleteClassModellator; }
            set { _deleteClassModellator = value; }
        }


        updateClassModellator _updateClassModellator;

        public updateClassModellator UpdateClassModellator
        {
            get { return _updateClassModellator; }
            set { _updateClassModellator = value; }
        }
        #endregion

        #region costructor

        
        public MysqlManagerClassModellator(MysqlClass MysqlClassRiferimento)
            : base()
        {
            this.inizializzaClasse(MysqlClassRiferimento);
        }

        public MysqlManagerClassModellator(String OutputNameClass, MysqlClass MysqlClassRiferimento)
            : base(OutputNameClass)
        {
            this.inizializzaClasse(MysqlClassRiferimento);
        }

        private void inizializzaClasse(MysqlClass MysqlClassRiferimento)
        {
            base.ListUsing.Add(Environment.NewLine);

            this.MysqlClassRiferimento = MysqlClassRiferimento;
            
            this.Name = "Manager_" + _mysqlClassRiferimento.Name;
            this.NameSpace = _mysqlClassRiferimento.NameSpace + ".Manager";
            base.AccessModifier = ListAccessModifiers.PUBLIC_PARTIAL.Value;
            this.setProperty();
            this.setListaFunzioni(_mysqlClassRiferimento);
            this.DriverUsed = TypeOfDriver.MySqlDriver;
            this.addUsing();
        }


        private void setProperty()
        {
            this.ListProperties.Add(new PropertyModellator("connectionString", "String"));
            this.ListProperties.Add(new PropertyModellator("connection", this.MysqlClassRiferimento.DriverUsed.ToString()));
        }

        private void addUsing()
        {
            base.ListUsing.Add(Environment.NewLine);
            base.ListUsing.Add("System.Globalization");
            base.ListUsing.Add("System.Threading");
            base.ListUsing.Add("System.Data");
            base.ListUsing.Add(Environment.NewLine);
            base.ListUsing.Add(_mysqlClassRiferimento.NameSpace);

        }
        #endregion

        private void setListaFunzioni(MysqlClass MysqlClassRiferimento)
        {
            _getClassModellator = new getClassModellator(MysqlClassRiferimento,"this._connection");
            _getClassModellator = new getClassModellator(MysqlClassRiferimento, "this._connection");
            _getListClassModellator = new getListClassModellator(MysqlClassRiferimento, "this._connection");
            _insertClassModellator = new insertClassModellator(MysqlClassRiferimento, "this._connection");
            _deleteClassModellator = new deleteClassModellator(MysqlClassRiferimento, "this._connection");
            _updateClassModellator = new updateClassModellator(MysqlClassRiferimento, "this._connection");
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
                    outputString.Append(this.getHeader(null,true));

                    
                    //outputString.Append("\t\t#region Property incapsultation" + Environment.NewLine + Environment.NewLine);
                    //foreach (PropertyModellator pm in ListProperty)
                    //{
                    //    outputString.Append(pm.getEncapsulationsProperty());
                    //}
                    //outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);


                    outputString.Append("\t\t#region Constructor" + Environment.NewLine + Environment.NewLine);
                    outputString.Append(this.getDefaultCostructor());

                    List<String> ls= new List<String>();
                    ls.Add("this._connection.open();");

                    outputString.Append(base.getCostructorWithAllPropertyAndStr(ls));
                    
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine);

                    outputString.Append("\t\t#region public function" + Environment.NewLine + Environment.NewLine);

                    outputString.Append(this._getClassModellator.getFunctionModelleted());
                    outputString.Append(Environment.NewLine);
                    outputString.Append(this._getListClassModellator.getFunctionModelleted());
                    outputString.Append(Environment.NewLine);
                    outputString.Append(this._insertClassModellator.getFunctionModelleted());
                    outputString.Append(Environment.NewLine);
                    outputString.Append(this._updateClassModellator.getFunctionModelleted());
                    outputString.Append(this._deleteClassModellator.getFunctionModelleted());
                    outputString.Append(Environment.NewLine);
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

        protected override String getDefaultCostructor()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\t\tpublic " + this.Name + "()" + Environment.NewLine);
            sb.Append("\t\t{" + Environment.NewLine);
            sb.Append("\t\t\tthis._connectionString = \"Database=DATABASE; Data Source=LOCALHOST; database=mysql; User Id=USERNAME; Password=PASSWORD\";" + Environment.NewLine);
            if (this.DriverUsed == TypeOfDriver.MySqlDriver)
            {
                sb.Append(Environment.NewLine + "\t\t\tthis._connection = new MySqlConnection( this._connectionString );" + Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine + "\t\t\tthis._connection = new MySQLConnection( this._connectionString );" + Environment.NewLine);
            }
            sb.Append(Environment.NewLine + "\t\t\tthis._connection.open();" + Environment.NewLine);
            sb.Append("\t\t}" + Environment.NewLine + Environment.NewLine);

            return sb.ToString();
            
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
                    outputString.Append("\t\t// Insert here your personal Code" + Environment.NewLine );
                    outputString.Append("\t\t// " + Environment.NewLine + Environment.NewLine);
                    outputString.Append("\t\t#endregion" + Environment.NewLine + Environment.NewLine );
                    
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
    }
}
