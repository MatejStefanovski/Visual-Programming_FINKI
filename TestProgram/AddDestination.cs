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
    public partial class AddDestination : Form
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Price { get; set; }
        public AddDestination()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            Length = (int)numericUpDown1.Value;
            Price = (int)numericUpDown2.Value;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Ne treba da e prazno");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                e.Cancel = false;
            }
        }
    }
}
