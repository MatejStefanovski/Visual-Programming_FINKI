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
    public partial class AddAirport : Form
    {
        public string City { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public AddAirport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            City = textBox1.Text;
            Name = textBox2.Text;
            Shortname = textBox3.Text;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Ne treba da e prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                e.Cancel = false;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                errorProvider1.SetError(textBox2, "Ne treba da e prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                e.Cancel = false;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string t = textBox3.Text;
            if (t.Length != 3)
            {
                errorProvider1.SetError(textBox3, "Treba da e 3 bukvi");
                e.Cancel= true;
                return;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (Char.IsLower(t[i]))
                {
                    errorProvider1.SetError(textBox3, "Treba golemi bukvi");
                    e.Cancel= true;
                    return;
                }
            }
            errorProvider1.SetError(textBox3, "");
            e.Cancel = false;
        }
    }
}
