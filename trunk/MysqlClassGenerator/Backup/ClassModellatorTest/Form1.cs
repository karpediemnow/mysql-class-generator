using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ClassModellator;
using ClassModellator.Class;
using ClassModellator.ModifierManager;
using ClassModellator.Statment;

namespace ClassModellatorTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassFileModellator tmp = new ClassFileModellator();

            tmp.ListUsings.Add(new ClassModellator.Using.UsingModellator("System"));
            tmp.ListUsings.Add(new ClassModellator.Using.UsingModellator("System.Data"));


            NameSpaceModellator tmpNS= new NameSpaceModellator("NameSpece.prova");
            tmp.ListNamespaces.Add(tmpNS);
 
            ClassModellatorNew tmpCM = new ClassModellatorNew("ClasseProva");
            tmpNS.ListClasses.Add(tmpCM);

            tmpCM.ListFields.Add(new FieldModelletor("int", "x"));
            tmpCM.ListFields.Add(new FieldModelletor("int", "y"));
            tmpCM.ListFields.Add(new FieldModelletor("int", "z"));
            tmpCM.ListFields.Add(new FieldModelletor("int", "COUNT", ListAccessModifiers.PUBLIC, ListModifiers.STATIC));

            
            FieldEncapsutatorModellator pm = new FieldEncapsutatorModellator("fieldEncapsulaed", "int", true, true, null, ListAccessModifiers.PUBLIC);
            tmpCM.ListProperties.Add(pm);
            PropertyModellatorNew pe = new PropertyModellatorNew("property", "int", true, true, null, ListAccessModifiers.PUBLIC);
            tmpCM.ListProperties.Add(pe);

            tmpCM.ListMethods.Add(new MethodModellatorNew("MethodX","void"));

            MethodModellatorNew tmpMet = new MethodModellatorNew("MethodY_somma", "int");
            tmpMet.ListVariables.Add(new VariableModellator("int","A"));
            tmpMet.ListVariables.Add(new VariableModellator("int","B"));
            tmpMet.Body = "return A + B;";

            tmpCM.ListMethods.Add(tmpMet);
            
            
            tmp.FileName = "test";

            this.textBox1.Text = tmp.ToString();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            StatmentModellator tmp = new StatmentModellator();
            tmp.AddLine("public int var;");
            tmp.AddLine(Environment.NewLine);
            tmp.AddLine("public void reset()");
            tmp.AddLine("{");
            tmp.AddLine("// insert code");
            tmp.AddLine("}");
            this.textBox1.Text = tmp.ToString();
        }
    }
}
