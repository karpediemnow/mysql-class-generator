using System;
using System.Collections.Generic;
using System.Text;
using ClassModellator.ModifierManager;

namespace ClassModellator.Class
{
    public class FieldModelletor: VariableModellator
    {
        XmlDocumentationModellator _xmlDocumentation;

        public XmlDocumentationModellator XmlDocumentation
        {
            get { return _xmlDocumentation; }
            set { _xmlDocumentation = value; }
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



        public FieldModelletor()
            : base()
        {
            _xmlDocumentation = new XmlDocumentationModellator();

        }

        public FieldModelletor(String Type, String Name)
            : base( Type,  Name)
        {
            _xmlDocumentation = new XmlDocumentationModellator();
            _modifier = new Modifier(String.Empty, null);
            _accessModifier = ListAccessModifiers.PUBLIC;
                
        }


        public FieldModelletor(String Type_Param, String Name_Param, string Description_Param)
            : base(Type_Param, Name_Param, Description_Param)
        {
            _xmlDocumentation = new XmlDocumentationModellator();
            _xmlDocumentation.Summary = Description_Param;
            _accessModifier = ListAccessModifiers.PUBLIC;
            _modifier = new Modifier(String.Empty, null);
        }
        
        public FieldModelletor(String Type_Param, String Name_Param, Modifier AccessMofifier)
            : base(Type_Param, Name_Param)
        {
            _xmlDocumentation = new XmlDocumentationModellator();
            _accessModifier = AccessMofifier;
            _modifier = new Modifier(String.Empty, null);
        }
        
        public FieldModelletor(String Type_Param, String Name_Param, Modifier AccessMofifier,Modifier Modifier)
            : base(Type_Param, Name_Param)
        {
            _xmlDocumentation = new XmlDocumentationModellator();
            _accessModifier = AccessMofifier;
            _modifier = Modifier;
        }

        public override string ToString()
        {
            //private static int x;
            return String.Format("{0} {1} {2} {3};", _accessModifier.Value, _modifier.Value, this.Type, this.Name);
        }
    }
}
