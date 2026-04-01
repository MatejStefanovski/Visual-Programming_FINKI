using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolokviumVezba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddNewTeam_Click(object sender, EventArgs e)
        {
            TeamForm t = new TeamForm();
            if (t.ShowDialog() == DialogResult.OK)
            {
                string Name = t.Name;
                string Country = t.Country;
                Tim tt = new Tim(Name, Country);
                listBox1.Items.Add(tt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (!ValidateChildren())
            {
                return;
            }*/
            if (listBox1.SelectedItems.Count == 2)
            {
                Tim t1 = listBox1.SelectedItems[0] as Tim;
                Tim t2 = listBox1.SelectedItems[1] as Tim;
                int coef1 = (int)numericUpDown1.Value;
                int coefx = (int)numericUpDown2.Value;
                int coef2 = (int)numericUpDown3.Value;
                string code = mtbCode.Text;
                if (t1.Country != t2.Country)
                {
                    errorProvider1.SetError(listBox1, "Mora da se od ista drzava");
                    return;
                }
                errorProvider1.SetError(listBox1, "");
                Match m = new Match(t1, t2, code, coef1, coefx, coef2);
                listBox2.Items.Add(m);
                listBox1.ClearSelected();
            }
            else
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tim t1 = new Tim("Barcelona", "Spain");
            Tim t2 = new Tim("Real Madrid", "Spain");
            listBox1.Items.Add(t1);
            listBox1.Items.Add(t2);
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("2");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string code = textBox2.Text;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                Match m = listBox2.Items[i] as Match;
                if (m.Code.Equals(code))
                {
                    listBox2.SelectedItem = m;
                }
                else
                {
                    listBox2.ClearSelected();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                return;
            }
            Match m = listBox2.SelectedItem as Match;
            string tip = comboBox1.Text;
            Livce l = new Livce(m, tip);
            listBox3.Items.Add(l);
            PresmetajKoef();
        }

        private void PresmetajKoef()
        {
            if (listBox3.Items.Count == 0)
            {
                textBox3.Text="0";
            }
            else
            {
                int koef = 1;
                for (int i = 0; i<listBox3.Items.Count; i++)
                {
                    Livce l = listBox3.Items[i] as Livce;
                    Match m = l.match;
                    string tip = l.tip;
                    if (tip == "1")
                    {
                        koef *= m.Coef1;
                    }
                    else if (tip == "X")
                    {
                        koef*=m.CoefX;
                    }
                    else
                    {
                        koef *= m.Coef2;
                    }
                }
                textBox3.Text=koef.ToString();
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            int uplata = (int)numericUpDown4.Value;
            int koef = int.Parse(textBox3.Text);
            koef *= uplata;
            textBox4.Text = koef.ToString();
        }

        private void button1_Validating(object sender, CancelEventArgs e)
        {
            /*if (listBox1.SelectedItems.Count < 2) return;
            Tim t1 = listBox1.SelectedItems[0] as Tim;
            Tim t2 = listBox1.SelectedItems[1] as Tim;
            if (t1.Country != t2.Country)
            {
                errorProvider1.SetError(listBox1, "Mora da se od ista drzava");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(listBox1, "");
                e.Cancel = false;
            }*/
        }

        private void mtbCode_Validating(object sender, CancelEventArgs e)
        {
            if (mtbCode.Text.Length == 0)
            {
                errorProvider1.SetError(mtbCode, "Vnesi sifra");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(mtbCode, "");
                e.Cancel= false;
            }
        }
    }
}
