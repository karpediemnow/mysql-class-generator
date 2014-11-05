using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using ColorCode;


namespace MysqlClassGeneratorV2
{
    public partial class View : Form
    {
        private String _content;

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }



        public View()
        {
            InitializeComponent();
            ////syntaxRichTextBox1.Settings.Keywords.Add("abstract");
            ////syntaxRichTextBox1.Settings.Keywords.Add("event");
            //syntaxRichTextBox1.Settings.Keywords.Add("new");
            ////syntaxRichTextBox1.Settings.Keywords.Add("struct");
            ////syntaxRichTextBox1.Settings.Keywords.Add("as");
            ////syntaxRichTextBox1.Settings.Keywords.Add("explicit");
            //syntaxRichTextBox1.Settings.Keywords.Add("null");
            //syntaxRichTextBox1.Settings.Keywords.Add("switch");
            //syntaxRichTextBox1.Settings.Keywords.Add("base");
            ////syntaxRichTextBox1.Settings.Keywords.Add("extern");
            //syntaxRichTextBox1.Settings.Keywords.Add("object");
            //syntaxRichTextBox1.Settings.Keywords.Add("this");
            //syntaxRichTextBox1.Settings.Keywords.Add("bool");
            //syntaxRichTextBox1.Settings.Keywords.Add("false");
            ////syntaxRichTextBox1.Settings.Keywords.Add("operator");
            //syntaxRichTextBox1.Settings.Keywords.Add("throw");
            //syntaxRichTextBox1.Settings.Keywords.Add("break");
            ////syntaxRichTextBox1.Settings.Keywords.Add("finally");
            ////syntaxRichTextBox1.Settings.Keywords.Add("out");
            //syntaxRichTextBox1.Settings.Keywords.Add("true");
            //syntaxRichTextBox1.Settings.Keywords.Add("byte");
            ////syntaxRichTextBox1.Settings.Keywords.Add("fixed");
            ////syntaxRichTextBox1.Settings.Keywords.Add("override");
            //syntaxRichTextBox1.Settings.Keywords.Add("try");
            //syntaxRichTextBox1.Settings.Keywords.Add("case");
            //syntaxRichTextBox1.Settings.Keywords.Add("float");
            ////syntaxRichTextBox1.Settings.Keywords.Add("params");
            ////syntaxRichTextBox1.Settings.Keywords.Add("typeof");
            //syntaxRichTextBox1.Settings.Keywords.Add("catch");
            //syntaxRichTextBox1.Settings.Keywords.Add("for");
            //syntaxRichTextBox1.Settings.Keywords.Add("private");
            //syntaxRichTextBox1.Settings.Keywords.Add("uint");
            //syntaxRichTextBox1.Settings.Keywords.Add("char");
            //syntaxRichTextBox1.Settings.Keywords.Add("foreach");
            ////syntaxRichTextBox1.Settings.Keywords.Add("protected");
            ////syntaxRichTextBox1.Settings.Keywords.Add("ulong");
            ////syntaxRichTextBox1.Settings.Keywords.Add("checked");
            ////syntaxRichTextBox1.Settings.Keywords.Add("goto");
            //syntaxRichTextBox1.Settings.Keywords.Add("public");
            ////syntaxRichTextBox1.Settings.Keywords.Add("unchecked");
            //syntaxRichTextBox1.Settings.Keywords.Add("class");
            //syntaxRichTextBox1.Settings.Keywords.Add("if");
            ////syntaxRichTextBox1.Settings.Keywords.Add("readonly");
            ////syntaxRichTextBox1.Settings.Keywords.Add("unsafe");
            ////syntaxRichTextBox1.Settings.Keywords.Add("const");
            ////syntaxRichTextBox1.Settings.Keywords.Add("implicit");
            ////syntaxRichTextBox1.Settings.Keywords.Add("ref");
            //syntaxRichTextBox1.Settings.Keywords.Add("ushort");
            ////syntaxRichTextBox1.Settings.Keywords.Add("continue");
            //syntaxRichTextBox1.Settings.Keywords.Add("in");
            //syntaxRichTextBox1.Settings.Keywords.Add("return");
            //syntaxRichTextBox1.Settings.Keywords.Add("using");
            //syntaxRichTextBox1.Settings.Keywords.Add("decimal");
            //syntaxRichTextBox1.Settings.Keywords.Add("int");
            //syntaxRichTextBox1.Settings.Keywords.Add("Int16");
            //syntaxRichTextBox1.Settings.Keywords.Add("Int32");
            //syntaxRichTextBox1.Settings.Keywords.Add("Int64");
            //syntaxRichTextBox1.Settings.Keywords.Add("sbyte");
            ////syntaxRichTextBox1.Settings.Keywords.Add("virtual");
            ////syntaxRichTextBox1.Settings.Keywords.Add("default");
            ////syntaxRichTextBox1.Settings.Keywords.Add("interface");
            ////syntaxRichTextBox1.Settings.Keywords.Add("sealed");
            ////syntaxRichTextBox1.Settings.Keywords.Add("volatile");
            ////syntaxRichTextBox1.Settings.Keywords.Add("delegate");
            ////syntaxRichTextBox1.Settings.Keywords.Add("internal");
            ////syntaxRichTextBox1.Settings.Keywords.Add("short");
            //syntaxRichTextBox1.Settings.Keywords.Add("void");
            ////syntaxRichTextBox1.Settings.Keywords.Add("do");
            ////syntaxRichTextBox1.Settings.Keywords.Add("is");
            ////syntaxRichTextBox1.Settings.Keywords.Add("sizeof");
            //syntaxRichTextBox1.Settings.Keywords.Add("while");
            //syntaxRichTextBox1.Settings.Keywords.Add("double");
            ////syntaxRichTextBox1.Settings.Keywords.Add("lock");
            ////syntaxRichTextBox1.Settings.Keywords.Add("stackalloc");
            //syntaxRichTextBox1.Settings.Keywords.Add("else");
            ////syntaxRichTextBox1.Settings.Keywords.Add("long");
            ////syntaxRichTextBox1.Settings.Keywords.Add("static");
            ////syntaxRichTextBox1.Settings.Keywords.Add("enum");
            //syntaxRichTextBox1.Settings.Keywords.Add("namespace");
            //syntaxRichTextBox1.Settings.Keywords.Add("string");

            //syntaxRichTextBox1.Settings.KeywordColor = Color.Blue;
            //syntaxRichTextBox1.Settings.CommentColor = Color.Green;
            //syntaxRichTextBox1.Settings.StringColor = Color.Red;
            //syntaxRichTextBox1.Settings.IntegerColor = Color.Red;
            
            //syntaxRichTextBox1.Settings.Comment = "//";
            //syntaxRichTextBox1.CompileKeywords();
        }

