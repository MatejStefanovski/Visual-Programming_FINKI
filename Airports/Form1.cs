using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAirport aero = new AddAirport();
            if (aero.ShowDialog() == DialogResult.OK)
            {
                Airport a = new Airport(aero.City, aero.Name, aero.Shortname);
                listBox1.Items.Add(a);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDestination dest = new AddDestination();
            if (dest.ShowDialog() == DialogResult.OK)
            {
                string Name = dest.Name;
                int Price = dest.Price;
                int Distance = dest.Distance;
                Destination d = new Destination(Name, Price, Distance);
                Airport a = listBox1.SelectedItem as Airport;
                if (a == null) return;
                a.AddDest(d);
                loadDestinations();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDestinations();
        }

        public void loadDestinations()
        {
            listBox2.Items.Clear();

            Airport a = listBox1.SelectedItem as Airport;
            if (a == null)
            {
                textBox1.Clear();
                textBox2.Clear();
                return;
            }
            int najskapa = 0, prosek = 0;
            for (int i = 0; i < a.Destinations.Count; i++)
            {
                listBox2.Items.Add(a.Destinations[i]);
                Destination d = a.Destinations[i];
                if (d.Price > najskapa)
                {
                    najskapa = d.Price;
                }
                prosek += d.Distance;
            }
            if (a.Destinations.Count == 0)
            {
                return;
            }
            textBox1.Text = najskapa.ToString();
            textBox2.Text = (prosek/a.Destinations.Count).ToString();
        }
    }
}
