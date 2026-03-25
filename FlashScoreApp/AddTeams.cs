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
    public partial class AddTeams : Form
    {

        public string Tip { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public string Rez { get; set; }

        public List<Strelec> HomeScorer { get; set; }
        public List<Strelec> AwayScorer { get; set; }

        public Natprevar Match { get; set; }

        public AddTeams()
        {
            InitializeComponent();
            HomeScorer = new List<Strelec>();
            AwayScorer = new List<Strelec>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Match = new Natprevar()
            {
                Tip = comboBox1.Text,
                Home = textBox1.Text,
                Away = textBox2.Text,
                Rez = textBox3.Text + ":" + textBox4.Text,
                HomeScorers = HomeScorer,
                AwayScorers = AwayScorer
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPlayer ap = new AddPlayer();
            if (ap.ShowDialog() == DialogResult.OK)
            {
                Strelec s = new Strelec(ap.Name, ap.Minute);
                HomeScorer.Add(s);
                listBox1.Items.Add(s);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPlayer ap = new AddPlayer();
            if (ap.ShowDialog() == DialogResult.OK)
            {
                Strelec s = new Strelec(ap.Name, ap.Minute);
                AwayScorer.Add(s);
                listBox2.Items.Add(s);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
