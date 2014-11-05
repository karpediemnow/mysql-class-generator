using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.ModifierManager;
using ClassModellator.Class;
using ClassModellator.Statment;

namespace ClassModellator
{
    /// <summary>
    /// 
    /// <code>
    /// public int Width
    /// {
    ///     get
    ///     {
    ///         return;
    ///     }
    ///     set
    ///     {
    ///         value;
    ///     }
    /// }
    /// </code>    
    /// </summary>
    public class PropertyModellatorNew:FieldModelletor, ClassModellator.Interface.IPropertyModellator
    {
        private Boolean _createSET;
        private Boolean _createGET;
        private Boolean _isNullable;
        object _tag;

        private getStatmentModellator _getCode;
        public getStatmentModellator GetCode
        {
            get { return _getCode; }
            set { _getCode = value; }
        }

        private setStatmentModellator _setCode;
        public setStatmentModellator SetCode
        {
            get { return _setCode; }
            set { _setCode = value; }
        }


        /// <summary>
        /// get or set Object
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Flag to specify if the property have get 
        /// </summary>
        public Boolean CreateGET
        {
            get { return _createGET; }
            set { _createGET = value; }
        }

        /// <summary>
        /// Flag to specify if the property have set
        /// </summary>
        public Boolean CreateSET
        {
            get { return _createSET; }
            set { _createSET = value; }
        }

        /// <summary>
        /// Type of property
        /// </summary>
        public String Type
        {
            get { return base.Type.Replace("System.", ""); }
            set { base.Type = value; }
        }

        /// <summary>
        /// The property is nullable
        /// </summary>
        public Boolean IsNullable
        {
            get { return _isNullable; }
            set { _isNullable = value; }
        }

     
        /// <summary>
        /// default contructor
        /// </summary>
        public PropertyModellatorNew()
        {
            this._createGET = true;
            this._createSET = true;
            base.Name = null;
            base.Type = null;
            this._isNullable = true;

            _getCode = new getStatmentModellator();
            CodeModellator tmpGet = new CodeModellator();
            tmpGet.AddLine("return;");
            _getCode.Body = tmpGet;

            _setCode = new setStatmentModellator();
            CodeModellator tmpSet = new CodeModellator();
            tmpSet.AddLine("value;");
            _setCode.Body = tmpSet;
        }

       
        /// <summary>
        /// contructor whith 2 parameters
        /// </summary>
        /// <param name="Name">Name of property</param>
        /// <param name="Type">Type of property</param>
        public PropertyModellatorNew(String Name, String Type)
            : base(Type, Name)
        {
            this.Name = Name;
            this.Type = Type;
        }

        public PropertyModellatorNew(String Name, String Type, bool createGET, bool createSET)
            : this(Name,Type)
        {
            this._createGET = createGET;
            this._createSET = createSET;
        }

       
        public PropertyModellatorNew(String Name, String Type, bool createGET, bool createSET,String Description)
            : this( Name, Type, createGET, createSET)
        {
            base.Description = Description;
        }

        public PropertyModellatorNew(String Name, String Type, bool createGET, bool createSET, String Summary, Modifier AccessModifier)
            : this(Name, Type, createGET, createSET, Summary)
        {
            base.AccessModifier = AccessModifier;
            
        }

        public PropertyModellatorNew(String Name, String Type, bool createGET, bool createSET, String Summary, Modifier AccessModifier ,Modifier Modifier)
            : this(Name, Type, createGET, createSET, Summary)
        {
            base.AccessModifier = AccessModifier;
            base.Modifier = Modifier;
        }

        /// <summary>
        /// Get  Encapsulations Property
        /// </summary>
        /// <returns></returns>
        public String getEncapsulationFied()
        {
            StringBuilder sb = new StringBuilder();

            /*complete example 
             private String _idAzienda;
            ///<summary>
            /// varchar(15) NOT NULL default '' COMMENT 'codice articolo',
            /// 
            /// get set idArticolo property
            /// </summary> 
            public String idArticolo
            {
                get { return this._idArticolo; }
                set { this._idArticolo = value; }
            }
             */

            #region private property

            //private String _idAzienda;
            sb.Append(Environment.NewLine + ListAccessModifiers.PRIVATE.Value + " " + base.Modifier.Value + " " +this.Type + " _" + this.Name + ";");

            #endregion

            #region Xmldocumentation

            //if (_xmlDocumentation.Summary==null || _xmlDocumentation.Summary.Length == 0)
            //{
            //    StringBuilder sb1 = new StringBuilder();
            //    if (this._createGET)
            //        sb1.Append("Get ");
            //    if (this._createSET)
            //        sb1.Append("Set ");
            //    if (this._createGET || this._createSET)
            //    {
            //        sb1.Append("the " + base.Name + " property.");
            //    }
            //    _xmlDocumentation.Summary = sb1.ToString();
            
            //    if (_description != null)
            //    {
            //        _xmlDocumentation.Value=(_description);
            //    }
              
            //   }
            //sb.Append(_xmlDocumentation.getXmlDocumentation().Replace("///", "///"));
             #endregion

            #region Encapsulations Property
            /*
             * public String idArticolo
                {
                    get { return this._idArticolo; }
                    set { this._idArticolo = value; }
                }
             */
            //public String idArticolo
            sb.Append(Environment.NewLine + ListAccessModifiers.PUBLIC.Value + " " + base.Modifier.Value + " " + this.Type + " " + this.Name);
            sb.Append(Environment.NewLine + "{");
            if (this._createGET)
                sb.Append(Environment.NewLine + "\tget { return this._" + this.Name + "; }");

            if (this._createSET)
                sb.Append(Environment.NewLine + "\tset { this._" + this.Name + " = value; }");

            sb.Append(Environment.NewLine + "}");
            #endregion

            return sb.ToString();
        }

