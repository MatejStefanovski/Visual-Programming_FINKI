using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            if (listBox1.Items.Count == 0)
            {
                string s = comboBox1.Text;
                string message = richTextBox1.Text;
                Message m = new Message(s, message);
                listBox1.Items.Add(m);
            }
            else
            {
                string s = comboBox1.Text;
                string message = richTextBox1.Text;
                Message mes = new Message(s, message);
                Message m = listBox1.Items[listBox1.Items.Count - 1] as Message;
                if (m.Sender == comboBox1.Text)
                {
                    errorProvider1.SetError(comboBox1, "Не може да се внесе пораката");
                    return;
                }
                else
                {
                    errorProvider1.SetError(comboBox1, "");
                    listBox1.Items.Add(mes);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("AI");
            comboBox1.Items.Add("User");

            Message m1 = new Message("User", "Poraka pratena od User");
            Message m2 = new Message("AI", "poraka pratena od AI");
            Message m3 = new Message("User", "Poraka part 2");
            Message m4 = new Message("AI", "Poraka AI Part 2");
            listBox1.Items.Add(m1);
            listBox1.Items.Add(m2);
            listBox1.Items.Add(m3);
            listBox1.Items.Add(m4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            int index = listBox1.SelectedIndex;
            if (listBox1.Items.Count==1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                Message m = listBox1.Items[index] as Message;
                if (m.Sender.Equals("AI"))
                {
                    Message pred = listBox1.Items[index - 1] as Message;
                    listBox1.Items.Remove(pred);
                    listBox1.Items.Remove(m);
                }
                else
                {
                    int posleden = listBox1.Items.Count - 1;
                    if (index<posleden)
                    {
                        Message posle = listBox1.Items[index+1] as Message;
                        listBox1.Items.Remove(posle);
                    }
                    listBox1.Items.Remove(m);
                }
            }
        }

        private void richTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                errorProvider1.SetError(richTextBox1, "Внесете порака");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError(richTextBox1, "");
                e.Cancel = false;
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Внесете праќач");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
                e.Cancel = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string poraka = textBox1.Text;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Message m = listBox1.Items[i] as Message;
                if (m.Text.Equals(poraka))
                {
                    listBox2.Items.Add(m);
                }
            }
        }
    }
}
