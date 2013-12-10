using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using mshtml;

// for Marshal.Copy
using System.Runtime.InteropServices;
using System.IO;

public class Form2 : Form
{
    private Metafile metafile1;
    private Graphics.EnumerateMetafileProc metafileDelegate;
    private WebBrowser we;
    private StatusStrip EditStatusStrip;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem H1StripMenuItem;
    private ToolStripMenuItem DivStripMenuItem;
    private ToolStripMenuItem StyleStripMenuItem;
    private ToolStripMenuItem ImgStripMenuItem;
    private ToolStripMenuItem SaveStripMenuItem;
    private ToolStripMenuItem TextStripMenuItem;
    private Point destPoint;//２８０.４补给公司！１０块工本费 290+30
    public Form2()
    {
        //metafile1 = new Metafile("C:\\Intel\\fenhuang.emf");
        //metafileDelegate = new Graphics.EnumerateMetafileProc(MetafileCallback);
        //destPoint = new Point(20, 10);
        //------------------------------------------------------------------------------
        InitializeComponent();
        this.MouseClick += Form2_MouseClick;
        this.we.Url = new Uri(Path.Combine(Directory.GetCurrentDirectory(), "we.html"));
        this.we.Document.Click += Document_Click;
        this.we.DocumentCompleted += we_DocumentCompleted;
    }

