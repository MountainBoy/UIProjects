using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Performance
{
    public partial class PerformanceForm : Form
    {
        private int interval = 15;
        private Timer timer = new Timer();
        private int offset = 0;
        private System.Collections.Queue Points = new System.Collections.Queue(1);
        private int x = 5, y = 5;

        public PerformanceForm()
        {
            InitializeComponent();
            this.timer.Interval = 1000;
            this.timer.Tick += timer_Tick;
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.offset--;
            if (Math.Abs(this.offset) > this.interval)
            {
                this.offset = 0;
            }
            this.Points.Enqueue(this.PointGenerator());
            int len = this.Points.Count;
            if ((len * this.y) > this.Width)
            {
                this.Points.Dequeue();
            }
            this.Points.TrimToSize();
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                using (Bitmap bmp = this.CreateBackGraphics())
                {
                    g.DrawImage(bmp, new Rectangle(0, 0, this.Width, this.Height));
                }
            }
        }

        private void DrawGrid(Graphics g, int offset)
        {
            using (Pen pen = new Pen(Color.FromArgb(255, 0, 128, 64), 1f))//0,128,64
            {
                for (var x = 0; x < this.Width; x += interval)
                {
                    g.DrawLine(pen, new Point(x + this.offset, 0), new Point(x + this.offset, this.Height));
                }
                for (var y = 0; y < this.Height; y += interval)
                {
                    g.DrawLine(pen, new Point(0, y), new Point(this.Width, y));
                }
            }
        }

        private Bitmap CreateBackGraphics()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Black);
                    this.DrawGrid(g, this.offset);
                    int len = this.Points.Count;
                    PointF[] points = new PointF[len];
                    //this.DrawWave(g, this.Points.ToArray());
                    return bmp;
                }
            }
        }

        private void DrawWave(Graphics g, PointF[] points)
        {
            using (Pen pen = new Pen(Color.FromArgb(255, 0, 255, 0), 1f))//0,255,0
            {
                g.DrawBeziers(pen, points);
            }
        }

        private Random poRan = new Random();
        private PointF PointGenerator()
        {
            PointF point = new PointF(poRan.Next(0, this.Width), poRan.Next(-(this.Height), 0));
            return point;
        }
    }
}
