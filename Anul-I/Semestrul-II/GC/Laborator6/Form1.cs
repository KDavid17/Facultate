using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_5
{
    public partial class Form1 : Form
    {
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();
            myGraphics.initGraph(pictureBox1);
            myGraphics.refreshGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGraphics.refreshGraph();
            myGraphics.clearGraph();
            float X = float.Parse(textBox1.Text);
            float Y = float.Parse(textBox2.Text);
            Engine.pointsAll.Add(new myPoint(X, Y));
            Engine.sortPoints();

            counter++;

            foreach (myPoint p in Engine.pointsAll)
            {
                Engine.drawPoint(myGraphics.grp);             
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            myGraphics.refreshGraph();
        }
    }
}
