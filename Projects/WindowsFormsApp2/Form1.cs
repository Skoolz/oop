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
        ModelB b;
        ModelA a;
        ModelC c;

        public Form1()
        {
            InitializeComponent();

            a = new ModelA();
            c = new ModelC();
            b = new ModelB(a, c);

            a.OnValueChange += Numeric_1_change_value;
            a.OnValueChange += TextBox_1_change_value;
            a.OnValueChange += Trace_1_change_value;
            a.OnValueChange += c.ModelAChange;
            a.OnValueChange += b.ModelAChange;

            b.OnValueChange += Numeric_2_change_value;
            b.OnValueChange += TextBox_2_change_value;
            b.OnValueChange += Trace_2_change_value;

            c.OnValueChange += Numeric_3_change_value;
            c.OnValueChange += TextBox_3_change_value;
            c.OnValueChange += Trace_3_change_value;
            c.OnValueChange += a.ModelCChange;
            c.OnValueChange += b.ModelCChange;

            a.SetValue(0);
            b.SetValue(0);
            c.SetValue(0);
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
            a.SetValue(Convert.ToInt32(textBox1.Text));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            a.SetValue(Convert.ToInt32(numericUpDown1.Value));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a.SetValue(trackBar1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                b.SetValue(Convert.ToInt32(textBox2.Text));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            b.SetValue(Convert.ToInt32(numericUpDown2.Value));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b.SetValue(trackBar2.Value);
        }

        private void textBox3_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                c.SetValue(Convert.ToInt32(textBox3.Text));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            c.SetValue(Convert.ToInt32(numericUpDown3.Value));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            c.SetValue(trackBar3.Value);
        }
    }
}
