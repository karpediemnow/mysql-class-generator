using System.Drawing;
namespace MysqlClassGeneratorV2
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCopySorce = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ClassName = new System.Windows.Forms.Label();
            this.webBrowserClassView = new System.Windows.Forms.WebBrowser();
            this.buttonCopyHTML = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.AutoSize = true;
            this.labelDescrizione.Location = new System.Drawing.Point(12, 21);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(65, 13);
            this.labelDescrizione.TabIndex = 1;
            this.labelDescrizione.Text = "Descrizione:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyALLToolStripMenuItem,
            this.selectALLToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // copyALLToolStripMenuItem
            // 
            this.copyALLToolStripMenuItem.Name = "copyALLToolStripMenuItem";
            this.copyALLToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyALLToolStripMenuItem.Text = "&Copy ALL";
            this.copyALLToolStripMenuItem.Click += new System.EventHandler(this.copyALL_Click);
            // 
            // selectALLToolStripMenuItem
            // 
            this.selectALLToolStripMenuItem.Name = "selectALLToolStripMenuItem";
            this.selectALLToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.selectALLToolStripMenuItem.Text = "&Select ALL";
            // 
            // buttonCopySorce
            // 
            this.buttonCopySorce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopySorce.Location = new System.Drawing.Point(598, 8);
            this.buttonCopySorce.Name = "buttonCopySorce";
            this.buttonCopySorce.Size = new System.Drawing.Size(89, 23);
            this.buttonCopySorce.TabIndex = 4;
            this.buttonCopySorce.Text = "Copy SOURCE";
            this.buttonCopySorce.UseVisualStyleBackColor = true;
            this.buttonCopySorce.Click += new System.EventHandler(this.copyALL_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClassName
            // 
            this.ClassName.AutoSize = true;
            this.ClassName.Location = new System.Drawing.Point(12, 4);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(60, 13);
            this.ClassName.TabIndex = 9;
            this.ClassName.Text = "ClassName";
            // 
            // webBrowserClassView
            // 
            this.webBrowserClassView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserClassView.Location = new System.Drawing.Point(11, 37);
            this.webBrowserClassView.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserClassView.Name = "webBrowserClassView";
            this.webBrowserClassView.Size = new System.Drawing.Size(676, 453);
            this.webBrowserClassView.TabIndex = 10;
            // 
            // buttonCopyHTML
            // 
            this.buttonCopyHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyHTML.Location = new System.Drawing.Point(489, 8);
            this.buttonCopyHTML.Name = "buttonCopyHTML";
            this.buttonCopyHTML.Size = new System.Drawing.Size(89, 23);
            this.buttonCopyHTML.TabIndex = 11;
            this.buttonCopyHTML.Text = "Copy HTML";
            this.buttonCopyHTML.UseVisualStyleBackColor = true;
            this.buttonCopyHTML.Click += new System.EventHandler(this.buttonCopyHTML_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 502);
            this.Controls.Add(this.buttonCopyHTML);
            this.Controls.Add(this.webBrowserClassView);
            this.Controls.Add(this.ClassName);
            this.Controls.Add(this.labelDescrizione);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonCopySorce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View";
            this.Load += new System.EventHandler(this.View_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyALLToolStripMenuItem;
        public System.Windows.Forms.Label labelDescrizione;
        private System.Windows.Forms.Button buttonCopySorce;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Label ClassName;
        private System.Windows.Forms.WebBrowser webBrowserClassView;
        private System.Windows.Forms.Button buttonCopyHTML;
    }
}