using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using System.IO;

using System.Xml;

using ClassModellator;
using ClassModellator.MysqlClassModellator;
using ClassModellator.MysqlClassModellator.Informations;
using ClassModellator.MysqlClassModellator.CSharpSqlManager;
using ClassModellator.MysqlClassModellator.MysqlClassModellator;
using ClassModellator.MysqlClassModellator.DBConnectorModellator;
using ClassModellator.ModifierManager;

namespace MysqlClassGeneratorV2
{
    public partial class FormMain : Form
    {
        private MySqlConnection _conn;
        private DataTable _dataTable;
        private MySqlDataAdapter _dataAdapter;
        private MySqlCommandBuilder _commandBuilder;
        MysqlManagerClassModellator _mysqlManagerClassModellator;
        MysqlClass _mysqlClassModellator;
        TableInformations _tableInformations;
        private String _XmlFile;
        View _view;
           
        MysqlInformations _mysqlInf;

        public FormMain()
        {
            _view = new View();
            InitializeComponent();
            this._XmlFile = null;
            _mysqlInf = new MysqlInformations();
            this.valorzeTipeDriver();
            this.valorizeModifiers();
            this.inizializeForm();
            this.Text +=" Assembly version: "+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 

             //_mysqlClassModellator = new MysqlClass();
             //_manageClassModellator = new StandardClass();

        }

        private void inizializeForm()
        {
            server.Text = textBoxCnfServer.Text = MysqlClassGeneratorV2.Properties.Settings.Default.Server;
            userid.Text = textBoxCnfUserId.Text= MysqlClassGeneratorV2.Properties.Settings.Default.Username;
            password.Text = textBoxCnfPassword.Text= MysqlClassGeneratorV2.Properties.Settings.Default.Password;
            this.textBoxPort.Text = textBoxCnfPort.Text= MysqlClassGeneratorV2.Properties.Settings.Default.Port.ToString();
            this.textBoxCnfConnectionString.Text = MysqlClassGeneratorV2.Properties.Settings.Default.MysqlConnectionString;
            textBoxCnfConnectionOptions.Text = MysqlClassGeneratorV2.Properties.Settings.Default.MysqlConnectionStringOptions;
            

            this.txtPath.Text = Application.StartupPath;

        }
        ///// <summary>
        ///// Informazioni della tabelle tableName
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <returns></returns>
        //private ShowTableStatusModellator getShowTableStatus(String tableName)
        //{
        //    ShowTableStatusModellator item =null;
        //    MySqlCommand cmd = new MySqlCommand("Show table status like '" + tableName+"'", _conn);
        //    //SHOW FULL COLUMNS FROM t1
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    try
        //    {
        //        if (reader.Read()) {
        //            item = new ShowTableStatusModellator(reader);
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Failed to retrive Show Table Status table (" + tableName + "): " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //            reader.Close();
        //    }
        //    return item;
        //}

        ///// <summary>
        ///// Informazioni delle singole colonne del database
        ///// </summary>
        ///// <param name="tableName"></param>
        ///// <returns></returns>
        //private List<ShowFullColumnsModellator> getFullColumnsList(String tableName)
        //{
        //    List<ShowFullColumnsModellator> items = new List<ShowFullColumnsModellator>();
        //    MySqlCommand cmd = new MySqlCommand("SHOW FULL COLUMNS FROM " + tableName, _conn);
        //    //SHOW FULL COLUMNS FROM t1
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    try
        //    {

        //        while (reader.Read())
        //        {
        //            items.Add(new ShowFullColumnsModellator(reader));
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Failed to populate Full ColumnsList list: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //            reader.Close();
        //    }
        //    return items;

        //}

        ///// <summary>
        ///// Lista delle tabelle
        ///// </summary>
        ///// <param name="dataBaseName"></param>
        ///// <returns></returns>
        //private List<String> getListTable(String dataBaseName)
        //{
        //    List<String> items = new List<string>();
        //    MySqlDataReader reader = null;
        //    _conn.ChangeDatabase(dataBaseName);
        //    MySqlCommand cmd = new MySqlCommand("SHOW TABLES", _conn);
        //    try
        //    {
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            items.Add(reader.GetString(0));
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Failed to populate table list: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //            reader.Close();
        //    }
        //    return items;
        //}

        ///// <summary>
        ///// Lista database
        ///// </summary>
        ///// <returns></returns>
        //private List<String> getListDatabases()
        //{
        //    List<String> items = new List<string>();

