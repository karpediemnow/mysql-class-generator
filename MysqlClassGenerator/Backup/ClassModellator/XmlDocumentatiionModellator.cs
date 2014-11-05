using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ClassModellator
{
    /// <summary>
    /// http://msdn.microsoft.com/it-it/library/5ast78ax(VS.80).aspx
    /// </summary>
    public class XmlDocumentationModellator
    {
        /*
         
      <param name="name"> permette di specificare i parametri passati ad un metodo 
<paramref name="name"> permette di specificare che una determinata parola è un parametro 
<returns> il valore di ritorno del metodo 
<exceptions cref="type"> permette di specifire le eccezioni che possono verificarsi 
<permission cref="type"> permette di specificare il livello di accesso 
<value> consente di descrivere una proprietà 
<example> specifica un esempio relativo all’utilizzo del codice 
<c>  il testo deve essere identificato come codice 
<code> più righe devono essere identificato come codice 
<para> Si può inserire all’interno di alcuni tag come <summary>, <remarks> o <returns>, e permette di aggiungere una struttura al testo. 

         */

        #region encapsulated property
        private String _summary;
        /// <summary>
        ///  Una descrizione generica di un metodo, una classe o altro 
        /// </summary>
        public String Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        private List<xmlDocListModellator> _listList;

        public List<xmlDocListModellator> List
        {
            get { return _listList; }
            set { _listList = value; }
        }

        private List<xmlIncludeModellator> _includeList;

        public List<xmlIncludeModellator> Include
        {
            get { return _includeList; }
            set { _includeList = value; }
        }

        private String _remarks;
        /// <summary>
        /// informazioni addizionali
        /// </summary>
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private List<xmlParamNameMolellator> _paramNameList;

        public List<xmlParamNameMolellator> ParamName
        {
            get { return _paramNameList; }
            set { _paramNameList = value; }
        }

        //private Hashtable _paramref;
    
        //public Hashtable Paramref
        //{
        //    get { return _paramref; }
        //    set { _paramref = value; }
        //}
        private string _returns;

        public string Returns
        {
            get { return _returns; }
            set { _returns = value; }
        }
        private List<xmlDoxExcepionModellator> _exceptionsList;

        public List<xmlDoxExcepionModellator> Exceptions
        {
            get { return _exceptionsList; }
            set { _exceptionsList = value; }
        }
        private String _permission;

        public String Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
        private String _value;

        public String Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _example;

        public string Example
        {
            get { return _example; }
            set { _example = value; }
        }

        //private String _c;

        //public String C
        //{
        //    get { return _c; }
        //    set { _c = value; }
        //}

        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        //private string _para;

        //public string Para
        //{
        //    get { return _para; }
        //    set { _para = value; }
        //}
        #endregion

        #region costructor
        public XmlDocumentationModellator()
        {
            _paramNameList = new List<xmlParamNameMolellator>();
            _exceptionsList = new List<xmlDoxExcepionModellator>();
            _listList = new List<xmlDocListModellator>();
            _includeList = new List<xmlIncludeModellator>();

            
        }
        #endregion


        #region public functions

        public void setParamName(List<VariableModellator> listaVariabili)
        {
            foreach (VariableModellator var in listaVariabili)
            {
                _paramNameList.Add(new xmlParamNameMolellator( var.Name, var.Description));
            }
        }



        public string getXmlDocumentation()
        {
            StringBuilder sb = new StringBuilder();

            #region summary
            if (_summary != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append("/// <summary>" + Environment.NewLine);
                sb.Append("/// " + _summary.Replace("\r", String.Empty).Replace("\n", Environment.NewLine + "///") + Environment.NewLine);
                sb.Append("/// </summary>" + Environment.NewLine);

                foreach (xmlDocListModellator list in _listList)
                {
                    sb.Append(list.ToString());
                }
            }
            #endregion

            #region remarks
            if (_remarks != null && _remarks.Length != 0)
            {
                sb.Append("/// <remarks>" + Environment.NewLine);
                sb.Append("/// " + _remarks.Replace("\r",String.Empty).Replace("\n", Environment.NewLine + "///") + Environment.NewLine);
                sb.Append("/// </remarks>" + Environment.NewLine);
            }
            #endregion

            #region include list

            foreach (xmlIncludeModellator include in _includeList)
            {
                sb.Append(include.ToString());
            }

            #endregion

            #region example / code
            if (_code != null && _code.Length != 0 && (_example == null || _example.Length == 0))
            {
                throw new ArgumentNullException("Example", "Attenction if set the Code param you can be set Example param");
            }
            else if (_example != null && _example.Length != 0)
            {
                sb.Append("/// <example> " + _example.Replace("\r",String.Empty).Replace("\n", Environment.NewLine + "///") + Environment.NewLine);
                if (_code != null && _code.Length != 0)
                {
                    sb.Append("/// <code>" + Environment.NewLine);
                    sb.Append("/// " + _code.Replace("\r",String.Empty).Replace("\n", Environment.NewLine + "///") + Environment.NewLine);
                    sb.Append("/// </code>" + Environment.NewLine);
                }
                sb.Append("/// </example>"+ Environment.NewLine);
            }
            #endregion

            #region param name
            foreach (xmlParamNameMolellator paramName in _paramNameList)
            {
                sb.Append(paramName.ToString());
            }
            #endregion

            #region exception
            foreach (xmlDoxExcepionModellator tmpEX in _exceptionsList){
               sb.Append(tmpEX.ToString());
                // sb.Append("/// <exception cref=\"" + tmpEX.CRefenence + "\">" + tmpEX.Description + "</exception>" + Environment.NewLine);
            }
            #endregion

            #region value
            if (_value != null && _value.Length != 0)
            {
                // /// <value>
                // /// The Name property gets/sets the _name data member.
                // /// </value>

                sb.Append("/// <value>" +Environment.NewLine);
                sb.Append("/// "+_value.Replace("\r",String.Empty).Replace("\n", Environment.NewLine + "///") +Environment.NewLine);
                sb.Append("/// </value>" + Environment.NewLine);
            }
            #endregion

            #region returns
            if (_returns != null && _returns.Length != 0)
            {
                sb.Append("/// <returns>" +Environment.NewLine);
                sb.Append("/// "+_returns.Replace("\r",String.Empty).Replace("\n", Environment.NewLine + "///") +Environment.NewLine);
                sb.Append("/// </returns>" + Environment.NewLine);
            }
            #endregion

            return sb.ToString();
        }

        #endregion
    }

    /// <summary>
    /// http://msdn.microsoft.com/it-it/library/w1htk11d(VS.80).aspx
    /// </summary>
    public class xmlDoxExcepionModellator
    {
        String _description;

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        String _cRefenence;

        public String CRefenence
        {
            get { return _cRefenence; }
            set { _cRefenence = value; }
        }
        public xmlDoxExcepionModellator()
        {
            _cRefenence = _description = null;
        }

        public override string  ToString()
        {
            return "\t/// <exception cref=\"" + _cRefenence.Replace("\n", String.Empty) + "\">" + _description.Replace("\n", String.Empty) + "</exception>" + Environment.NewLine;
        }
    }

    /// <summary>
    /// http://msdn.microsoft.com/it-it/library/y3ww3c7e(VS.80).aspx
    /// </summary>
    public class xmlDocListModellator
    {
        String _type;

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }

        List<string> _description;

        public List<string> Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public xmlDocListModellator()
        {
            _description = new List<string>();
            _type = String.Empty;
        }

        public override string ToString()
        {
            StringBuilder  sb = new StringBuilder();
            sb.Append("/// <list type=\"" + _type.Replace("\n"," ") + "\">" + Environment.NewLine);
            foreach (string tmpSTR in _description)
            {
                sb.Append("/// <item>" + Environment.NewLine);
                sb.Append("/// <description>" + tmpSTR.Replace("\n", Environment.NewLine + "\t///") + "</description>" + Environment.NewLine);
                sb.Append("/// </item>" + Environment.NewLine);
            }
            sb.Append("/// </list>"+Environment.NewLine);
            return sb.ToString();
        }
    }

    /// <summary>
    /// http://msdn.microsoft.com/it-it/library/9h8dy30z(VS.80).aspx
    /// </summary>
    public class xmlIncludeModellator
    {
        //Nome del file che contiene la documentazione. È possibile qualificare il nome del file tramite un percorso. Racchiudere filename tra virgolette singole (' ').
        String _filename;

        public String Filename
        {
            get { return _filename; }
            set { _filename = value; }
        } 
        
        //Percorso dei tag di filename che porta al name del tag. Racchiudere il percorso tra virgolette singole (' ').
        String _tagpath;

        public String Tagpath
        {
            get { return _tagpath; }
            set { _tagpath = value; }
        } 
        
        //Identificatore del nome contenuto nel tag che precede i commenti. name ha sempre un id.
        String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        } 
        
        //ID del tag che precede i commenti. Racchiudere l'ID tra virgolette doppie (" ").
        String _id;

        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public xmlIncludeModellator()
        {
            _filename = _id = _name = _tagpath = String.Empty;
        }

        public override string ToString()
        {
            return "<include file='" + _filename.Replace("\n",string.Empty) + "' path='" + _tagpath.Replace("\n", String.Empty) + "[@" + _name.Replace("\n",string.Empty) + "=\"" + _id + "\"]' />";
        }

    }

    /// <summary>
    /// http://msdn.microsoft.com/it-it/library/8cw818w8(VS.80).aspx
    /// </summary>
    public class xmlParamNameMolellator
    {
        // /// <param name="Int1">Used to indicate status.</param>

        //Nome di un parametro di metodo. Racchiudere il nome tra virgolette doppie (" ").
        String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        } 
        
        //Descrizione del parametro.
        String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public xmlParamNameMolellator()
        {
            _name = String.Empty;
            _description = String.Empty;
        }

        public xmlParamNameMolellator(String Name_Param ,String Description_Param )
        {
            _name = Name_Param;
            _description = Description_Param;
        }

        public override string ToString()
        {
            if (_description == null)
            {
                _description = " ";
            }
            return "/// <param name=\"" + _name.Replace("\n", String.Empty) + "\">" + _description.Replace("\n",string.Empty) + "</param>" + Environment.NewLine;
            
        }
    }

    /// <summary>
    /// http://msdn.microsoft.com/it-it/library/h9df2kfb(VS.80).aspx
    /// </summary>
    public class xmlPermissionMolellator
    {
        //<permission cref="member">description</permission>


        //Nome di un parametro di metodo. Racchiudere il nome tra virgolette doppie (" ").
        String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Descrizione del parametro.
        String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public xmlPermissionMolellator()
        {
            _name = _description =String.Empty;
        }

        public xmlPermissionMolellator(String Name_Param, String Description_Param)
        {
            _name = Name_Param;
            _description = Description_Param;
        }
        
        public override string ToString()
        {
            return "\t/// <permission cref=\"" + _name + "\">" + _description + "</permission>" + Environment.NewLine;
            
        }
    }

}
