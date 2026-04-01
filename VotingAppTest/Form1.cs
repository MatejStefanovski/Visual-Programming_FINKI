using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingAppTest
{
    public partial class Form1 : Form
    {
        public List<Partija> Partii { get; set; }
        public Form1()
        {
            InitializeComponent();
            Partii = new List<Partija>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int redbr=int.Parse(rbglas.Text);
            int votes = (int)numericUpDown1.Value;
            if (listBox1.Items.Count == 0) return;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Partija p = listBox1.Items[i] as Partija;
                if (p.Rbr.Equals(redbr))
                {
                    p.AddVotes(votes);
                }
            }
            displayPartii();
            displayRez();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string redbr = rbr.Text;
            string sname = shortname.Text;
            string name = longname.Text;
            Partija p = new Partija(int.Parse(redbr), sname, name);
            Partii.Add(p);
            listBox1.Items.Add(p);
            displayPartii();
            displayRez();
        }

        private void displayPartii()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Partii.Count; i++)
            {
                listBox1.Items.Add(Partii[i]);
            }
        }
        private double procent(int redbr)
        {
            double count = 0;
            Partija p = null;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Partija temp = listBox1.Items[i] as Partija;

                if (temp.Rbr.Equals(redbr))
                {
                    p = temp;
                }

                count += temp.Votes;
            }

            if (p == null || count == 0)
                return 0;

            double momentalno = p.Votes;
            double d = (1.0 * momentalno / count)*100;

            return d;
        }

        private void displayRez()
        {
            string s = "";
            for (int i = 0; i<listBox1.Items.Count; i++)
            {
                Partija p = listBox1.Items[i] as Partija;
                s += listBox1.Items[i].ToString() + " " + p.Votes + " " + procent(p.Rbr) + "%" + "\n";
            }
            rezultati.Text=s;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Partija p1 = new Partija(1, "P1", "Partija1");
            Partija p2 = new Partija(2, "P2", "Partija2");
            Partija p3 = new Partija(3, "P3", "Partija3");
            listBox1.Items.Add (p1);
            listBox1.Items.Add (p2);
            listBox1.Items.Add (p3);
            Partii.Add(p1);
            Partii.Add (p2);
            Partii.Add (p3);
            displayRez();
        }
    }
}
