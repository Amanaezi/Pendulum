using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorLib;
using Point = System.Drawing.Point;

namespace Pendulum
{
    public class PictureBall
    {
        public Ball Ball { get; set; }
        public PictureBox Pb { get; set; }
        public double Scale { get; set; }

        private Control parent;

        

        public PictureBall(PictureBox pb, double scale)
        {
            parent = pb.Parent;
            Pb = pb;
            Scale = scale;
            Ball = new Ball()
            {
                R = new Vector((pb.Left + pb.Width / 2.0) / Scale, (pb.Top + pb.Height) / 2.0 / Scale),
                Radius = (pb.Height + pb.Width) / 4.0 / Scale
            };    
        }

        public PictureBall(Color color, Control Parent, int size = 20, double scale = 1) :
                this(CreatePb(color, Parent, size), scale)
        { }

        public static PictureBox CreatePb(Control parent, int size = 20)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(size, size);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            parent.Controls.Add(pb);
            return pb;
        }

        public static PictureBox CreatePb(Color color, Control parent, int size = 20)
        {
            PictureBox pb = CreatePb(parent, size);
            pb.BackColor = color;
            return pb;
        }

        public void MoveWithBounce(double dt, params VectorLib.Point[] points)
        {
            Ball.Bounce(points);
            Ball.Mp.Move(dt);
            Update();
        }
        public void Update()
        {
            Pb.Location = new Point((int)(Ball.R.X * Scale) - Pb.Width / 2, (int)(Ball.R.Y * Scale) - Pb.Height / 2);
            parent.Update();
        }

    }
}
