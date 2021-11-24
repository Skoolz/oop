using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomList;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DynamicList<Circle> circles = new DynamicList<Circle>();
        DynamicList<Circle> selected_cirlces = new DynamicList<Circle>();
        public bool mouse_select = false;
        public bool key_press = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckSelect(e.X, e.Y, !key_press)) return;

            CreateCircle(e.X, e.Y, 20);
        }

        public bool CheckSelect(int x, int y, bool need_remove = true)
        {
            for (int i = circles.Count-1;i >=0;i--)
            {
                Circle circle = circles[i];
                if (circle.MouseOverObject(x,y))
                {
                    SelectCircle(circle, need_remove);
                    return true;
                }
            }
            return false;
        }

        public void CreateCircle(int x, int y, int r)
        {
            Circle circle = new Circle(this, x, y, r);
            circles.Add(circle);
            SelectCircle(circle);
        }

        public void SelectCircle(Circle circle, bool need_remove=true)
        {
            if (need_remove)
            {
                foreach (Circle c in selected_cirlces)
                {
                    c.UnSelect();
                }
                selected_cirlces.Clear();
            }
            circle.Select();
            selected_cirlces.Add(circle);
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Circle circle in circles)
            {
                Color color = circle.selected ? Color.Red:Color.Blue;
                circle.Paint(color, e);
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                key_press = true;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_select = true;
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_select = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                key_press = false;
            }
            else if(e.KeyCode==Keys.Delete)
            {
                foreach(Circle circle in selected_cirlces)
                {
                    circles.Remove(circle);
                } 
                selected_cirlces.Clear();
                this.Refresh();
            }
        }
    }
}
