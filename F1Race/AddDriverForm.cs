using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F1Race
{
    public partial class AddDriverForm : Form
    {
        public string Ime { get; set; }
        public int Vozrast { get; set; }
        public bool PrvVozac { get; set; }
        public AddDriverForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ime = textBox1.Text;
            Vozrast = (int)numericUpDown1.Value;
            if (checkBox1.Checked)
            {
                PrvVozac = true;
            }
            else
            {
                PrvVozac = false;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Мора да внесете име");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                e.Cancel = false;
            }
        }
    }
}
