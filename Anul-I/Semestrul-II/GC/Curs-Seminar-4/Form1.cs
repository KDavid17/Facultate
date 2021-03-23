using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_4
{
    public partial class Form1 : Form
    {
        public static int[] latura = new int[100];
        public static int contor = 0;
        public static PointF[] ps;
        public Form1()
        {
            InitializeComponent();
            myGraphics.initGraph(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float X = float.Parse(textBox1.Text);
            float Y = float.Parse(textBox2.Text);
            latura[contor] = int.Parse(textBox3.Text);
            Engine.points.Add(new myPoint(X, Y));
            myGraphics.grp.DrawRectangle(Pens.Black, X, Y, latura[contor], latura[contor]);
            myGraphics.refreshGraph();
            contor++;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Engine.drawLines(myGraphics.grp, latura);
            myGraphics.refreshGraph();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myGraphics.clearGraph();

            int counter = int.Parse(textBox4.Text);

            Random rnd = new Random();

            PointF[] ps = new PointF[counter];

            for (int i = 0; i < counter; i++)
            {
                ps[i] = new PointF(rnd.Next(0, 200), rnd.Next(0, 400));
            }
            myGraphics.grp.DrawPolygon(Pens.Black, ps);
            myGraphics.refreshGraph();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                {
                    pen = new Pen(Color.Blue);
                }
                else if (i == 1)
                {
                    pen = new Pen(Color.Aqua);
                }
                else if (i == 2)
                {
                    pen = new Pen(Color.DarkMagenta);
                }
                else if (i == 3)
                {
                    pen = new Pen(Color.Green);
                }
                else if (i == 4)
                {
                    pen = new Pen(Color.Yellow);
                }
                else if (i == 5)
                {
                    pen = new Pen(Color.Purple);
                }
                else if (i == 6)
                {
                    pen = new Pen(Color.Orange);
                }
                else if (i == 7)
                {
                    pen = new Pen(Color.LimeGreen);
                }
                float X = rnd.Next(0, 400);
                float Y = rnd.Next(0, 400);
                latura[contor] = rnd.Next(50, 100);
                Engine.points.Add(new myPoint(X, Y));
                myGraphics.grp.DrawRectangle(pen, X, Y, latura[contor], latura[contor]);
                myGraphics.refreshGraph();
                contor++;
            }

        }
    }
}
