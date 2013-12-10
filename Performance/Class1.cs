using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

// for Marshal.Copy
using System.Runtime.InteropServices;

public class Form1 : Form
{
    private Metafile metafile1;
    private Graphics.EnumerateMetafileProc metafileDelegate;
    private Point destPoint;
    public Form1()
    {
        metafile1 = new Metafile("C:\\Intel\\fenhuang.emf");
        metafileDelegate = new Graphics.EnumerateMetafileProc(MetafileCallback);
        destPoint = new Point(50, 50);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.EnumerateMetafile(metafile1, destPoint, metafileDelegate);
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

        //metafile1.PlayRecord(recordType, flags, dataSize, dataArray);
        metafile1.PlayRecord(recordType, flags, dataSize, dataArray);
        callbackData = new PlayRecordCallback(PrcCallback);
        callbackData(EmfPlusRecordType.Comment, 1, 3, this.CreateGraphics().GetHdc());
        return true;
    }

    //PlayRecordCallback prc=new PlayRecordCallback(EmfPlusRecordType,int,int,IntPtr);
    private int count = 0;
    private void PrcCallback(EmfPlusRecordType recordType, int i1, int i2, IntPtr data)
    {
        //MessageBox.Show(recordType.ToString());
        this.Text = recordType.ToString() + " " + count++ + " " + data;
    }

    //static void Main()
    //{
    //    Application.Run(new Form1());
    //}
}