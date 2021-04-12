using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PartialForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myGraphics.initGraph(pictureBox1);

            string[] text = File.ReadAllLines("../../ex03.in.txt");

            foreach (var item in text)
            {
                string[] subtext = item.Split(' ');

                int X = int.Parse(subtext[0]);
                int Y = int.Parse(subtext[1]);

                myPoint p = new myPoint(X, Y);

                p.draw(myGraphics.grp);
            }

            myGraphics.refreshGraph();
        }
    }
}
