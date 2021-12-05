using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp3
{
    public class Figure
    {
        public delegate void state_change();
        public event state_change OnStateChange;

        public virtual List<Color> colors { get; set; } = new List<Color>()
        {
            Color.White,
            Color.Green,
            Color.Blue,
            Color.Brown,
        };
        
        public virtual Color SelectColor { get; set; } = Color.Red;
        public Color current_color { get; private set; }

        public int x { get; private set; }
        public int y { get; private set; }

        public int width { get; private set; }
        public int height { get; private set; }

        public bool selected { get; private set; }

        public Figure(int x,int y,int width,int height)
        {
            OnStateChange += Form.ActiveForm.Refresh;
            current_color = colors[0];
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            
        }

        public void StateChanged()
        {
            OnStateChange();
        }

        public bool PointOverObject(int x, int y)
        {
            return x >= this.x && x <= this.x + this.width && y >= this.y && y <= this.y + this.height;
        }

        public void ChangeColor()
        {
            current_color = colors[(colors.IndexOf(current_color) + 1) % colors.Count];
            StateChanged();
        }

        public void Draw(PaintEventArgs e)
        {
            if (selected)
            {
                Pen frame = new Pen(SelectColor);
                e.Graphics.DrawRectangle(frame,new Rectangle(x-2,y-2,width+4,height+4));
            }
            Paint(current_color, e);
        }

        public virtual void Move(int dx,int dy)
        {
            Form1 form = (Form1)Form.ActiveForm;
            Panel panel = form.panel1;
            int borderx = panel.Size.Width;
            int bordery = panel.Size.Height;
            var temp_x = this.x + dx;
            var temp_y = this.y + dy;
            if (temp_x > 0 && (temp_x + width) < borderx && temp_y > 0 && (temp_y + height) < bordery)
            {

                this.x = temp_x;
                this.y = temp_y;
            }
            StateChanged();
        }

        public virtual void Paint(Color color, PaintEventArgs e)
        {
          
        }

        public void Select()
        {
            selected = true;
            StateChanged();
        }

        public void UnSelect()
        {
            selected = false;
            StateChanged();
        }

        public virtual void SetWidth(int value)
        {
            Form1 form = (Form1)Form.ActiveForm;
            Panel panel = form.panel1;
            int borderx = panel.Size.Width;

            var temp = value;
            if(temp >1 && x+temp < borderx)
            this.width = value;
            StateChanged();
        }
        public virtual void SetHeight(int value)
        {
            Form1 form = (Form1)Form.ActiveForm;
            Panel panel = form.panel1;
            int bordery = panel.Size.Height;

            var temp = value;
            if (temp > 1 && y + temp < bordery)
                this.height = value;
            StateChanged();
        }



    }

    public class Ellipse : Figure
    {
        public override List<Color> colors { get; set; } = new List<Color>()
        {
            Color.Red,
            Color.Magenta,
            Color.Yellow,
        };
        public Ellipse(int x,int y,int radious):base(x,y,radious,radious)
        {
        }


        public override void Paint(Color color, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(color);
            e.Graphics.FillEllipse(brush,new Rectangle(x,y,this.width,this.height));
        }
    }

    public class Rect:Figure
    {
        public Rect(int x,int y,int width,int height) : base(x, y, width, height)
        {

        }


        public override void Paint(Color color, PaintEventArgs e)
        {
            Brush brush=new SolidBrush(color);
            e.Graphics.FillRectangle(brush, new Rectangle(x,y,width,height));
        }
    }

    public class Triangle:Figure
    {
        public Point[] points = new Point[3];
        public Triangle(int x,int y,int width, int height):base(x,y,width,height) {
            CalculatePoints();
        }

        public void CalculatePoints()
        {
            points[0] = new Point(x, y + height);
            points[1] = new Point(x + width, y + height);
            points[2] = new Point(x + width/2, y);
            StateChanged();
        }

        public override void SetHeight(int value)
        {
            base.SetHeight(value);
            CalculatePoints();
        }

        public override void SetWidth(int value)
        {
            base.SetWidth(value);
            CalculatePoints();
        }

        public override void Move(int dx, int dy)
        {
            base.Move(dx, dy);
            CalculatePoints();
        }

        public override void Paint(Color color, PaintEventArgs e)
        {
            Brush b = new SolidBrush(color);
            e.Graphics.FillPolygon(b, points);
        }

    }
}
