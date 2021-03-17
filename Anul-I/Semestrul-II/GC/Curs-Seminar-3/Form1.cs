using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_3
{
    public partial class Form1 : Form
    {

        static Graphics gfx;
        static Pen pen = new Pen(Color.Black);
        static PointF[] points;
        public Form1()
        {
            InitializeComponent();
        }    

        private void Draw_Click_1(object sender, EventArgs e)
        {
            points = new PointF[]
            {
                new PointF(float.Parse(textBox1.Text),float.Parse(textBox2.Text)),
                new PointF(float.Parse(textBox3.Text),float.Parse(textBox4.Text)),
                new PointF(float.Parse(textBox5.Text),float.Parse(textBox6.Text)),
            };

            gfx.Clear(Color.White);
            gfx.DrawPolygon(pen, points);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
        }
    }
}
