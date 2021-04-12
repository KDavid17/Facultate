using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Curs_Seminar_6
{
    public class myPoint
    {
        public static int size = 4;
        public float X, Y;
        public string name;
        public Color fillColor;
        public Color drawColor;

        public myPoint(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
            this.fillColor = Color.Red;
            this.drawColor = Color.Black;
        }

        public myPoint(float X, float Y, Color fillColor, Color drawColor)
        {
            this.X = X;
            this.Y = Y;
            this.fillColor = fillColor;
            this.drawColor = drawColor;
        }

        public void draw(Graphics grp)
        {
            Pen pen = new Pen(drawColor);
            SolidBrush sb = new SolidBrush(fillColor);
            grp.FillEllipse(sb, X - size, Y - size, size * 2 + 1, size * 2 + 1);
            grp.DrawEllipse(pen, X - size, Y - size, size * 2 + 1, size * 2 + 1);
            grp.DrawString(name, new Font("Arial", 10), sb, X, Y);
        }
    }
}