        public String getProperty()
        {
            StringBuilder sb = new StringBuilder();

            /*complete example 
             private String _idAzienda;
            ///<summary>
            /// varchar(15) NOT NULL default '' COMMENT 'codice articolo',
            /// 
            /// get set idArticolo property
            /// </summary> 
            public String idArticolo
            {
                get { return this._idArticolo; }
                set { this._idArticolo = value; }
            }
             */


            #region Xmldocumentation

            //if (_xmlDocumentation.Summary==null || _xmlDocumentation.Summary.Length == 0)
            //{
            //    StringBuilder sb1 = new StringBuilder();
            //    if (this._createGET)
            //        sb1.Append("Get ");
            //    if (this._createSET)
            //        sb1.Append("Set ");
            //    if (this._createGET || this._createSET)
            //    {
            //        sb1.Append("the " + base.Name + " property.");
            //    }
            //    _xmlDocumentation.Summary = sb1.ToString();

            //    if (_description != null)
            //    {
            //        _xmlDocumentation.Value=(_description);
            //    }

            //   }
            //sb.Append(_xmlDocumentation.getXmlDocumentation().Replace("///", "///"));
            #endregion

            #region Encapsulations Property
            /*
             * public String idArticolo
                {
                    get { return this._idArticolo; }
                    set { this._idArticolo = value; }
                }
             */
            //public String idArticolo
            sb.Append(Environment.NewLine + ListAccessModifiers.PUBLIC.Value + " " + base.Modifier.Value + " " + this.Type + " " + this.Name);
            sb.Append(Environment.NewLine + "{");
            if (this._createGET)
                sb.Append(Environment.NewLine + "\tget { return; }");

            if (this._createSET)
                sb.Append(Environment.NewLine + "\tset { value; }");

            sb.Append(Environment.NewLine + "}");
            #endregion

            return sb.ToString();
        }


        public String getConstructorPropertyString()
        {
            StringBuilder sb = new StringBuilder();
        //        sb.Append(Environment.NewLine + "\tthis._" +  this.Name + " = " +  this.Name + "_Param;");
            return sb.ToString();
        }

        public String getConstructorPropertyStringReader()
        {
            StringBuilder sb = new StringBuilder();

            ////incapsutated field
            //    switch (this.Type)
            //    {
            //        case ("Byte[]"):
            //            sb.Append(Environment.NewLine + "\t#region set property " + this.Name);
            //            sb.Append(Environment.NewLine + "\ttry");
            //            sb.Append(Environment.NewLine + "\t{");
            //            sb.Append(Environment.NewLine + "\t\tif (!reader.IsDBNull(reader.GetOrdinal(\"" + this.Name + "\")))");
            //            sb.Append(Environment.NewLine + "\t\t{");
            //            sb.Append(Environment.NewLine + "\t\t\tthis._" + this.Name + " = (Byte[])reader.GetValue(reader.GetOrdinal(\"" + this.Name + "\"));");
            //            sb.Append(Environment.NewLine + "\t\t}");
            //            sb.Append(Environment.NewLine + "\t\telse");
            //            sb.Append(Environment.NewLine + "\t\t{");
            //            sb.Append(Environment.NewLine + "\t\t\tthis._" + this.Name + " = null;");
            //            sb.Append(Environment.NewLine + "\t\t}");
            //            sb.Append(Environment.NewLine + "\t}");
            //            sb.Append(Environment.NewLine + "\tcatch (InvalidCastException)");
            //            sb.Append(Environment.NewLine + "\t{");
            //            sb.Append(Environment.NewLine + "\t\tthis._" + this.Name + " = null;");
            //            sb.Append(Environment.NewLine + "\t}");
            //            sb.Append(Environment.NewLine + "\t#endregion");
            //            break;
            //        case ("UInt32"):
            //            //(uint)reader.GetInt32
            //            sb.Append(Environment.NewLine + "\tthis._" + this.Name + " = (uint)reader.GetInt32(reader.GetOrdinal(\"" + this.Name + "\"));");
            //            break;
            //        default:
            //            //aggiustare il GetString con il corrispettivo tipo
            //            // sb.Append(Environment.NewLine + "\tthis._" + this.Name + " = reader.Get" + this.Type.Replace("[]", "") + "(reader.GetOrdinal(\"" + this.Name + "\"));");
            //            //sb.Append(Environment.NewLine + "\tthis._" + this.Name + " = reader.Get" + this.Type.Replace("[]", "") + "(reader.GetOrdinal(\"" + this.Name + "\"));");
            //            sb.Append(Environment.NewLine + "\tthis._" + this.Name + " = reader.GetValue(reader.GetOrdinal(\"" + this.Name + "\")) == DBNull.Value ? default(" + this.Type.Replace("[]", "") + ") : (" + this.Type.Replace("[]", "") + ")reader.GetValue(reader.GetOrdinal(\"" + this.Name + "\"));");
            //            break;
            //    }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.getProperty());
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
        
    }   

}
