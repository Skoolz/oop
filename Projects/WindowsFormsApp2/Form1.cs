using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Model m = new Model();

        public Form1()
        {
            InitializeComponent();

            m.OnValueChangeA += Numeric_1_change_value;
            m.OnValueChangeA += TextBox_1_change_value;
            m.OnValueChangeA += Trace_1_change_value;

            m.OnValueChangeB += Numeric_2_change_value;
            m.OnValueChangeB += TextBox_2_change_value;
            m.OnValueChangeB += Trace_2_change_value;

            m.OnValueChangeC += Numeric_3_change_value;
            m.OnValueChangeC += TextBox_3_change_value;
            m.OnValueChangeC += Trace_3_change_value;

            m.SetValueA(0);
            m.SetValueB(0);
            m.SetValueC(0);
        }

       

        public void Numeric_1_change_value(int value)
        {
            numericUpDown1.Value = value;
        }
        public void TextBox_1_change_value(int value)
        {
            textBox1.Text = value.ToString();
        }
        public void Trace_1_change_value(int value)
        {
            trackBar1.Value = value;
        }

        public void Numeric_2_change_value(int value)
        {
            numericUpDown2.Value = value;
        }
        public void TextBox_2_change_value(int value)
        {
            textBox2.Text = value.ToString();
        }
        public void Trace_2_change_value(int value)
        {
            trackBar2.Value = value;
        }

        public void Numeric_3_change_value(int value)
        {
            numericUpDown3.Value = value;
        }
        public void TextBox_3_change_value(int value)
        {
            textBox3.Text = value.ToString();
        }
        public void Trace_3_change_value(int value)
        {
            trackBar3.Value = value;
        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            m.SetValueA(Convert.ToInt32(textBox1.Text));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            m.SetValueA(Convert.ToInt32(numericUpDown1.Value));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            m.SetValueA(trackBar1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m.SetValueB(Convert.ToInt32(textBox2.Text));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            m.SetValueB(Convert.ToInt32(numericUpDown2.Value));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            m.SetValueB(trackBar2.Value);
        }

        private void textBox3_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m.SetValueC(Convert.ToInt32(textBox3.Text));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            m.SetValueC(Convert.ToInt32(numericUpDown3.Value));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            m.SetValueC(trackBar3.Value);
        }
    }
}