        //    MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", _conn);
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    try
        //    {
        //        while (reader.Read())
        //        {
        //            items.Add(reader.GetString(0));
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Failed to populate database list: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }
        //    return items;
        //}

        //private string getCreateTableString(String tableName)
        //{
        //    string CT = "";

        //    MySqlDataReader reader = null;

        //    String q = "SHOW CREATE TABLE " + tableName ;
        //    MySqlCommand cmd = new MySqlCommand(q, _conn);
        //    try
        //    {
        //        reader = cmd.ExecuteReader();
        //        reader.Read();

        //        if (reader.HasRows)
        //        {
        //            CT = reader.GetString(1);
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Failed to populate database list: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }
        //    return CT;
        //}


        private void valorizeModifiers()
        {
            comboBoxModifiers.DataSource = ListAccessModifiers.toListString();
            comboBoxModifiers.SelectedIndex = 5;
        }

        private void valorzeTipeDriver()
        {
            List<TypeOfDriver> listaTypeOfDriver = new List<TypeOfDriver>();
            listaTypeOfDriver.Add(TypeOfDriver.MySqlDriver);
            listaTypeOfDriver.Add(TypeOfDriver.MySQLDriverCS);
            comboBoxTypeDrivedr.DataSource = listaTypeOfDriver;
        }

        private void bttConnect_Click(object sender, EventArgs e)
        {
            this.connectDisconnect();
        }



        private void databaseList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            tables.DataSource = null;
            tables.Items.Clear();
            //this.groupBoxFunction.Enabled = false;
            // buttonShoCreateTable.Enabled = false;
            if (databaseList.SelectedItem != null)
            {
                tables.DataSource = _mysqlInf.getListTable(databaseList.SelectedItem.ToString());
            }
        }

        private void tables_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //this.groupBoxFunction.Enabled = false;
            if (tables.SelectedItem != null)
            {
                _dataTable = new DataTable();

                _dataAdapter = new MySqlDataAdapter("SELECT * FROM " + tables.SelectedItem.ToString(), _conn);
                _commandBuilder = new MySqlCommandBuilder(_dataAdapter);

                _dataAdapter.Fill(_dataTable);

                dataGrid.DataSource = _dataTable;

                this.textBoxClassName.Text = this.tables.SelectedItem.ToString();
                
            }
            else
            {
                dataGrid.DataSource = null;
            }
        }

        private void updateBtn_Click(object sender, System.EventArgs e)
        {
            DataTable changes = _dataTable.GetChanges();
            _dataAdapter.Update(changes);
            _dataTable.AcceptChanges();
        }

        //private void tabPage2_Enter(object sender, EventArgs e)
        //{
        //    this.richTextBoxXmlSchema.Clear();
        //    if (this._XmlFile != null && File.Exists(this._XmlFile))
        //    {
        //        this.caricaXMLinRichTextBox(this._XmlFile);
        //    }
        //    else
        //        MessageBox.Show("Generate fist XML File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //private void tabPageTreeView_Enter(object sender, EventArgs e)
        //{
        //    this.richTextBoxXmlSchema.Clear();
        //    if (this._XmlFile != null && File.Exists(this._XmlFile))
        //    {
        //        this.caricaXmlInTreeView(this._XmlFile);
        //    }
        //    else
        //        MessageBox.Show("Generate fist XML File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        //}

        //private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        //{
        //    XmlNode xNode;
        //    TreeNode tNode;
        //    XmlNodeList nodeList;
        //    int i;

        //    // Loop through the XML nodes until the leaf is reached.
        //    // Add the nodes to the TreeView during the looping process.
        //    if (inXmlNode.HasChildNodes)
        //    {
        //        nodeList = inXmlNode.ChildNodes;
        //        for (i = 0; i <= nodeList.Count - 1; i++)
        //        {
        //            xNode = inXmlNode.ChildNodes[i];
        //            inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
        //            tNode = inTreeNode.Nodes[i];
        //            AddNode(xNode, tNode);
        //        }
        //    }
        //    else
        //    {
        //        // Here you need to pull the data from the XmlNode based on the
        //        // type of node, whether attribute values are required, and so forth.
        //        inTreeNode.Text = (inXmlNode.OuterXml).Trim();
        //    }
        //}

        //private void caricaXmlInTreeView(String XmlPath)
        //{
        //    try
        //    {
        //        // SECTION 1. Create a DOM Document and load the XML data into it.
        //        XmlDocument dom = new XmlDocument();
        //        dom.Load(XmlPath);

        //        // SECTION 2. Initialize the TreeView control.
        //        treeViewSchema.Nodes.Clear();
        //        treeViewSchema.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
        //        TreeNode tNode = new TreeNode();
        //        tNode = treeViewSchema.Nodes[0];

        //        // SECTION 3. Populate the TreeView with the DOM nodes.
        //        AddNode(dom.DocumentElement, tNode);
        //        treeViewSchema.ExpandAll();
        //    }
        //    catch (XmlException xmlEx)
        //    {
        //        MessageBox.Show(xmlEx.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        //private void caricaXMLinRichTextBox(String XmlPath)
        //{
        //    XmlTextReader reader = new XmlTextReader(XmlPath);

        //    while (reader.Read())
        //    {

        //        switch (reader.NodeType)
        //        {

        //            case XmlNodeType.Element: // The node is an element.

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Blue;

        //                this.richTextBoxXmlSchema.AppendText("<");

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Brown;

        //                this.richTextBoxXmlSchema.AppendText(reader.Name);

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Blue;

        //                this.richTextBoxXmlSchema.AppendText(">");

        //                break;

        //            case XmlNodeType.Text: //Display the text in each element.

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Black;

        //                this.richTextBoxXmlSchema.AppendText(reader.Value);

        //                break;

        //            case XmlNodeType.EndElement: //Display the end of the element.

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Blue;

        //                this.richTextBoxXmlSchema.AppendText("</");

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Brown;

        //                this.richTextBoxXmlSchema.AppendText(reader.Name);

        //                this.richTextBoxXmlSchema.SelectionColor = Color.Blue;

        //                this.richTextBoxXmlSchema.AppendText(">");

        //                this.richTextBoxXmlSchema.AppendText(""+Environment.NewLine);

        //                break;

        //        }

        //    }


        //}

        public void setManagerClass()
        {
            _mysqlManagerClassModellator = new MysqlManagerClassModellator(_mysqlClassModellator);
        }


        public void setClass()
        {
            String selectesItems = tables.SelectedItem.ToString();
            _tableInformations = _mysqlInf.getTableInformations(selectesItems);

            _tableInformations.Schema = selectesItems;
            _tableInformations.PrimaryKey = _mysqlInf.getPrimaryKeyConstraints(_tableInformations.Schema, selectesItems);
            _tableInformations.ForeignConstraints = _mysqlInf.getForeignConstraints(_tableInformations.Schema,selectesItems);
            _tableInformations.UniqueConstraints = _mysqlInf.getUniqueConstraints(_tableInformations.Schema, selectesItems);
            _tableInformations.CreateTableStatement = _mysqlInf.getCreateTableString(selectesItems).Replace(Environment.NewLine,"").Replace("\r","").Replace("\n","");

            _mysqlClassModellator = new MysqlClass();
            //creazione della classe
            _mysqlClassModellator.TableInformation = _tableInformations;
            String summary = this.textBoxClassSummary.Text;

            summary += Environment.NewLine + "Full Class Information";
            summary += Environment.NewLine + "Table Name : " + _tableInformations.Name;
            summary += Environment.NewLine + "Table Comment : " + _tableInformations.Comment;
            summary += Environment.NewLine + "Table Collation : " + _tableInformations.Collation;
            summary += Environment.NewLine + "Table Create_time : " + _tableInformations.Create_time;
            summary += Environment.NewLine + "Table Engine : " + _tableInformations.Engine;
            summary += Environment.NewLine + "Table Version : " + _tableInformations.Version;
            summary += Environment.NewLine + "Table Row_format : " + _tableInformations.Row_format;
            summary += Environment.NewLine + "Table Rows : " + _tableInformations.Rows;
            summary += Environment.NewLine + "Table Avg_row_length : " + _tableInformations.Avg_row_length;
            summary += Environment.NewLine + "Table Data_length : " + _tableInformations.Data_length;
            summary += Environment.NewLine + "Table Max_data_length : " + _tableInformations.Max_data_length;
            summary += Environment.NewLine + "Table Index_length : " + _tableInformations.Index_length;
            summary += Environment.NewLine + "Table Data_free : " + _tableInformations.Data_free;
            summary += Environment.NewLine + "Table Auto_increment : " + _tableInformations.Auto_increment;
            summary += Environment.NewLine + "Table Update_time : " + _tableInformations.Update_time;
            summary += Environment.NewLine + "Table Check_time : " + _tableInformations.Check_time;
            summary += Environment.NewLine + "Table Checksum : " + _tableInformations.Checksum;
            summary += Environment.NewLine + "Table Create_options : " + _tableInformations.Create_options;

            if (checkBoxInsertCreateTable.Checked)
            {
                summary += Environment.NewLine + Environment.NewLine + Environment.NewLine + "Create Table Statment:";
                summary += "" + Environment.NewLine + _tableInformations.CreateTableStatement;
            }

            //classModellator.PathToSave = this.txtPath.Text;
            _mysqlClassModellator.Description = summary;
            _mysqlClassModellator.DriverUsed = (TypeOfDriver)this.comboBoxTypeDrivedr.SelectedItem;
            if (this.checkBoxPersonalCodeClass.Checked)
            {
                _mysqlClassModellator.AccessModifier = ListAccessModifiers.PUBLIC_PARTIAL.Value;
            }
            else
            {
                _mysqlClassModellator.AccessModifier = this.comboBoxModifiers.SelectedItem.ToString();
            }
            _mysqlClassModellator.NameSpace = this.textBoxProjectName.Text+(this.textBoxProjectName.Text.Length>0 ? ".":"") + this.textBoxNamespace.Text;
            _mysqlClassModellator.Name = this.textBoxClassName.Text;
            _mysqlClassModellator.ListCouloumbInformations = _mysqlInf.getFullColumnsList(tables.SelectedItem.ToString());
            summary = "";
            foreach (CoulomnInformations tmp in _mysqlClassModellator.ListCouloumbInformations)
            {
                PropertyModellator tmpPM = new PropertyModellator();

                tmpPM.Name = tmp.Field;
                summary = Environment.NewLine + "Complete informations";
                summary += Environment.NewLine + "Field: " + tmp.Field;
                summary += Environment.NewLine + "Comment: " + tmp.Comment;
                summary += Environment.NewLine + "Type: " + tmp.Type;
                summary += Environment.NewLine + "Collation: " + tmp.Collation;
                summary += Environment.NewLine + "Null: " + tmp.Null;
                summary += Environment.NewLine + "Key: " + tmp.Key;
                summary += Environment.NewLine + "Default: " + tmp.Default;
                summary += Environment.NewLine + "Extra: " + tmp.Extra;
                summary += Environment.NewLine + "Privileges: " + tmp.Privileges;
                tmpPM.Description = summary;
                tmpPM.Type = MysqlTypeMapping.getCsharpType(tmp.Type);
                _mysqlClassModellator.ListProperties.Add(tmpPM);

                //this.groupBoxFunction.Enabled = true;
            }
        }

        public void writeFullClass()
        {
            this.setClass();
            String path = this.txtPath.Text + "\\Table\\Mapping\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            path += _mysqlClassModellator.FileName;
            

            StreamWriter sw = File.CreateText(path);
            try
            {
                sw.Write(_mysqlClassModellator.getClassModellated());

                //classModellator.writeClass();
                if (this.checkBoxPersonalCodeClass.Checked)
                {
                    String pathPersonalCode = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "_PersCode" + Path.GetExtension(path);// path.Insert(path.LastIndexOf('.'), "_PersCode");

                    DialogResult tmp = DialogResult.Yes;

                    if (File.Exists(pathPersonalCode))
                    {

                        tmp = MessageBox.Show("The file: \n\n " + Path.GetFileName(pathPersonalCode) + "\n\n already exist.\n\n\n Are you sure overwrite?", "Attention!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }


                    if (tmp == DialogResult.Yes)
                    {
                        StreamWriter swPersonalCode = File.CreateText(pathPersonalCode);
                        try
                        {
                            swPersonalCode.Write(this._mysqlClassModellator.getPersonalCodeClassModelleted());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: \n\n" + ex.Message);
                        }
                        finally
                        {
                            swPersonalCode.Close();
                        }
                    }
                }
                
                
                if (this.checkBoxOpenFile.Checked)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex.Message);
            }
            finally
            {
                sw.Close();
            }
            //todo creare un modo che permette di convertite i varType
            //se il valore puo essere nullo allora fare il controllo isDbnull

            //MySqlCommand cmd = new MySqlCommand("SHOW FULL COLUMNS FROM " + tables.SelectedItem.ToString(), _conn);
            //MySqlDataReader reader = cmd.ExecuteReader();
            //try
            //{
            //    reader.Read();
            //    this._XmlFile = "PROVA_Xml.xml";
            //    DataTable dtGST = reader.GetSchemaTable();

            //    dtGST.WriteXml(this._XmlFile);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed to write XML: " + ex.Message);
            //}
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //}
        }

        public void writeManagerClass()
        {
            this.setClass();
            this.setManagerClass();
            String path = this.txtPath.Text + "\\Table\\Manager\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            path += _mysqlManagerClassModellator.FileName;
            StreamWriter sw = File.CreateText(path);
             try
            {
                sw.Write(this._mysqlManagerClassModellator.getClassModellated());

                if (this.checkBoxPersonalCodeManagerClass.Checked)
                {
                    String pathPersonalCode = Path.GetDirectoryName(path)+"\\" + Path.GetFileNameWithoutExtension(path) + "_PersCode" + Path.GetExtension(path);// path.Insert(path.LastIndexOf('.'), "_PersCode");

                    DialogResult tmp = DialogResult.Yes;

                    if (File.Exists(pathPersonalCode))
                    {
                       
                        tmp= MessageBox.Show("The file: \n\n "+Path.GetFileName(pathPersonalCode)+"\n\n already exist.\n\n\n Are you sure overwrite?", "Attention!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }


                    if(tmp == DialogResult.Yes)
                    {
                        StreamWriter swPersonalCode = File.CreateText(pathPersonalCode);
                        try
                        {
                            swPersonalCode.Write(this._mysqlManagerClassModellator.getPersonalCodeClassModelleted());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: \n\n" + ex.Message);
                        }
                        finally
                        {
                            swPersonalCode.Close();
                        }
                    }
                }
                //classModellator.writeClass();


                if (this.checkBoxOpenFile.Checked)
                {
                    System.Diagnostics.Process.Start(path);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex.Message);
            }
            finally
            {
                sw.Close();
            }

        }

        public void createClass(String XmlPath, string ClassComment)
        {
            MysqlClass classModellator = new MysqlClass();
            //classModellator.PathToSave = this.txtPath.Text;
            classModellator.Description = ClassComment;
            classModellator.DriverUsed = (TypeOfDriver)this.comboBoxTypeDrivedr.SelectedItem;
            classModellator.AccessModifier = this.comboBoxModifiers.SelectedItem.ToString();
            classModellator.NameSpace = this.textBoxProjectName.Text + (this.textBoxProjectName.Text.Length > 0 ? "." : "") + this.textBoxNamespace.Text;
            classModellator.Name = this.textBoxClassName.Text;

            XmlTextReader reader = new XmlTextReader(XmlPath);
            String Name = "";
            String Type = "";

            bool isColumnName = false;
            bool isDataType = false;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "ColumnName")
                        {
                            isColumnName = true;
                        }
                        else if (reader.Name == "DataType")
                        {
                            isDataType = true;
                        }
                        //DataType
                        break;

                    case XmlNodeType.Text:
                        if (isColumnName)
                        {
                            Name = reader.Value;
                            isColumnName = false;
                        }
                        else if (isDataType)
                        {
                            Type = reader.Value;
                            String[] vetStr = Type.Split(',');
                            PropertyModellator tmpPM = new PropertyModellator();
                            tmpPM.Name = Name;
                            tmpPM.Type = vetStr[0];
                            classModellator.ListProperties.Add(tmpPM);
                            //classTable.addProperty(Name, vetStr[0]);
                            isColumnName = false;
                            isDataType = false;
                            Name = "";
                            Type = "";
                        }
                        //tmp=reader.Value;
                        break;

                    case XmlNodeType.EndElement:
                        //tmp = reader.Name;

                        break;

                }
            }


            StreamWriter sw = File.CreateText(this.txtPath.Text + "\\" + classModellator.FileName);

            sw.Write(classModellator.getClassModellated());

            //classModellator.writeClass();


            if (this.checkBoxOpenFile.Checked)
            {
                System.Diagnostics.Process.Start(this.txtPath.Text + "\\" + classModellator.FileName);
            }

        }

        


        private void buttonShoCreateTable_Click(object sender, EventArgs e)
        {
            _view.labelDescrizione.Text = "Mysql Create Class";
            _view.Content = _mysqlInf.getCreateTableString(tables.SelectedItem.ToString());
            _view.ShowDialog();
        }


        #region private function


        private void GetDatabases()
        {
            databaseList.DataSource = null;
            databaseList.Items.Clear();
            databaseList.DataSource = _mysqlInf.getListDatabases();
        }



        private void connectDisconnect()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
                _mysqlInf.Connessione = null;
                bttConnect.Text = "Connect";
                groupBoxServerConnection.Enabled = true;

                groupBoxClassConfigurations.Enabled = false;
                grpBoxTableSelection.Enabled = false;
                tabControl1.Enabled = false;
                groupBoxMake.Enabled = false;
                groupBoxConfigurations.Enabled = true;
            }
            else
            {                //                   "server={0};user id={1}; password={2}; database=mysql; pooling=false"
                string connStr = String.Format(MysqlClassGeneratorV2.Properties.Settings.Default.MysqlConnectionString + MysqlClassGeneratorV2.Properties.Settings.Default.MysqlConnectionStringOptions,
                server.Text,"mysql", userid.Text, password.Text,textBoxPort.Text);

                try
                {
                    _conn = new MySqlConnection(connStr);
                    _conn.Open();
                    _mysqlInf.Connessione = _conn;
                    bttConnect.Text = "Disconnect";
                    groupBoxServerConnection.Enabled = false;

                    groupBoxClassConfigurations.Enabled = true;
                    grpBoxTableSelection.Enabled = true;
                    tabControl1.Enabled = true;
                    groupBoxMake.Enabled = true;

                    groupBoxConfigurations.Enabled = false;
                    GetDatabases();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error connecting to the server: " + ex.Message);
                    _conn.Dispose();
                    _conn = null;
                    _mysqlInf.Connessione = null;
                    bttConnect.Text = "Connect";
                    groupBoxServerConnection.Enabled = true;
                    groupBoxClassConfigurations.Enabled = false;
                    grpBoxTableSelection.Enabled = false;
                    tabControl1.Enabled = false;
                    groupBoxMake.Enabled = false;

                }

            }
        }

        #endregion


        //private void tabPageTreeView_Enter_1(object sender, EventArgs e)
        //{
        //    this.richTextBoxXmlSchema.Clear();
        //    if (this._XmlFile != null && File.Exists(this._XmlFile))
        //    {
        //        this.caricaXmlInTreeView(this._XmlFile);
        //    }
        //    else
        //        MessageBox.Show("Generate fist XML File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}


        //private void tabPageSchema_Enter(object sender, EventArgs e)
        //{
        //    this.richTextBoxXmlSchema.Clear();
        //    if (this._XmlFile != null && File.Exists(this._XmlFile))
        //    {
        //        this.caricaXMLinRichTextBox(this._XmlFile);
        //    }
        //    else
        //        MessageBox.Show("Generate fist XML File.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length != 0)
            {
                folderBrowserDialog1.SelectedPath = Path.GetFullPath(txtPath.Text);
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }


            //saveFileDialog1.Filter = "C Sharp files (*.cs)|*.cs|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 1;
            //saveFileDialog1.RestoreDirectory = true;

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    //if ((myStream = saveFileDialog1.OpenFile()) != null)
            //    //{
            //    //    // Code to write the stream goes here.
            //    //    myStream.Close();
            //    //}
            //}

        }

        

        private void buttonCreateCompleteClass_Click(object sender, EventArgs e)
        {
            this.writeFullClass();
            MessageBox.Show("Class created correctly in \n\n" + this.txtPath.Text + " \n\nGood coding.", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void showGetClass()
        {
            getClassModellator tmp = new getClassModellator();
            tmp.ClasseRiferimento = _mysqlClassModellator;

            //  tmp.ListVariables = _mysqlClassModellator.getVariablesInWhereClausule()   //.Add(new Variables("int", "idXXX"));
            tmp.NameConnection = "this._connection";
            // tmp.ListVariables.Add(new Variables(_mysqlClassModellator.DriverUsed.ToString(), "connecction"));

            _view.labelDescrizione.Text = "Metod get Class";
            _view.Content = tmp.getFunctionModelleted();
            _view.ClassName.Text = _mysqlClassModellator.Name+"_getClass.cs";
            _view.ShowDialog();
            // MessageBox.Show(tmp.Body);
        }

        private void showUpdateClass()
        {
            
            updateClassModellator tmp = new updateClassModellator();
            tmp.ClasseRiferimento = _mysqlClassModellator;

             tmp.NameConnection = "this._connection";
            
            _view.labelDescrizione.Text = "Update class";
            _view.ClassName.Text = _mysqlClassModellator.Name+"_updateClass.cs";
            _view.Content = tmp.getFunctionModelleted();
            _view.ShowDialog();
        }

        private void showDeleteClass()
        {
            deleteClassModellator tmp = new deleteClassModellator();
            tmp.ClasseRiferimento = _mysqlClassModellator;

            //  tmp.ListVariables = _mysqlClassModellator.getVariablesInWhereClausule()   //.Add(new Variables("int", "idXXX"));
            tmp.NameConnection = "this._connection";
            // tmp.ListVariables.Add(new Variables(_mysqlClassModellator.DriverUsed.ToString(), "connecction"));

            _view.labelDescrizione.Text = "Delete class";
            _view.Content = tmp.getFunctionModelleted();
            _view.ClassName.Text = _mysqlClassModellator.Name+"_deleteClass.cs"; 
            
            _view.ShowDialog();
        }

        private void showInsertClass()
        {
            insertClassModellator tmp = new insertClassModellator();
            tmp.ClasseRiferimento = _mysqlClassModellator;

            //  tmp.ListVariables = _mysqlClassModellator.getVariablesInWhereClausule()   //.Add(new Variables("int", "idXXX"));
            tmp.NameConnection = "this._connection";
            // tmp.ListVariables.Add(new Variables(_mysqlClassModellator.DriverUsed.ToString(), "connecction"));

            _view.labelDescrizione.Text = "Metod Insert";
            _view.ClassName.Text = _mysqlClassModellator.Name+"_InsertClass.cs";
            _view.Content = tmp.getFunctionModelleted();
            _view.ShowDialog();
        }

        private void ShowCreateListClass()
        {
            getListClassModellator tmp = new getListClassModellator(_mysqlClassModellator, "this._connection");

            _view.labelDescrizione.Text = "Metodo get List Class";
            _view.Content = tmp.getFunctionModelleted();
            _view.ClassName.Text = _mysqlClassModellator.Name+"_getListClass.cs"; 
            _view.ShowDialog();
            //MessageBox.Show(tmp.Body);
        }

        private void showDBConnectorClass()
        {
            MySqlClientDBConnector tmp = new MySqlClientDBConnector();
            tmp.NameSpace = this.textBoxProjectName.Text + (this.textBoxProjectName.Text.Length > 0 ? "." : "") + "DataLayer";  
            _view.labelDescrizione.Text = "Class db Connector modellated";
            _view.Content = tmp.getClassModellated();
            _view.ClassName.Text = tmp.FileName;
            _view.ShowDialog();

        }
        
        private void showCreteClass()
        {
            this.setClass();
            _view.labelDescrizione.Text = "Class modellated";
            _view.Content = _mysqlClassModellator.getClassModellated();


            if (this.checkBoxPersonalCodeClass.Checked)
            {
                _view.Content += Environment.NewLine + "//\n// Personal code class:\n//" + Environment.NewLine;
                _view.Content += _mysqlClassModellator.getPersonalCodeClassModelleted();
            }


            _view.ClassName.Text = _mysqlClassModellator.FileName; 
            _view.ShowDialog();

        }

        private void showManagerClass()
        {
            this.setManagerClass();
            _view.labelDescrizione.Text = "ManagerClass class";
            _view.Content = this._mysqlManagerClassModellator.getClassModellated();
            _view.Content += Environment.NewLine + Environment.NewLine;
            _view.Content += this._mysqlManagerClassModellator.getPersonalCodeClassModelleted();
            _view.ClassName.Text = this._mysqlManagerClassModellator.FileName;
            _view.ShowDialog();
        }

        private void buttCreateFunction_Click(object sender, EventArgs e)
        {
            if (chBoxCreateGetClass.Checked)
            {
                this.showGetClass();
            }

            if (chBoxCreateGetListClass.Checked)
            {
                ShowCreateListClass();
            }

            if (checkBoxInsert.Checked)
            {
                showInsertClass();
            }

            if (checkBoxDelete.Checked)
            {
                showDeleteClass();
            }

            if (checkBoxUpdate.Checked)
            {
                showUpdateClass();
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {          
            this.showCreteClass();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
                this.setClass();
            this.showGetClass();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
                this.setClass();
            this.ShowCreateListClass();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
                this.setClass();
            this.showInsertClass();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
                this.setClass();
            this.showDeleteClass();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
                this.setClass();
            this.showUpdateClass();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
            this.setClass();
            this.showManagerClass();
        }

        private void buttCreateFunction_Click_1(object sender, EventArgs e)
        {
            this.writeManagerClass();
            MessageBox.Show("Manager Class created correctly in \n\n" + this.txtPath.Text + " \n\nGood coding.", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void buttonSaveServerConf_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = textBoxCnfServer.Text;
            Properties.Settings.Default.Username = textBoxCnfUserId.Text;
            Properties.Settings.Default.Password = textBoxCnfPassword.Text;
            Properties.Settings.Default.Port = Convert.ToInt32(textBoxCnfPort.Text);
            //Properties.Settings.Default.MysqlConnectionString = this.textBoxCnfConnectionString.Text;
            Properties.Settings.Default.MysqlConnectionStringOptions = textBoxCnfConnectionOptions.Text;
            Properties.Settings.Default.Save();

        }

        private void tabControlMake_Selected(object sender, TabControlEventArgs e)
        {
            this.inizializeForm();
        }

        private void buttonCreateAllClass_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //List<string> tmpList = (List<string>)tables.DataSource;
           for(int i=0; i<tables.Items.Count;i++)
            {
               tables.SelectedIndex=i;
                writeFullClass();
            }

           this.Cursor = Cursors.Default;
           MessageBox.Show("ALL Class created correctly in \n\n" + this.txtPath.Text + "\\Table \n\nGood coding.", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void buttonCreateALLManagerClass_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < tables.Items.Count; i++)
            {
                tables.SelectedIndex = i;
                writeManagerClass();
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("ALL Manager Class created correctly in \n\n" + this.txtPath.Text + "\\Manager \n\nGood coding.", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.setClass();
            this.showPersonalManager();
        }

        private void showPersonalManager()
        {
            this.setManagerClass();
            _view.labelDescrizione.Text = "Personal ManagerClass class";
            _view.Content = this._mysqlManagerClassModellator.getPersonalCodeClassModelleted();
            _view.ClassName.Text = this._mysqlManagerClassModellator.FileName;
            _view.ShowDialog();
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            //if (_mysqlClassModellator == null)
            this.setClass();
            this.ShowCreateTableFunction();
        }

        private void ShowCreateTableFunction()
        {

            createTableModellator tmp = new createTableModellator();
            tmp.ClasseRiferimento = _mysqlClassModellator;

            //  tmp.ListVariables = _mysqlClassModellator.getVariablesInWhereClausule()   //.Add(new Variables("int", "idXXX"));
            tmp.NameConnection = "this._connection";
            // tmp.ListVariables.Add(new Variables(_mysqlClassModellator.DriverUsed.ToString(), "connecction"));

            _view.labelDescrizione.Text = "Metod Create Table";
            _view.ClassName.Text = _mysqlClassModellator.Name + "_CreateTable.cs";
            _view.Content = tmp.getFunctionModelleted();
            _view.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.createPersonalManagerCode = checkBoxPersonalCodeManagerClass.Checked;
            Properties.Settings.Default.createPeronalCode = checkBoxPersonalCodeClass.Checked;
            Properties.Settings.Default.Save();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkBoxPersonalCodeManagerClass.Checked = Properties.Settings.Default.createPersonalManagerCode;
            checkBoxPersonalCodeClass.Checked = Properties.Settings.Default.createPeronalCode;

        }

        private void buttonMakeALL_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < tables.Items.Count; i++)
            {
                tables.SelectedIndex = i;
                writeFullClass();
                writeManagerClass();
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("ALL Class created correctly in \n\n" + this.txtPath.Text + " \n\nGood coding.", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonCreatedbConnector_Click(object sender, EventArgs e)
        {
            showDBConnectorClass();
        }

        private void comboBoxTypeDrivedr_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeDrivedr.Text == TypeOfDriver.MySQLDriverCS.ToString())
            {
                MessageBox.Show("Attention beta version not full supported");
            }
        }



 
        

    }
}
