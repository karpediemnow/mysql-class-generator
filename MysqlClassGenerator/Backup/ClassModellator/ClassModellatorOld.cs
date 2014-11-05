using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ClassModellator.ModifierManager;
using ClassModellator.Class;


namespace ClassModellator
{ 

    public class ClassModellatorOld
    {
        #region Poperty and associated field

        XmlDocumentationModellator _xmlDocument;

        internal XmlDocumentationModellator XmlDocument
        {
            get { return _xmlDocument; }
            set { _xmlDocument = value; }
        }
        List<String> _listUsing;

        public List<String> ListUsing
        {
            get { return _listUsing; }
            set { _listUsing = value; }
        }


        //String _pathToSave;
         String _name;
         String _Description;
         String _accessModifier;
         List<PropertyModellator> _listProperties;

         /// <summary>
         /// list of property (Coulomn of database Schema)
         /// </summary>
         public virtual List<PropertyModellator> ListProperties
         {
             get { return _listProperties; }
             set { _listProperties = value; }
         }

         List<functionModellator> _listMethods;

         public List<functionModellator> ListMethods
         {
             get { return _listMethods; }
             set { _listMethods = value; }
         }

         private List<FieldModelletor> _listFields;
         public List<FieldModelletor> ListFields
         {
             get { return _listFields; }
             set { _listFields = value; }
         }

        String _namespace;

        /// <summary>
        /// Namespace to use (default Class) 
        /// </summary>
        public String NameSpace
        {
            get {
                string nm;
                if (_namespace == null || _namespace.Length == 0)
                {
                    nm = "Class";
                }
                else
                {
                    nm = _namespace;
                }
                return nm;            
            }
            set { _namespace = value; }
        }

       

        /// <summary>
        /// The name of the table to model
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Optinal Property write the Summary class
        /// </summary>
        public String Description
        {
            get
            {
                if (this._Description == null)
                {
                    string returnStr = "Modellation of a DataTableSchema ";
                    if (this._name != null)
                    {
                        returnStr += this._name;
                    }
                    return returnStr;
                }
                else
                    return _Description;

            }
            set { _Description = value; }
        }

        

        /// <summary>
        /// scope of class default public
        /// 
        /// </summary>
        public String AccessModifier
        {
            get { return _accessModifier; }
            set { _accessModifier = value; }
        }


        public String FileName
        {
            get
            {
                if (_name != null)
                {
                    return _name + ".cs";
                }
                else
                {
                    throw new Exception("The property Name is not set");
                }
            }
        }

        //public String PathToSave
        //{
        //    get
        //    {
        //        //if (_pathToSave.Trim().Length != 0)
        //        //{
        //            return _pathToSave;
        //        //}
        //        //else
        //        //{
        //        //    string tmp = System.IO.Path.GetTempPath();
        //        //    return tmp.Substring(0, tmp.Length - 2);
        //        //}
        //    }
        //    set { _pathToSave = value; }
        //}

        #endregion
        
        public ClassModellatorOld()
        {
            this._name = null;
            this._Description = null;
            this._accessModifier = ListAccessModifiers.PUBLIC.Value;
            this._namespace = "Class";
            //this._pathToSave = "";
            this._listProperties = new List<PropertyModellator>();
            this._listMethods = new List<functionModellator>();
            this._listFields = new List<FieldModelletor>();
            _xmlDocument = new XmlDocumentationModellator();
            _listUsing = new List<string>();
            this.setdefaultsUsing();
        }

        public ClassModellatorOld(String OutputNameClass)
        {
            this._name = OutputNameClass;
            this._Description = null;
            this._accessModifier = "public";
            this._namespace = "Class";
            //this._pathToSave = "";
            this._listProperties = new List<PropertyModellator>();
            _listMethods = new List<functionModellator>();
            _xmlDocument = new XmlDocumentationModellator();
            _listUsing = new List<string>();
            this.setdefaultsUsing();
        }
       

