using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_6
{
    public partial class Form1 : Form
    {
        int index = 1, index2 = 1;
        float xmin = 500, ymin = 500;

        public Form1()
        {
            InitializeComponent();
            myGraphics.initGraph(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float X = float.Parse(textBox1.Text);
            float Y = float.Parse(textBox2.Text);
            
            Engine.points.Add(new myPoint(X, Y));
            
            if (X < xmin)
            {
                xmin = X;
                index = Engine.points.Count - 1;
            }
            if (Y < ymin)
            {
                ymin = Y;
                index2 = Engine.points.Count - 1;
            }

            Engine.DrawPoint(myGraphics.grp);
            myGraphics.refreshGraph();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xmin = 500;
            ymin = 500;

            myGraphics.clearGraph();
            myGraphics.refreshGraph();
            Engine.points = new List<myPoint>();

            Random rnd = new Random();

            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                float X = rnd.Next(0, 500);
                float Y = rnd.Next(0, 500);
                
                Engine.points.Add(new myPoint(X, Y));
                
                if (X < xmin)
                {
                    xmin = X;
                    index = Engine.points.Count - 1;
                }
                if (Y < ymin)
                {
                    ymin = Y;
                    index2 = Engine.points.Count - 1;
                }
            }
            Engine.DrawPoint(myGraphics.grp);
            myGraphics.refreshGraph();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float min_y = Engine.points[0].Y;
            int min = 0;

            for (int i = 1; i < Engine.points.Count; i++)
            {
                float y = Engine.points[i].Y;
                
                if ((y < min_y) || (y == min_y && Engine.points[i].X < Engine.points[min].X))
                {
                    min_y = Engine.points[i].Y;
                    
                    min = i;
                }
            }

            (Engine.points[0], Engine.points[min]) = (Engine.points[min], Engine.points[0]);

            myPoint p0 = Engine.points[0];


        }
        private float Dist(myPoint p1, myPoint p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);

        }
            private int Orient(myPoint p1, myPoint p2, myPoint p3)
        {
            float val = (p2.Y - p1.Y) * (p3.X - p2.X) - (p2.X - p1.X) * (p3.Y - p2.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<myPoint> pointsFinal = new List<myPoint>();

            int p = index, q;

            do
            {
                pointsFinal.Add(Engine.points[p]);

                q = (p + 1) % Engine.points.Count;

                for (int i = 0; i < Engine.points.Count; i++)
                {
                    if (Orient(Engine.points[p], Engine.points[i], Engine.points[q]) == 2)
                    {
                        q = i;
                    }
                }

                p = q;
            }
            while (p != index);

            Engine.LinesDraw(myGraphics.grp, pointsFinal);
            myGraphics.refreshGraph();
        }
    }
}
