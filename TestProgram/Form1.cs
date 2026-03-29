using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAirport airport = new AddAirport();
            if (airport.ShowDialog() == DialogResult.OK)
            {
                Airport a = new Airport(airport.City, airport.Name, airport.Shortname);
                listBox1.Items.Add(a);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            AddDestination dest = new AddDestination();
            if (dest.ShowDialog() == DialogResult.OK)
            {
                Airport a=listBox1.SelectedItem as Airport;
                Destination dd = new Destination(dest.Name, dest.Length, dest.Price);
                a.AddAir(dd);
                ShowDest();
            }
        }

        private void ShowDest()
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex != -1)
            {
                double najskapa = 0;
                double prosecnaDolz = 0;
                Airport a = listBox1.SelectedItem as Airport;
                for (int i=0; i<a.Destinations.Count; i++)
                {
                    Destination d = a.Destinations[i];
                    listBox2.Items.Add(d);
                    if (d.Price > najskapa)
                    {
                        najskapa = d.Price;
                        textBox1.Text = d.ToString();
                    }
                    prosecnaDolz += d.Length;
                }
                textBox2.Text=(prosecnaDolz/a.Destinations.Count).ToString();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            DialogResult res = MessageBox.Show("Dali ste sigurni?", "Comfirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                ShowDest();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Airport a = new Airport("Barcelona", "El Prat", "BCN");
            listBox1.Items.Add(a);
        }
    }
}
