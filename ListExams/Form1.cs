using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListExams
{
    public partial class Form1 : Form
    {
        List<Ispit> ispiti = new List<Ispit>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddIspit ispit = new AddIspit();
            if (ispit.ShowDialog() == DialogResult.OK)
            {
                Ispit i = new Ispit(ispit.Mesec, ispit.Godina);
                ispiti.Add(i);
                listBox1.Items.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ispit i = new Ispit("Juni", 2014);
            i.Zadaca1.Description = "Прва задача";
            i.Zadaca1.Points = 50;
            i.Zadaca2.Description = "Втора задача";
            i.Zadaca2.Points = 50;
            Ispit i2 = new Ispit("Јануари", 2015);
            i2.Zadaca1.Description = "Прва задача";
            i2.Zadaca1.Points = 25;
            i2.Zadaca2.Description = "Втора задача";
            i2.Zadaca2.Points = 75;
            listBox1.Items.Add(i);
            listBox1.Items.Add(i2);
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                ispiti.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                Ispit i = listBox1.SelectedItem as Ispit;
                richTextBox1.Text = i.Zadaca1.Description.ToString();
                richTextBox2.Text = i.Zadaca2.Description.ToString();
                numericUpDown1.Value = i.Zadaca1.Points;
                numericUpDown2.Value = i.Zadaca2.Points;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            Ispit i = listBox1.SelectedItem as Ispit;
            i.Zadaca1.Description = richTextBox1.Text;
            i.Zadaca1.Points = (int)numericUpDown1.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            Ispit i = listBox1.SelectedItem as Ispit;
            i.Zadaca2.Description = richTextBox2.Text;
            i.Zadaca2.Points = (int)numericUpDown2.Value;
        }
    }
}
