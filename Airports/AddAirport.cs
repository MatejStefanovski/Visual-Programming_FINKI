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
    public partial class AddAirport : Form
    {
        public string City { get; set; }

        public string Name { get; set; }

        public string Shortname { get; set; }
        public AddAirport()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            City = textBox1.Text;
            Name = textBox2.Text;
            Shortname = textBox3.Text;
            Airport a = new Airport(City, Name, Shortname);
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox1, "Името на градот е задолжително");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
                e.Cancel = false;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox2, "Мора да внесете име");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox2, null);
                e.Cancel = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Trim().Length != 3)
            {
                errorProvider1.SetError(textBox3, "Кратенката треба да има точно 3 големи букви");
                e.Cancel = true;
            }
            else
            {
                string sh = textBox3.Text.Trim();
                foreach (char c in sh)
                {
                    if (Char.IsLower(c))
                    {
                        errorProvider1.SetError(textBox3, "Кратенката треба да има точно 3 големи букви");
                        e.Cancel = true;
                        return;
                    }
                }
                errorProvider1.SetError(textBox3, null);
                e.Cancel = false;
            }
        }
    }
}


/*
 private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tbName, "Името е задолжително");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbName, null);
                e.Cancel = false;
            }
        }

        private void tbShort_Validating(object sender, CancelEventArgs e)
        {
            if (tbShort.Text.Trim().Length != 3)
            {
                errorProvider1.SetError(tbShort, "Кратенката треба да има точно 3 големи букви");
                e.Cancel = true;
            }
            else
            {
                string sh = tbShort.Text.Trim();
                foreach (char c in sh)
                {
                    if (Char.IsLower(c))
                    {
                        errorProvider1.SetError(tbShort, "Кратенката треба да има точно 3 големи букви");
                        e.Cancel = true;
                        return;
                    }
                }
                errorProvider1.SetError(tbShort, null);
                e.Cancel = false;
            }
        }
 */