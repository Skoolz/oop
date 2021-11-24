using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Circle
    {
        public int radious { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public bool selected { get; private set; }

        public Circle(Form1 form, int x,int y, int r)
        {
            radious = r;
            this.x = x;
            this.y = y;

        }

        public bool MouseOverObject(int x,int y)
        {
            return x >= this.x - this.radious && x <= this.x + this.radious && y >= this.y - this.radious && y <= this.y + this.radious;
        }

        public void Paint(Color color, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            e.Graphics.FillEllipse(myBrush, new Rectangle(this.x-radious, this.y-radious,2* this.radious,2* this.radious));
        }

        public void Select()
        {
            selected = true;
        }

        public void UnSelect()
        {
            selected = false;
        }
    }
}