        private void copyALL_Click(object sender, EventArgs e)
        {

            Clipboard.SetDataObject(this._content, true);

        }


        // void ParseLine(string line)
        //{
        //    Regex r = new Regex("([ \\t{}();])");
        //    String[] tokens = r.Split(line);

        //    foreach (string token in tokens)
        //    {
        //        // Set the token's default color and font.
        //        richTextBoxMessaggio.SelectionColor = Color.Black;
        //        richTextBoxMessaggio.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);

        //        // Check for a comment.
        //        if (token == "//" || token.StartsWith("//"))
        //        {
        //            // Find the start of the comment and then extract the whole comment.
        //            int index = line.IndexOf("//");
        //            string comment = line.Substring(index, line.Length - index);
        //            richTextBoxMessaggio.SelectionColor = Color.LightGreen;
        //            richTextBoxMessaggio.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
        //            richTextBoxMessaggio.SelectedText = comment;
        //            break;
        //        }

        //        // Check whether the token is a keyword. 
        //        String[] keywords = { "public", "void", "using", "static", "class" };
        //        for (int i = 0; i < keywords.Length; i++)
        //        {
        //            if (keywords[i] == token)
        //            {
        //                // Apply alternative color and font to highlight keyword.
        //                richTextBoxMessaggio.SelectionColor = Color.Blue;
        //                richTextBoxMessaggio.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
        //                break;
        //            }
        //        }
        //        richTextBoxMessaggio.SelectedText = token;
        //    }
        //    richTextBoxMessaggio.SelectedText = "\n";
        //}


