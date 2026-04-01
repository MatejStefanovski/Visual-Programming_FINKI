using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBotPart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            string prakjac = comboBox1.Text;
            string poraka = richTextBox1.Text;
            Message m = new Message(prakjac, poraka);
            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add(m);
            }
            else
            {
                Message temp = listBox1.Items[listBox1.Items.Count - 1] as Message;
                if (temp.Sender == m.Sender)
                {
                    errorProvider1.SetError(comboBox1, "Ne vnesuva ist prakjac 2 poraki");
                    return;
                }
                else
                {
                    errorProvider1.SetError(comboBox1, "");
                    listBox1.Items.Add(m);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("AI");
            comboBox1.Items.Add("User");
            Message m1 = new Message("Ai", "Poraka AI");
            Message m2 = new Message("Ai", "Poraka AI part 2");
            Message m3 = new Message("Ai", "Poraka AI part 3");
            Message m4 = new Message("User", "Poraka od User part 0");
            Message m5 = new Message("User", "Poraka od User part 1");
            Message m6 = new Message("User", "Poraka od User part 2");
            Message m7 = new Message("User", "Poraka od User part 3");
            listBox1.Items.Add(m4);
            listBox1.Items.Add(m1);
            listBox1.Items.Add(m5);
            listBox1.Items.Add(m2);
            listBox1.Items.Add(m6);
            listBox1.Items.Add(m3);
            listBox1.Items.Add(m7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            Message m = listBox1.SelectedItem as Message;
            int index = listBox1.SelectedIndex;
            if (listBox1.Items.Count == 1)
            {
                listBox1.Items.Remove(m);
            }
            else
            {
                if (listBox1.Items.Count-1 == listBox1.SelectedIndex)
                {
                    if (m.Sender == "User")
                    {
                        listBox1.Items.Remove(m);
                    }
                    else
                    {
                        listBox1.Items.RemoveAt(index);
                        listBox1.Items.RemoveAt(index - 1);
                    }
                }
                else
                {
                    if (m.Sender == "User")
                    {
                        listBox1.Items.RemoveAt(index + 1);
                        listBox1.Items.RemoveAt(index);
                    }
                    else
                    {
                        listBox1.Items.RemoveAt(index - 1);
                        listBox1.Items.RemoveAt(index);
                    }
                }
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                errorProvider1.SetError(comboBox1, "Vnesete prakjac");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
                e.Cancel = false;
            }
        }

        private void richTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                errorProvider1.SetError(richTextBox1, "Vnesete Poraka");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(richTextBox1, "");
                e.Cancel = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string poraka = textBox1.Text;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Message temp = listBox1.Items[i] as Message;
                if (temp.Poraka == poraka)
                {
                    Message m = temp;
                    listBox2.Items.Add(m);
                }
            }
        }
    }
}
