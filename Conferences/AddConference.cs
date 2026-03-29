using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conferences
{
    public partial class AddConference : Form
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public AddConference()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            Year = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Треба да внесете име");
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