        //void ParseALL()
        //{
        //    string[] tempArray = new string[richTextBoxMessaggio.Lines.Length];
        //    tempArray = richTextBoxMessaggio.Lines;
        //    for (int counter = 0; counter < tempArray.Length; counter++)
        //    {
        //       this.ParseLine(tempArray[counter]);
        //    }
        //}


        ////private void TextChangedEvent(object sender, EventArgs e)
        ////{
        ////    // Calculate the starting position of the current line.
        ////    int start = 0, end = 0;
        ////    for (start = richTextBoxMessaggio.SelectionStart - 1; start > 0; start--)
        ////    {
        ////        if (richTextBoxMessaggio.Text[start] == '\n') { start++; break; }
        ////    }

        ////    // Calculate the end position of the current line.
        ////    for (end = richTextBoxMessaggio.SelectionStart; end < richTextBoxMessaggio.Text.Length; end++)
        ////    {
        ////        if (richTextBoxMessaggio.Text[end] == '\n') break;
        ////    }

        ////    // Extract the current line that is being edited.
        ////    String line = richTextBoxMessaggio.Text.Substring(start, end - start);

        ////    // Backup the users current selection point.
        ////    int selectionStart = richTextBoxMessaggio.SelectionStart;
        ////    int selectionLength = richTextBoxMessaggio.SelectionLength;

        ////    // Split the line into tokens.
        ////    Regex r = new Regex("([ \\t{}();])");
        ////    string[] tokens = r.Split(line);
        ////    int index = start;
        ////    foreach (string token in tokens)
        ////    {

        ////        // Set the token's default color and font.
        ////        richTextBoxMessaggio.SelectionStart = index;
        ////        richTextBoxMessaggio.SelectionLength = token.Length;
        ////        richTextBoxMessaggio.SelectionColor = Color.Black;
        ////        richTextBoxMessaggio.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);

        ////        // Check for a comment.
        ////        if (token == "//" || token.StartsWith("//"))
        ////        {
        ////            // Find the start of the comment and then extract the whole comment.
        ////            int length = line.Length - (index - start);
        ////            string commentText = richTextBoxMessaggio.Text.Substring(index, length);
        ////            richTextBoxMessaggio.SelectionStart = index;
        ////            richTextBoxMessaggio.SelectionLength = length;
        ////            richTextBoxMessaggio.SelectionColor = Color.LightGreen;
        ////            richTextBoxMessaggio.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
        ////            break;
        ////        }

        ////        // Check whether the token is a keyword. 
        ////        String[] keywords = { "public", "void", "using", "static", "class" };
        ////        for (int i = 0; i < keywords.Length; i++)
        ////        {
        ////            if (keywords[i] == token)
        ////            {
        ////                // Apply alternative color and font to highlight keyword.        
        ////                richTextBoxMessaggio.SelectionColor = Color.Blue;
        ////                richTextBoxMessaggio.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
        ////                break;
        ////            }
        ////        }
        ////        index += token.Length;
        ////    }
        ////    // Restore the users current selection point.    
        ////    richTextBoxMessaggio.SelectionStart = selectionStart;
        ////    richTextBoxMessaggio.SelectionLength = selectionLength;
        ////}

        private void View_Load(object sender, EventArgs e)
        {
            //this.ParseALL();

            CodeColorizer tmp = new CodeColorizer();

            this.webBrowserClassView.DocumentText = tmp.Colorize(this._content, Languages.CSharp);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamWriter sw = File.CreateText(folderBrowserDialog1.SelectedPath + "\\" + ClassName.Text);

                sw.Write(this._content);

                sw.Close();

            }
        }

        private void buttonCopyHTML_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.webBrowserClassView.DocumentText, true);
        }

    }
}
