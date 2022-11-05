using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorLib;

namespace Pendulum
{
    public partial class Form1 : Form
    {
        PictureBall pb;
        VectorLib.PointD p1, p2, p3, p4;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            p1 = new PointD(-10, ClientSize.Height);
            p2 = new PointD(Width, ClientSize.Height / 2);
            p3 = new PointD(Width, -10);
            p4 = new PointD(-10, -10);
            pb = new PictureBall(Color.Green, this);
            pb.Ball.V = new Vector(500, 600);
            g = CreateGraphics();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            g.DrawLine(Pens.Red, (int)p1.X, (int)p1.Y, (int)p2.X, (int)p2.Y);
            pb.MoveWithBounce(Timer1.Interval / 1000.0, p1, p2, p3, p4, p1);
            pb.Update();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            g.DrawLine(Pens.Red, (int)p1.X, (int)p1.Y, (int)p2.X, (int)p2.Y);
            Timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
