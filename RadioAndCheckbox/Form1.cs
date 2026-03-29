using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioAndCheckbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 0;
            string str = "!";
            button1.Enabled=false;
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                if (radioButton1.Checked)
                {
                    price += 200;
                    str= "Mala";
                }
                else if (radioButton2.Checked)
                {
                    price += 500;
                    str = "Sredna";
                }
                else
                {
                    price += 800;
                    str = "Golema";
                }

                if (checkBox1.Checked)
                {
                    price += 40;
                }
                if (checkBox2.Checked)
                {
                    price += 30;
                }
                if (checkBox3.Checked)
                {
                    price += 20;
                }
            }
            if (str != "!")
            {
                button1.Enabled = true;
                Pizza p = new Pizza(str, price);
                listBox1.Items.Add(p);
                presmetajSmetka();
            }
        }

        private void presmetajSmetka()
        {
            if (listBox1.Items.Count > 0)
            {
                int price = 0;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    Pizza p = listBox1.Items[i] as Pizza;
                    price += p.Price;
                }
                textBox7.Text = price.ToString();
            }
        }
    }
}
