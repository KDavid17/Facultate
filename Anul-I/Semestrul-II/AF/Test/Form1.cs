using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myGraphics.initGraph(pictureBox1);
            myGraphics.grp.DrawEllipse(Pens.Green, 100, 100, 150, 175);
            myGraphics.refreshGraph();
        }

        private void pointDisplay_Click(object sender, EventArgs e)
        {
            float X = float.Parse(textBox1.Text);
            float Y = float.Parse(textBox2.Text);
            Engine.points.Add(new myPoint(X, Y));
            Engine.draw(myGraphics.grp);
            myGraphics.refreshGraph();
        }

        private void removePoint_Click(object sender, EventArgs e)
        {
            myGraphics.clearGraph();
            Engine.remove();
            Engine.draw(myGraphics.grp);
            myGraphics.refreshGraph();
        }
    }
}
