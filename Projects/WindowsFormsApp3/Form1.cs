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
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        DynamicList<Figure> figures = new DynamicList<Figure>();
        Figure selected_figure = null;

        public Form1()
        {
            InitializeComponent();
        }

        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
            this.Refresh();
        }

        public void DeleteFigure(Figure figure)
        {
            figures.Remove(figure);
            this.Refresh();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        public void SelectFigure(Figure figure)
        {
            if (selected_figure != null) selected_figure.UnSelect();
            selected_figure = figure;
            figure.Select();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddFigure(new Ellipse(10, 10, 100));
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddFigure(new Rect(10, 10, 100, 100));
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddFigure(new Triangle(10, 10, 100, 100));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void panel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (selected_figure != null)
            {
                if (e.KeyCode == Keys.W)
                {
                    selected_figure.SetWidth(selected_figure.width * 2);
                }
                else if (e.KeyCode == Keys.Q)
                {
                    selected_figure.SetWidth(selected_figure.width / 2);
                }
                else if (e.KeyCode == Keys.E)
                {
                    selected_figure.SetHeight(selected_figure.height / 2);
                }
                else if (e.KeyCode == Keys.R)
                {
                    selected_figure.SetHeight(selected_figure.height * 2);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    selected_figure.Move(0, -3);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    selected_figure.Move(0, 3);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    selected_figure.Move(-3, 0);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    selected_figure.Move(3, 0);
                }
                else if(e.KeyCode==Keys.C)
                {
                    selected_figure.ChangeColor();
                }

                else if (e.KeyCode == Keys.Delete)
                {
                    DeleteFigure(selected_figure);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure f in figures) f.Draw(e);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (figures.Count > 0)
            {
                if (selected_figure != null)
                {
                    selected_figure.UnSelect();
                    selected_figure = null;
                }
                foreach (Figure f in figures)
                {
                    if (f.PointOverObject(e.X, e.Y))
                    {
                        SelectFigure(f);
                        break;
                    }
                }
                figures.Remove(selected_figure);
                figures.Add(selected_figure);
                this.Refresh();
            }
        }
    }
}
