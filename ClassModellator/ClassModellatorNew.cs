using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ClassModellator.ModifierManager;
using ClassModellator.Static;
using ClassModellator.Class;
using ClassModellator.Interface;


namespace ClassModellator
{ 
    public class ClassModellatorNew
    {
        String _className;

        public String ClassName
        {
            get { return _className; }
            set { _className = value; }
        }
        Modifier _accessModifier;

        public Modifier AccessModifier
        {
            get { return _accessModifier; }
            set { _accessModifier = value; }
        }

        Modifier _modifier;

        public Modifier Modifier
        {
            get { return _modifier; }
            set { _modifier = value; }
        }

        List<FieldModelletor> _listFields;

        public List<FieldModelletor> ListFields
        {
            get { return _listFields; }
            set { _listFields = value; }
        }

        List<IPropertyModellator> _listProperties;

        public List<IPropertyModellator> ListProperties
        {
            get { return _listProperties; }
            set { _listProperties = value; }
        }

        List<MethodModellatorNew> _listMethods;

        public List<MethodModellatorNew> ListMethods
        {
            get { return _listMethods; }
            set { _listMethods = value; }
        }


        //List<StaticFieldModelletor> _listStaticFields;

        //public List<StaticFieldModelletor> ListStaticFields
        //{
        //    get { return _listStaticFields; }
        //    set { _listStaticFields = value; }
        //}

        List<StaticPropertyModellator> _listStaticProperties;

        public List<StaticPropertyModellator> ListStaticProperties
        {
            get { return _listStaticProperties; }
            set { _listStaticProperties = value; }
        }

        List<StaticMethodModellator> _listStaticMethods;

        public List<StaticMethodModellator> ListStaticMethods
        {
            get { return _listStaticMethods; }
            set { _listStaticMethods = value; }
        }


        public ClassModellatorNew(String ClassName)
        {
            _className = ClassName;
            _modifier = new Modifier();
            _accessModifier = ListAccessModifiers.PUBLIC;
            this._listFields = new List<FieldModelletor>();
            _listProperties = new List<IPropertyModellator>();
            _listMethods = new List<MethodModellatorNew>();
            //_listStaticFields = new List<StaticFieldModelletor>();
            _listStaticMethods = new List<StaticMethodModellator>();
            _listStaticProperties = new List<StaticPropertyModellator>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_className.Length > 0)
            {
                sb.Append(Environment.NewLine + this._accessModifier.Value + " " + _modifier.Value + " " + _className);
                sb.Append(Environment.NewLine+"{");
                sb.Append(Environment.NewLine + "\t");
             
                #region fields
                sb.Append(Environment.NewLine + "\t#region fields");
                foreach (FieldModelletor fm in _listFields)
                {
                    sb.Append(Environment.NewLine + "\t" + fm.ToString().Replace(Environment.NewLine,Environment.NewLine+"\t"));
                }
                sb.Append(Environment.NewLine + "\t#endregion");
                #endregion

                #region Static fields
                //sb.Append(Environment.NewLine + "\t#region Static fields");
                //foreach (StaticFieldModelletor fm in _listStaticFields)
                //{
                //    sb.Append(Environment.NewLine + "\t" + fm.ToString());
                //}
                //sb.Append(Environment.NewLine + "\t#endregion");
                #endregion

                
                sb.Append(Environment.NewLine + "\t");
                
                #region Propertties
                sb.Append(Environment.NewLine + "\t#region Encapsulated Fiels - Properties");
                foreach (IPropertyModellator fm in _listProperties)
                {
                    sb.Append(Environment.NewLine + "\t" + fm.ToString().Replace(Environment.NewLine, Environment.NewLine + "\t"));
                }
                #endregion

                #region properties
                //come encapsulated Fiels ma senza un field privato di riferimento 
                #endregion

                sb.Append(Environment.NewLine + "\t#endregion");
                
                
                sb.Append(Environment.NewLine + "\t");

                #region Methods
                sb.Append(Environment.NewLine + "\t#region Methods");
                
                foreach (MethodModellatorNew fm in _listMethods)
                {
                    sb.Append(Environment.NewLine + "\t" + fm.ToString().Replace(Environment.NewLine, Environment.NewLine + "\t"));
                }
                sb.Append(Environment.NewLine + "\t#endregion");
                #endregion

                sb.Append(Environment.NewLine + "\t");
                
              
                sb.Append(Environment.NewLine + "\t");

                #region Static Propertties
                sb.Append(Environment.NewLine + "\t#region Static Propertties");
                foreach (StaticPropertyModellator fm in _listStaticProperties)
                {
                    sb.Append(Environment.NewLine + "\t" + fm.ToString());
                }
                sb.Append(Environment.NewLine + "\t#endregion");
                #endregion

                sb.Append(Environment.NewLine + "\t");

                #region Static Methods
                sb.Append(Environment.NewLine + "\t#region Static Methods");
                foreach (StaticMethodModellator fm in _listStaticMethods)
                {
                    sb.Append(Environment.NewLine + "\t" + fm.ToString());
                }
                sb.Append(Environment.NewLine + "\t#endregion");
                #endregion


                sb.Append(Environment.NewLine + "}");
                
            }
            else
            {
                throw new ArgumentException("The ClassName Parameter is null");
            }
            return sb.ToString();
        }
    }
}