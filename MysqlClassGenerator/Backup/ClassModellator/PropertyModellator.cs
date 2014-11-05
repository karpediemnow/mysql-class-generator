using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator
{
    public class PropertyModellator:VariableModellator
    {
        private String _description;
        private Boolean _createSET;
        private Boolean _createGET;
        private Boolean _isNullable;
        private String _default;
        object _tag;

        private string _modifier;

        /// <summary>
        /// esempio static 
        /// </summary>
        public string Modifier
        {
            get { return _modifier; }
            set { _modifier = value; }
        }


        XmlDocumentationModellator _xmlDocumentation;

        /// <summary>
        /// get or set Object
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Summary of property
        /// </summary>
        public String Description
        {
            get { return _description; }
            set { _description = value; }
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
        /// Default Value
        /// </summary>
        public String Default
        {
            get { return _default; }
            set { _default = value; }
        }


        /// <summary>
        /// default contructor
        /// </summary>
        public PropertyModellator()
        {
            this._createGET = true;
            this._createSET = true;
            base.Name = null;
            base.Type = null;
            this._isNullable = true;
            _default = "null";
            _modifier = null ;
            _xmlDocumentation = new XmlDocumentationModellator();
        }

        /// <summary>
        /// contructor whith 2 parameters
        /// </summary>
        /// <param name="Name">Name of property</param>
        /// <param name="Type">Type of property</param>
        public PropertyModellator(String Name, String Type)
            : this()
        {
            this.Name = Name;
            this.Type = Type;
        }

        public PropertyModellator(String Name, String Type, bool createGET, bool createSET)
            : this(Name,Type)
        {
            this._createGET = createGET;
            this._createSET = createSET;
        }

        public PropertyModellator(String Name, String Type, String Summary, bool createGET, bool createSET)
            : this( Name, Type, createGET, createSET)
        {
            //this.Name = Name;
            //this.Type = Type;
            this._description = Summary;
            //this._createGET = createGET;
            //this._createSET = createSET;

            _xmlDocumentation = new XmlDocumentationModellator();
        }

        public PropertyModellator(String Name, String Type,String Modifier, String Summary, bool createGET, bool createSET)
            : this( Name,  Type,  Summary,  createGET,  createSET)
        {
            _modifier = Modifier;
        }


        /// <summary>
        /// Get  Encapsulations Property
        /// </summary>
        /// <returns></returns>
        public String getEncapsulationsProperty()
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
            sb.Append("\t\tprivate " + _modifier + " " + base.Type + " _" + base.Name + ";" + Environment.NewLine);

            #endregion

            #region Xmldocumentation

            if (_xmlDocumentation.Summary==null || _xmlDocumentation.Summary.Length == 0)
            {
                StringBuilder sb1 = new StringBuilder();
                if (this._createGET)
                    sb1.Append("Get ");
                if (this._createSET)
                    sb1.Append("Set ");
                if (this._createGET || this._createSET)
                {
                    sb1.Append("the " + base.Name + " property.");
                }
                _xmlDocumentation.Summary = sb1.ToString();
            
                if (_description != null)
                {
                    _xmlDocumentation.Value=(_description);
                }
              
               }
            sb.Append(_xmlDocumentation.getXmlDocumentation().Replace("///", "\t\t///"));
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
            sb.Append("\t\tpublic " + _modifier + " " + base.Type + " " + base.Name + "" + Environment.NewLine);
            sb.Append("\t\t{"+Environment.NewLine);
            if (this._createGET)
                sb.Append("\t\t\tget { return this._" + base.Name + "; }" + Environment.NewLine);

            if (this._createSET)
                sb.Append("\t\t\tset { this._" + base.Name + " = value; }" + Environment.NewLine);

            sb.Append("\t\t}"+Environment.NewLine+Environment.NewLine);
            #endregion

            return sb.ToString();
        }

        public String getConstructorPropertyString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\t\tthis._" + base.Name + " = " + this.Name + "_Param;" + Environment.NewLine);
            return sb.ToString();
        }

        public String getConstructorPropertyStringReader()
        {
            StringBuilder sb = new StringBuilder();
            switch (this.Type)
            {
                case ("Byte[]"):
                    sb.Append("\t\t\t#region set property " + this.Name + "" + Environment.NewLine);
                    sb.Append("\t\t\ttry" + Environment.NewLine);
                    sb.Append("\t\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\t\tif (!reader.IsDBNull(reader.GetOrdinal(\"" + this.Name + "\")))" + Environment.NewLine);
                    sb.Append("\t\t\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\t\t\tthis._" + this.Name + " = (Byte[])reader.GetValue(reader.GetOrdinal(\"" + this.Name + "\"));" + Environment.NewLine);
                    sb.Append("\t\t\t\t}" + Environment.NewLine);
                    sb.Append("\t\t\t\telse" + Environment.NewLine);
                    sb.Append("\t\t\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\t\t\tthis._" + this.Name + " = null;" + Environment.NewLine);
                    sb.Append("\t\t\t\t}" + Environment.NewLine);
                    sb.Append("\t\t\t}" + Environment.NewLine);
                    sb.Append("\t\t\tcatch (InvalidCastException)" + Environment.NewLine);
                    sb.Append("\t\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\t\tthis._" + this.Name + " = null;" + Environment.NewLine);
                    sb.Append("\t\t\t}" + Environment.NewLine);
                    sb.Append("\t\t\t#endregion" + Environment.NewLine);
                    break;
                case ("UInt32"):
                    //(uint)reader.GetInt32
                    sb.Append("\t\t\tthis._" + this.Name + " = (uint)reader.GetInt32(reader.GetOrdinal(\"" + this.Name + "\"));" + Environment.NewLine);
                    break;
                default:
                    //aggiustare il GetString con il corrispettivo tipo
                    // sb.Append("\t\t\tthis._" + this.Name + " = reader.Get" + this.Type.Replace("[]", "") + "(reader.GetOrdinal(\"" + this.Name + "\"));" + Environment.NewLine);
                    //sb.Append("\t\t\tthis._" + this.Name + " = reader.Get" + this.Type.Replace("[]", "") + "(reader.GetOrdinal(\"" + this.Name + "\"));" + Environment.NewLine);
                    sb.Append("\t\t\tthis._" + this.Name + " = reader.GetValue(reader.GetOrdinal(\"" + this.Name + "\")) == DBNull.Value ? default(" + this.Type.Replace("[]", "") + ") : (" + this.Type.Replace("[]", "") + ")reader.GetValue(reader.GetOrdinal(\"" + this.Name + "\"));" + Environment.NewLine);
                    break;
            }

            return sb.ToString();
        }

       
        
    }   

}
