using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conferences
{
    public partial class Form1 : Form
    {
        public List<Conference> ConfList { get; set; }
        public Form1()
        {
            InitializeComponent();
            ConfList = new List<Conference>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddConference ac = new AddConference();
            if (ac.ShowDialog() == DialogResult.OK)
            {
                Conference c = new Conference(ac.Name, ac.Year);
                listBox1.Items.Add(c);
                ConfList.Add(c);
                if (!comboBox1.Items.Contains(ac.Year))
                {
                    comboBox1.Items.Add(ac.Year);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DialogResult res = MessageBox.Show("Дали сте сигурни дека сакате да ја избришете конференцијата?", "Confirm", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    ConfList.RemoveAt(listBox1.SelectedIndex);
                }
                else
                {
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conference c1 = new Conference("Конференција 1", 2025);
            Conference c2 = new Conference("Конференција 2", 2024);
            Conference c3 = new Conference("Конференција 3", 2023);
            listBox1.Items.Add(c1);
            listBox1.Items.Add(c2);
            listBox1.Items.Add(c3);
            ConfList.Add(c1);
            ConfList.Add(c2);
            ConfList.Add(c3);
        }

        private void ShowConf(int godina)
        {
            listBox1.Items.Clear();
            if (godina == -1)
            {
                for (int i=0; i<ConfList.Count; i++)
                {
                    listBox1.Items.Add(ConfList[i]);
                }
            }
            else
            {
                for (int i = 0; i < ConfList.Count; i++)
                {
                    Conference c = ConfList[i];
                    if (c.Year.Equals(godina))
                    {
                        listBox1.Items.Add(ConfList[i]);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(comboBox1.Text, out int text))
            {
                return;
            }
            ShowConf(text);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length <= 0)
            {
                ShowConf(-1);
                return;
            }
            if (int.TryParse(comboBox1.Text, out int res))
            {
                ShowConf(res);
            }
            else
            {
                ShowConf(-1);
            }
        }
    }
}
