using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashScoreApp
{
    public partial class Form1 : Form
    {
        List<Natprevar> kosarka = new List<Natprevar>();
        List<Natprevar> fudbal = new List<Natprevar>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTeams team = new AddTeams();

            if (team.ShowDialog() == DialogResult.OK)
            {
                Natprevar m = team.Match;

                if (m.Tip == "Кошарка")
                {
                    kosarka.Add(m);
                    listBox1.Items.Add(m);
                }
                else if (m.Tip == "Фудбал")
                {
                    fudbal.Add(m);
                    listBox2.Items.Add(m);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Natprevar m = (Natprevar)listBox1.SelectedItem;
            if (m == null) return;

            listBox3.Items.Clear();
            listBox4.Items.Clear();

            foreach (var s in m.HomeScorers)
                listBox3.Items.Add(s);

            foreach (var s in m.AwayScorers)
                listBox4.Items.Add(s);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Natprevar m = (Natprevar)listBox2.SelectedItem;
            if (m == null) return;

            listBox3.Items.Clear();
            listBox4.Items.Clear();

            foreach (var s in m.HomeScorers)
                listBox3.Items.Add(s);

            foreach (var s in m.AwayScorers)
                listBox4.Items.Add(s);
        }
    }
}
