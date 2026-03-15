using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int redbr = int.Parse(rbr.Text);
            string shortnamee = shortname.Text;
            string longnamee = longname.Text;
            for (int i=0; i<listBox1.Items.Count; i++)
            {
                Member temp = listBox1.Items[i] as Member;
                if (temp.redbr == redbr)
                {
                    flag=true;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show("Веќе постоечки број на партија");
                rbr.Clear();
                return;
            }
            Member m = new Member(redbr, shortnamee, longnamee, 0);
            listBox1.Items.Add(m);
            rbr.Clear();
            shortname.Clear();
            longname.Clear();
        }

        public decimal PrecentCalc(int redbr)
        {
            int br = 0;
            int vkupno = 0;
            for (int i=0; i<listBox1.Items.Count; i++)
            {
                Member m = listBox1.Items[i] as Member;
                if (m.redbr == redbr)
                {
                    br += m.votecount;
                }
                vkupno += m.votecount;
            }
            if (vkupno == 0)
            {
                return 0;
            }
            decimal d = ((decimal)br / vkupno) * 100;
            return Math.Round(d, 2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rezultati.Text = "";
            int redbr = int.Parse(rbglas.Text);
            int votes = (int)numericUpDown1.Value;
            bool flag = false;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Member m = listBox1.Items[i] as Member;
                if (m.redbr == redbr)
                {
                    m.AddVotes(votes);
                    flag=true;
                }
            }
            string s = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Member m = listBox1.Items[i] as Member;
                s += m.redbr + " " + m.shortname + " Гласови: " + m.votecount + " (" + PrecentCalc(m.redbr) + "%)" + "\n";
            }
            rezultati.Text = s;
            if (!flag)
            {
                MessageBox.Show("Невалидна Партија");
                return;
            }
        }
    }
}