    void we_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        //this.we.Document.GetElementById("Editor").SetAttribute("contenteditable", "true");
    }

    void Form2_MouseClick(object sender, MouseEventArgs e)
    {
        MessageBox.Show(e.Location.ToString());
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        //e.Graphics.EnumerateMetafile(metafile1, destPoint, metafileDelegate);
    }
    private bool MetafileCallback(
       EmfPlusRecordType recordType,
       int flags,
       int dataSize,
       IntPtr data,
       PlayRecordCallback callbackData)
    {
        byte[] dataArray = null;
        if (data != IntPtr.Zero)
        {
            // Copy the unmanaged record to a managed byte buffer 
            // that can be used by PlayRecord.
            dataArray = new byte[dataSize];
            Marshal.Copy(data, dataArray, 0, dataSize);
        }

        metafile1.PlayRecord(recordType, flags, dataSize, dataArray);

        return true;
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.we = new System.Windows.Forms.WebBrowser();
            this.EditStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.H1StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DivStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StyleStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImgStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // we
            // 
            this.we.Location = new System.Drawing.Point(12, 12);
            this.we.MinimumSize = new System.Drawing.Size(20, 20);
            this.we.Name = "we";
            this.we.Size = new System.Drawing.Size(585, 393);
            this.we.TabIndex = 0;
            this.we.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            // 
            // EditStatusStrip
            // 
            this.EditStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.EditStatusStrip.Location = new System.Drawing.Point(0, 408);
            this.EditStatusStrip.Name = "EditStatusStrip";
            this.EditStatusStrip.Size = new System.Drawing.Size(609, 22);
            this.EditStatusStrip.TabIndex = 1;
            this.EditStatusStrip.Text = "EditStatusStrip";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.H1StripMenuItem,
            this.DivStripMenuItem,
            this.StyleStripMenuItem,
            this.ImgStripMenuItem,
            this.TextStripMenuItem,
            this.SaveStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // H1StripMenuItem
            // 
            this.H1StripMenuItem.Name = "H1StripMenuItem";
            this.H1StripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.H1StripMenuItem.Text = "H1StripMenuItem";
            this.H1StripMenuItem.Click += new System.EventHandler(this.H1StripMenuItem_Click);
            // 
            // DivStripMenuItem
            // 
            this.DivStripMenuItem.Name = "DivStripMenuItem";
            this.DivStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.DivStripMenuItem.Text = "DivStripMenuItem";
            this.DivStripMenuItem.Click += new System.EventHandler(this.DivStripMenuItem_Click);
            // 
            // StyleStripMenuItem
            // 
            this.StyleStripMenuItem.Name = "StyleStripMenuItem";
            this.StyleStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.StyleStripMenuItem.Text = "StyleStripMenuItem";
            this.StyleStripMenuItem.Click += new System.EventHandler(this.StyleStripMenuItem_Click);
            // 
            // ImgStripMenuItem
            // 
            this.ImgStripMenuItem.Name = "ImgStripMenuItem";
            this.ImgStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ImgStripMenuItem.Text = "ImgStripMenuItem";
            this.ImgStripMenuItem.Click += new System.EventHandler(this.ImgStripMenuItem_Click);
            // 
            // TextStripMenuItem
            // 
            this.TextStripMenuItem.Name = "TextStripMenuItem";
            this.TextStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.TextStripMenuItem.Text = "TextStripMenuItem";
            this.TextStripMenuItem.Click += new System.EventHandler(this.TextStripMenuItem_Click);
            // 
            // SaveStripMenuItem
            // 
            this.SaveStripMenuItem.Name = "SaveStripMenuItem";
            this.SaveStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.SaveStripMenuItem.Text = "SaveStripMenuItem";
            this.SaveStripMenuItem.Click += new System.EventHandler(this.SaveStripMenuItem_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(609, 430);
            this.Controls.Add(this.EditStatusStrip);
            this.Controls.Add(this.we);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.EditStatusStrip.ResumeLayout(false);
            this.EditStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private Point cp = new Point();
    void Document_Click(object sender, HtmlElementEventArgs e)
    {
        cp = e.MousePosition;
        //throw new NotImplementedException();
    }

    void we_GotFocus(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void SaveStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show(this.we.Document.Body.InnerHtml);
    }

    private void H1StripMenuItem_Click(object sender, EventArgs e)
    {
        HtmlElement he = this.we.Document.CreateElement("h1");
        he.InnerText = "Yes";
        he.Id = "Yes";
        this.we.Document.Body.AppendChild(he);
    }

    private void StyleStripMenuItem_Click(object sender, EventArgs e)
    {
        this.we.Document.GetElementById("Yes").Style = "Color: red; Font-Size: 64px;";
    }

    private void DivStripMenuItem_Click(object sender, EventArgs e)
    {
        var obj = this.we.Document.GetElementFromPoint(this.cp);
        obj.Style = "color: green; font-weight: bolder;";
        var div = this.we.Document.CreateElement("div");
        div.Style = "border: 1px solid red; width: 100px; height: 100px;";
        obj.AppendChild(div);
        div.InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeEnd, obj);
    }

    private void TextStripMenuItem_Click(object sender, EventArgs e)
    {
        mshtml.IHTMLDocument2 i2 = this.we.Document.DomDocument as mshtml.IHTMLDocument2;
        mshtml.IHTMLTxtRange range = i2.selection.createRange() as IHTMLTxtRange;
        range.pasteHTML("<span style=\"color: red;\">May It Be Too.</span>");
    }

    private void ImgStripMenuItem_Click(object sender, EventArgs e)
    {
        string img = "<img src=\"http://www.google.com.hk/images/srpr/logo11w.png\" alt=\"\" style=\"width: 320px;\" />";
        this.Insert(img);
    }

    private void Insert(string text)
    {
        mshtml.IHTMLDocument2 i2 = this.we.Document.DomDocument as mshtml.IHTMLDocument2;
        mshtml.IHTMLTxtRange range = i2.selection.createRange() as IHTMLTxtRange;
        range.pasteHTML(text);
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using mshtml;
　　
////添加引用 .Net-Microsoft.mshtml
//namespace WindowsApplication29
//...{
//  public partial class Form1 : Form
//  ...{
//    public Form1()
//    ...{
//      InitializeComponent();
//      this.webBrowser1.Navigate("www.google.cn");
//    }
　　
//    private void button1_Click(object sender, EventArgs e)
//    ...{
//      IHTMLDocument2 doc = (IHTMLDocument2)this.webBrowser1.Document.DomDocument;
//      IHTMLTxtRange range = doc.selection.createRange() as IHTMLTxtRange;
//      range.pasteHTML(range.text+"<div>jinjazz 路过</div>");
//    }
//  }
//}

//using mshtml;
////获取用户选中的文字
//            IHTMLDocument2 htmlDocument = webBrowser1.Document.DomDocument as IHTMLDocument2;
//            IHTMLSelectionObject currentSelection = htmlDocument.selection;
//            if (currentSelection != null)
//            { IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
//                if (range != null)
//                {
//                    //MessageBox.Show(range.text);
//                    tbKeyWord.Text = range.text;
//                }
//            }