        protected void reset()
        {
            _listMethods.Clear();
            _listProperties.Clear();
            _name =_namespace = _accessModifier = _Description = string.Empty;
            _xmlDocument = new XmlDocumentationModellator();
            this.setdefaultsUsing(); 
        }

        protected void setdefaultsUsing()
        {
            _listUsing.Clear();
            _listUsing.Add("System");
            _listUsing.Add("System.Collections.Generic");
            _listUsing.Add("System.Text");
        }


        /// <summary>
        /// Add property by mame and Type
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        public void addProperty(String Name, String Type)
        {
            this._listProperties.Add(new PropertyModellator(Name, Type));
        }

        /// <summary>
        /// return the string that conetin class 
        /// </summary>
        /// <returns></returns>
        public virtual String getClassModellated() {
            StringBuilder outputString= new StringBuilder();
            if (this._name != null)
            {
                try
                {
                    outputString.Append(this.getHeader(null, true));

                    outputString.Append("\t\t#region Property incapsultation"+Environment.NewLine+Environment.NewLine);
                    foreach (PropertyModellator pm in _listProperties)
                    {
                        outputString.Append(pm.getEncapsulationsProperty());
                    }
                    outputString.Append("\t\t#endregion"+Environment.NewLine+Environment.NewLine);


                    outputString.Append("\t\t#region Costructor"+Environment.NewLine+Environment.NewLine);
                    outputString.Append(this.getDefaultCostructor());
                    outputString.Append(this.getCostructorWithAllProperty());
                    outputString.Append("\t\t#endregion"+Environment.NewLine+Environment.NewLine);
                    outputString.Append(this.getFoter());
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

        //public virtual void writeClass()
        //{
        //    if (this._name != null)
        //    {
               
        //        StreamWriter sw = File.CreateText(this.PathToSave +"\\"+ this.FileName);

        //        try
        //        {
        //            sw.Write(this.getHeader());

        //            sw.Write("\t\t#region Property incapsultation"+Environment.NewLine+Environment.NewLine);
        //            foreach (PropertyModellator pm in _listProperty)
        //            {
        //                sw.Write(pm.getEncapsulationsProperty());
        //            }
        //            sw.Write("\t\t#endregion"+Environment.NewLine+Environment.NewLine);


        //            sw.Write("\t\t#region Costructor"+Environment.NewLine+Environment.NewLine);
        //            sw.Write(this.getCostructor());
        //            sw.Write(this.getCostructorLine());
        //            //sw.Write(this.getCostructorReader());
        //            sw.Write("\t\t#endregion"+Environment.NewLine+Environment.NewLine);


        //            sw.Write(this.getFoter());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw (ex);
        //        }
        //        finally
        //        {
        //            sw.Close();
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("The property Name is not set");
        //    }

        //}

        protected virtual string getUsing()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _listUsing.Count; i++)
            {
                if (_listUsing[i].Trim().Length != 0)
                {
                    sb.Append("using " + _listUsing[i] + ";" + Environment.NewLine);
                }
                else
                {
                    sb.Append(Environment.NewLine);
                }
            }
            sb.Append(Environment.NewLine);            
            return sb.ToString();
        }

        protected virtual string getHeader(String Comment,Boolean inAppend )
        {/*
          * using System;
          * using System.Collections.Generic;
          * using System.Text;
          * 
          * namespace MysqlModellator
          * {
          * public class ClassModellator
          * {
          */
            StringBuilder sb = new StringBuilder();
            sb.Append(this.getUsing());
            sb.Append("namespace " + this.NameSpace + ""+Environment.NewLine);
            sb.Append("{"+Environment.NewLine);

            if (_xmlDocument.Summary == null || _xmlDocument.Summary.Length == 0)
            {
                _xmlDocument.Summary = "MySQL Data Base Table Modellator " + Environment.NewLine ;
                if (_Description != null)
                {
                    _xmlDocument.Summary += _Description;
                }                
            }

            if (!inAppend)
            {
                _xmlDocument.Summary = Environment.NewLine + " " + Comment + Environment.NewLine;
            
            }
            else
            {
                _xmlDocument.Summary += Environment.NewLine + " " + Comment + Environment.NewLine;
            }
            
            sb.Append(_xmlDocument.getXmlDocumentation().Replace("///", "\t///"));
            sb.Append("\t" + _accessModifier + " class " + this._name);
            sb.Append(Environment.NewLine+"\t{"+Environment.NewLine+Environment.NewLine);

            return sb.ToString();

        }

        protected virtual string getDefaultCostructor()
        {
            /*public NAME()
             * {
             * 
             * }
             */
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\tpublic " + this._name + "()"+Environment.NewLine);
            sb.Append("\t\t{"+Environment.NewLine);
            sb.Append("\t\t\t"+Environment.NewLine);
            sb.Append("\t\t}"+Environment.NewLine+Environment.NewLine);

            return sb.ToString();

        }

        protected string getCostructorWithAllProperty()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\t\tpublic " + this._name + "(");

            PropertyModellator pm;
            for (int i = 0; i < _listProperties.Count - 1; i++)
            {
                pm = _listProperties[i];
                sb.Append(pm.Type + " " + pm.Name + "_Param, ");
            }
            pm = _listProperties[_listProperties.Count - 1];
            sb.Append(pm.Type + " " + pm.Name + "_Param");
            sb.Append(")"+Environment.NewLine);

            sb.Append("\t\t{"+Environment.NewLine);
            sb.Append("\t\t\t#region constructor " + this._name + ""+Environment.NewLine);            
            foreach (PropertyModellator pm1 in _listProperties)
            {
                sb.Append(pm1.getConstructorPropertyString());
            }
            sb.Append("\t\t\t#endregion"+Environment.NewLine);
            sb.Append("\t\t}"+Environment.NewLine+Environment.NewLine);
            
            return sb.ToString();
        }


        protected string getCostructorWithAllPropertyAndStr(List<String> listStrToAdd)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\t\tpublic " + this._name + "(");

            PropertyModellator pm;
            for (int i = 0; i < _listProperties.Count - 1; i++)
            {
                pm = _listProperties[i];
                sb.Append(pm.Type + " " + pm.Name + "_Param, ");
            }
            pm = _listProperties[_listProperties.Count - 1];
            sb.Append(pm.Type + " " + pm.Name + "_Param");
            sb.Append(")" + Environment.NewLine);

            sb.Append("\t\t{" + Environment.NewLine);
            sb.Append("\t\t\t#region constructor " + this._name + "" + Environment.NewLine);
            foreach (PropertyModellator pm1 in _listProperties)
            {
                sb.Append(pm1.getConstructorPropertyString());
            }

            foreach (string s in listStrToAdd)
            {
                sb.Append("\t\t\t" + s + Environment.NewLine);
            }

            sb.Append("\t\t\t#endregion" + Environment.NewLine);
            sb.Append("\t\t}" + Environment.NewLine + Environment.NewLine);

            return sb.ToString();
        }

        protected string getResetFunction()
        {
            functionModellator tmp = new functionModellator();
            tmp.Description = "Reset All property";
            tmp.AccessModifier = "public";
            tmp.Name = "reset";
            tmp.Type = "void";

            StringBuilder sb = new StringBuilder();
            PropertyModellator pm;
            for (int i = 0; i < _listProperties.Count - 1; i++)
            {
                pm = _listProperties[i];
                sb.Append("this._" + pm.Name + " =  default(" + pm.Type + ");" + Environment.NewLine);
            }
            
            tmp.Body = sb.ToString();

            return tmp.functionModellatorString();
        }

        
        protected string getFoter()
        {

            return "\t}"+Environment.NewLine+"}"+Environment.NewLine;
        }

        
    }
}