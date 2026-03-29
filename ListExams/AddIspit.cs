using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListExams
{
    public partial class AddIspit : Form
    {
        public string Mesec { get; set; }
        public int Godina { get; set; }
        public AddIspit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text=="")
            {
                errorProvider1.SetError(comboBox1, "Внесете Месец");
                return;
            }
            errorProvider1.SetError(comboBox1, ""); 
            Mesec = comboBox1.Text;
            Godina = (int)numericUpDown1.Value;
            DialogResult=DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
