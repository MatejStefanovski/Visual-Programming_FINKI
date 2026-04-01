using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F1Race
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDriverForm driver = new AddDriverForm();
            if (driver.ShowDialog() == DialogResult.OK)
            {
                string Ime = driver.Ime;
                int Vozrast = driver.Vozrast;
                bool PrvVozac = driver.PrvVozac;
                Driver d = new Driver(Ime, Vozrast, PrvVozac);
                listBox1.Items.Add(d);
                ShowLaps();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            DialogResult res = MessageBox.Show("Дали сте сигурно дека сакате да го избришете возачот?", "Comfirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Driver d1 = new Driver("Verstapen", 29, true);
            Driver d2 = new Driver("Hamilton", 35, false);
            listBox1.Items.Add(d1);
            listBox1.Items.Add(d2);
            ShowLaps();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int minutes = (int)numericUpDown1.Value;
            int seconds = (int)numericUpDown2.Value;
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            Lap l = new Lap(minutes, seconds);
            Driver d = listBox1.SelectedItem as Driver;
            d.Krugovi.Add(l);
            ShowLaps();
            bestLap();
        }

        private void ShowLaps()
        {
            if (listBox1.SelectedIndex == -1) return;
            listBox2.Items.Clear();
            Driver d = listBox1.SelectedItem as Driver;
            for (int i = 0; i < d.Krugovi.Count; i++)
            {
                Lap l = d.Krugovi[i] as Lap;
                listBox2.Items.Add(l);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int t = (int)numericUpDown2.Value;
            if (t == 60)
            {
                numericUpDown1.Value = numericUpDown1.Value+1;
                numericUpDown2.Value = 0;
            }
            if (t==-1)
            {
                if (numericUpDown1.Value > 0)
                {
                    numericUpDown1.Value = 1;
                    numericUpDown2.Value = 59;
                }
            }
        }

        private void numericUpDown2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                numericUpDown1.Value = numericUpDown1.Value-1;
                numericUpDown2.Value = 59;
            }
        }
        private void bestLap()
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            int best = 9999;
            Driver d = listBox1.SelectedItem as Driver;
            for (int i = 0; i < d.Krugovi.Count; i++)
            {
                Lap l = d.Krugovi[i] as Lap;
                int time = l.Minuti * 60 + l.Sekundi;
                if (time < best)
                {
                    best = time;
                    textBox1.Text = l.ToString();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bestLap();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex == -1) return;
            Driver d = listBox1.SelectedItem as Driver;
            int time = (int)numericUpDown3.Value;
            for (int i = 0; i < d.Krugovi.Count; i++)
            {
                Lap t = d.Krugovi[i] as Lap;
                int tt = t.Minuti * 60 + t.Sekundi;
                if (tt > time)
                {
                    listBox2.Items.Add(t);
                }
            }
        }
    }
}
