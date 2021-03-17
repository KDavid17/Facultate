using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public static class myGraphics
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color backColor = Color.White;
        public static int resx, resy;

        public static void initGraph(PictureBox Display)
        {
            display = Display;          
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            resx = display.Width;
            resy = display.Height;
            clearGraph();
        }

        public static void clearGraph()
        {
            grp.Clear(backColor);
        }

        public static void refreshGraph()
        {
            display.Image = bmp;
        }
    }
}
